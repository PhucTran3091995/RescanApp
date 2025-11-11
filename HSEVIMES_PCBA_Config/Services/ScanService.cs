using HSEVIMES_PCBA_Config.Data;
using HSEVIMES_PCBA_Config.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSEVIMES_PCBA_Config.Services
{
    public class ScanService
    {
        private static readonly object _lock = new object();
        private readonly AppDbContext _context;
        private readonly Random _random = new Random();
        private static string? _currentPba = null;

        public ScanService()
        {
            _context = new AppDbContext();
        }

        public string? CurrentPba => _currentPba;

        public async Task<(bool isOk, string message)> ScanPidAsync(string pid)
        {
            // 1️⃣ Verificar si el PID existe en TbScanOut
            var pidData = await _context.TbScanOut.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Pid == pid);

            if (pidData == null)
                return (false, $"¡El PID [{pid}] no se ha escaneado en el sistema!");

            // 2️⃣ Verificar si el PID ya existe en TbRescan
            bool exists = await _context.TbRescan
                .AsNoTracking()
                .AnyAsync(r => r.Pid == pid);
            if (exists)
                return (false, $"¡El PID [{pid}] ya fue reescaneado!");

            string currentPartNo = pidData.Part_No ?? string.Empty;

            TbModelDict? modelInfo = null;
            if (!string.IsNullOrWhiteSpace(currentPartNo))
            {
                modelInfo = await _context.TbModelDict.AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Part_No == currentPartNo);
            }

            string? modelName = modelInfo?.Model_Name ?? pidData.Model_Name;
            string? modelSuffix = modelInfo?.Model_Suffix ?? pidData.Model_Suffix;

            lock (_lock) // si se usa static
            {
                if (_currentPba == null)
                {
                    _currentPba = GeneratePbaCode();
                }
                else
                {
                    var count = _context.TbRescan.Count(r => r.Pba == _currentPba);
                    if (count > 0)
                    {
                        var firstPartNo = _context.TbRescan
                            .Where(r => r.Pba == _currentPba)
                            .Select(r => r.Part_No)
                            .FirstOrDefault();
                        if (!string.Equals(firstPartNo, currentPartNo, StringComparison.OrdinalIgnoreCase))
                        {
                            return (false, $"El PID [{pid}] tiene un número de pieza diferente ({firstPartNo}). ¡No se permite insertar!");
                        }
                    }
                }
            }

            // 4️⃣ Crear un nuevo registro
            var newRecord = new TbRescan
            {
                Pba = _currentPba!,
                Model_Name = modelName,
                Pid = pid,
                Part_No = currentPartNo,
                Work_Order = pidData.Work_Order,
                Scan_At = pidData.Scan_At,
                Rescan_At = DateTime.Now,
                Qty = pidData.Qty,
                Model_Suffix = modelSuffix
            };

            try
            {
                await _context.TbRescan.AddAsync(newRecord);
                await _context.SaveChangesAsync();
                return (true, $"OK - El PID [{pid}] se ha añadido al PBA [{_currentPba}].");
            }
            catch (Exception ex)
            {
                return (false, $"Error al guardar el PID [{pid}]: {ex.Message}");
            }
        }

        public async Task<int> GetRescanCountAsync(string? pba)
        {
            if (string.IsNullOrWhiteSpace(pba))
                return 0;

            return await _context.TbRescan.CountAsync(r => r.Pba == pba);
        }
        public void ResetCurrentPba()
        {
            _currentPba = null;
        }

        private string GeneratePbaCode()
        {
            string pbaCode = $"PBA{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            return pbaCode;
        }


        public async Task<List<TbRescan>> GetAllRescansAsync()
        {
            return await _context.TbRescan
                .OrderByDescending(r => r.Rescan_At)
                .ToListAsync();
        }

        public async Task<TbModelDict?> GetModelInfoByPartNoAsync(string? partNo)
        {
            if (string.IsNullOrWhiteSpace(partNo))
                return null;

            return await _context.TbModelDict
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Part_No == partNo);
        }

        public class TodayPbaSummary
        {
            public string? Date { get; set; }
            public int PbaCount { get; set; }
        }
        public async Task<List<TbRescan>> GetTodayPbaSummaryAsync()
        {
            var start = DateTime.Today;
            var end = start.AddDays(1);

            return await _context.TbRescan
                .AsNoTracking()
                .Where(r => r.Rescan_At.HasValue && r.Rescan_At.Value >= start && r.Rescan_At.Value < end)
                .OrderByDescending(r => r.Rescan_At)
                .ToListAsync();
        }
        public async Task<(bool isOk, string message)> DeletePbaAsync(string pba)
        {
            if (string.IsNullOrWhiteSpace(pba))
                return (false, "El código PBA está vacío.");

            var items = await _context.TbRescan
                .Where(r => r.Pba == pba)
                .ToListAsync();

            if (items.Count == 0)
                return (false, $"El PBA [{pba}] no existe en la base de datos.");

            _context.TbRescan.RemoveRange(items);

            try
            {
                await _context.SaveChangesAsync();
                // Si el PBA actual coincide, reiniciar
                if (string.Equals(_currentPba, pba, StringComparison.OrdinalIgnoreCase))
                {
                    _currentPba = null;
                }
                return (true, $"Se han eliminado {items.Count} registros para el PBA [{pba}].");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar el PBA [{pba}]: {ex.Message}");
            }
        }

        public class PbaSummary
        {
            public string? Pba { get; set; }
            public string? PartNo { get; set; }
            public DateTime? RescanAt { get; set; }
            public int Qty { get; set; }
        }

        public async Task<List<PbaSummary>> GetPbaSummariesAsync(string? pbaFilter, DateTime? dateFilter)
        {
            var query = _context.TbRescan.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pbaFilter))
            {
                query = query.Where(r => r.Pba == pbaFilter);
            }
            else if (dateFilter.HasValue)
            {
                // Comparar por rango de fechas
                var start = dateFilter.Value.Date;
                var end = start.AddDays(1);
                query = query.Where(r => r.Rescan_At.HasValue && r.Rescan_At.Value >= start && r.Rescan_At.Value < end);
            }
            else
            {
                // sin filtro: retornar lista vacía
                return new List<PbaSummary>();
            }

            var grouped = await query
                .GroupBy(r => new { r.Pba, r.Part_No })
                .Select(g => new PbaSummary
                {
                    Pba = g.Key.Pba,
                    PartNo = g.Key.Part_No,
                    RescanAt = g.Max(x => x.Rescan_At),
                    Qty = g.Sum(x => x.Qty)
                })
                .OrderByDescending(x => x.RescanAt)
                .ToListAsync();

            return grouped;
        }

        public async Task<List<TbRescan>> GetRescansByPbaAsync(string pba)
        {
            if (string.IsNullOrWhiteSpace(pba))
                return new List<TbRescan>();

            return await _context.TbRescan
                .Where(r => r.Pba == pba)
                .OrderByDescending(r => r.Rescan_At)
                .ToListAsync();
        }
    }
}
