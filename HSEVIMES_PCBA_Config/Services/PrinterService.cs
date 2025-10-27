using HSEVIMES_PCBA_Config.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Threading.Tasks;

namespace HSEVIMES_PCBA_Config.Services
{
    public class PrinterService
    {
        private readonly string _targetPrinterName;
        private readonly string _targetPort;

        public PrinterService()
        {
            // Đọc từ App.config
            _targetPrinterName = ConfigurationManager.AppSettings["PrinterName"] ?? "EPSON TM-T83III Receipt";
            _targetPort = ConfigurationManager.AppSettings["PrinterPort"] ?? "TMUSB001";
        }

        /// <summary>
        /// Tìm máy in đúng với tên và port
        /// </summary>
        private string? FindPrinter()
        {
            // 1️⃣ Kiểm tra danh sách cài sẵn
            foreach (string name in PrinterSettings.InstalledPrinters)
            {
                if (name.Contains(_targetPrinterName, StringComparison.OrdinalIgnoreCase))
                    return name;
            }

            // 2️⃣ Nếu chưa thấy, kiểm tra qua WMI
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT Name, PortName FROM Win32_Printer");
                foreach (ManagementObject mo in searcher.Get())
                {
                    var name = mo["Name"]?.ToString();
                    var port = mo["PortName"]?.ToString();
                    if (string.Equals(name, _targetPrinterName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(port, _targetPort, StringComparison.OrdinalIgnoreCase))
                    {
                        return name;
                    }
                }
            }
            catch
            {
                // ignore nếu không truy cập được WMI
            }

            return null;
        }

        /// <summary>
        /// In nhãn cho 1 nhóm PBA (toàn bộ danh sách PID)
        /// </summary>
        public async Task<(bool isOk, string message)> PrintLabelAsync(List<TbRescan> rescans)
        {
            if (rescans == null || rescans.Count == 0)
                return (false, "Không có dữ liệu để in!");

            string printerToUse = FindPrinter() ?? _targetPrinterName;

            var printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerToUse;

            if (!printDoc.PrinterSettings.IsValid)
            {
                return (false, $"Máy in '{printerToUse}' không hợp lệ hoặc chưa kết nối.");
            }

            var drawer = new UI.DrawLabel();
            printDoc.PrintPage += (s, ev) =>
            {
                foreach (var rescan in rescans)
                {
                    drawer.RenderLabel(ev, rescan);
                }
            };

            try
            {
                await Task.Run(() => printDoc.Print());
                return (true, $"Đã in label cho PBA [{rescans.First().Pba}] với {rescans.Count} PID.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi in nhãn: " + ex.Message);
            }
        }
    }
}
