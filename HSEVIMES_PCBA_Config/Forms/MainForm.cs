﻿using HSEVIMES_PCBA_Config.Services;
using HSEVIMES_PCBA_Config.UI;
using QRCoder;
using HSEVIMES_PCBA_Config.Data;
using HSEVIMES_PCBA_Config.Services;            // available
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Media;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms; // ensure Keys, KeyEventArgs
using MySqlConnector;

namespace HSEVIMES_PCBA_Config
{
    public partial class MainForm : Form
    {
        private readonly ScanService _scanService = new ScanService();
        private SerialPort? _serialPort;
        // Insert inside MainForm class (near existing _serialPort field)
        private readonly StringBuilder _serialBuffer = new StringBuilder();
        private bool _isProcessingFromSerial = false;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            // Wire textbox key event so scanner (which usually sends Enter) triggers processing
            txtBarcode.KeyDown += TxtBarcode_KeyDown;
            // removed duplicate: do not re-subscribe btnCheckSQL here if designer already wires it
            btnAddCom.Click += btnAddCom_Click;
            cbCheckCom.DropDown += CbCheckCom_DropDown;
            InitSerialFromAppSettings();
            txtBarcode.Focus();
            LoadAvailableComPorts();
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            await RefreshTodayPbaSummaryAsync();
        }

        private async Task RefreshTodayPbaSummaryAsync()
        {
            var summary = await _scanService.GetTodayPbaSummaryAsync();
            gridResults.DataSource = null;
            gridResults.DataSource = summary;
            gridResults.Refresh();
        }

        private void ClearRescanInfo()
        {
            lblModelName.Text = string.Empty;
            lblModelSuffix.Text = string.Empty;
            lblPartNo.Text = string.Empty;
            lblWO.Text = string.Empty;
            lblQty.Text = string.Empty;
            lblProdDate.Text = string.Empty;
            lblYearPBA.Text = string.Empty;
            lblMonthPBA.Text = string.Empty;
            picBarcodePBA.Image = null;
            picBarcodePBA.Text = string.Empty;
        }
        private async void btnScan_Click(object sender, EventArgs e)
        {
            await ProcessScannedPidAsync();
        }

        // Centralized scan processing reused by button and textbox Enter
        private async Task ProcessScannedPidAsync()
        {
            string pid = txtBarcode.Text.Trim();
            // Thêm điều kiện kiểm tra định dạng EBRxxxx
            if (string.IsNullOrEmpty(pid) || !System.Text.RegularExpressions.Regex.IsMatch(pid, @"^EBR.{19}$"))
            {
                lblMessage.Text = "Incorrect PID code\r\n !";
                txtBarcode.Clear();
                txtBarcode.Focus();
                return;
            }

            var (ok, message) = await _scanService.ScanPidAsync(pid);
            lblResult.Text = ok ? "OK" : "NG";
            lblResult.ForeColor = ok ? Color.Green : Color.Red;

            // play sounds
            if (ok) PlayPassSound(); else PlayFailSound();

            lblMessage.Text = message;

            // reload data
            await RefreshTodayPbaSummaryAsync();
            if (ok)
            {
                await DisplayRescanInfoAsync(pid);
            }

            // Clear textbox so user can scan next PID immediately
            txtBarcode.Clear();
            txtBarcode.Focus();
            txtBarcode.SelectAll();
        }

        private async Task DisplayRescanInfoAsync(string pid)
        {
            // Lấy thông tin rescans theo PID
            var rescans = await _scanService.GetAllRescansAsync();
            var rescan = rescans.LastOrDefault(r => r.Pid == pid);

            if (rescan != null)
            {
                var modelInfo = await _scanService.GetModelInfoByPartNoAsync(rescan.Part_No);

                lblModelName.Text = modelInfo?.Model_Name ?? rescan.Model_Name ?? string.Empty;
                lblModelSuffix.Text = modelInfo?.Model_Suffix ?? rescan.Model_Suffix ?? string.Empty;
                // Nếu có ModelSuffix, hãy thêm vào model và database, ví dụ: lblModelSuffix.Text = rescan.Model_Suffix ?? "";
                lblPartNo.Text = rescan.Part_No ?? string.Empty;
                lblWO.Text = rescan.Work_Order ?? string.Empty;
                lblQty.Text = rescans.Where(r => r.Pba == rescan.Pba).Sum(r => r.Qty).ToString();
                lblProdDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                // Year PBA và Month PBA từ Rescan_At
                lblYearPBA.Text = DateTime.Now.Year.ToString();
                lblMonthPBA.Text = DateTime.Now.Month.ToString("D2");

                // Barcode PBA
                string pbaCode = rescan.Pba ?? string.Empty;
                picBarcodePBA.Text = pbaCode;

                // Tạo QR code và hiển thị lên PictureBox
                if (!string.IsNullOrEmpty(pbaCode))
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(pbaCode, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(3);
                    picBarcodePBA.Image = qrCodeImage; // 3 là kích thước pixel cho mỗi ô
                }
                else
                {
                    picBarcodePBA.Image = null;
                }
            }
            else
            {
                ClearRescanInfo();
            }
        }

        // Handle Enter (scanner finish) on textbox
        private async void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                await ProcessScannedPidAsync();
            }
        }

        // replace btnPrinter_Click implementation with this
        // replace existing btnPrinter_Click implementation with this
        private async void btnPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                var currentPba = _scanService.CurrentPba;
                if (string.IsNullOrEmpty(currentPba))
                {
                    MessageBox.Show(
                        "No current PBA to print. Please scan PID first. / No hay PBA actual para imprimir. Por favor escanee el PID primero.",
                        "Notice / Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var allRescans = await _scanService.GetAllRescansAsync();
                var itemsInCurrentPba = allRescans
                    .Where(r => r.Pba == currentPba)
                    .OrderBy(r => r.Id)
                    .ToList();

                if (itemsInCurrentPba.Count == 0)
                {
                    MessageBox.Show(
                        "No records found for current PBA. / No se encontraron registros para el PBA actual.",
                        "Notice / Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Use DrawLabel to render each TbRescan on its own print page
                var drawer = new DrawLabel();
                int pageIndex = 0;

                bool hasPrinted = false;
                using (var printDoc = new PrintDocument())
                {

                    if (!printDoc.PrinterSettings.IsValid)
                    {
                        MessageBox.Show(
                            "Printer is invalid or not connected. / La impresora no es válida o no está conectada.",
                            "Error / Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    printDoc.PrintPage += (s, ev) =>
                    {
                        // render current item
                        var item = itemsInCurrentPba[pageIndex];
                        drawer.RenderLabel(ev, item);

                        // advance page index and indicate more pages if needed
                        ev.HasMorePages = false;
                    };

                    // print (synchronous)
                    printDoc.Print();
                    hasPrinted = true;
                }

                if (hasPrinted)
                {
                    _scanService.ResetCurrentPba();
                    await RefreshTodayPbaSummaryAsync();
                    ClearRescanInfo();
                }

                txtBarcode.Clear();
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Print label error: " + ex.Message + " / Error al imprimir etiqueta: " + ex.Message,
                    "Error / Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnDeletePBA_Click(object sender, EventArgs e)
        {
            string pba = txtDeletePBA.Text.Trim();
            if (string.IsNullOrEmpty(pba))
            {
                MessageBox.Show(
                    "Please enter the PBA to delete. / Por favor ingrese el PBA a eliminar.",
                    "Notice / Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDeletePBA.Focus();
                return;
            }

            // Optional: preview count before confirming
            var all = await _scanService.GetAllRescansAsync();
            var matches = all.Where(r => string.Equals(r.Pba, pba, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matches.Count == 0)
            {
                MessageBox.Show(
                    $"PBA [{pba}] not found in database. / PBA [{pba}] no encontrado en la base de datos.",
                    "Notice / Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Found {matches.Count} records for PBA [{pba}].\r\nDo you want to delete them? / Se encontraron {matches.Count} registros para PBA [{pba}].\r\n¿Desea eliminarlos?",
                "Confirm delete / Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var (ok, message) = await _scanService.DeletePbaAsync(pba);
            MessageBox.Show(
                message + (ok ? " / Operation succeeded." : " / Operation failed."),
                ok ? "Notice / Aviso" : "Error / Error",
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            // refresh UI
            await RefreshTodayPbaSummaryAsync();

            txtDeletePBA.Clear();
            txtDeletePBA.Focus();
        }

        private async void btnSearchPBA_Click(object sender, EventArgs e)
        {
            string pba = txtSearchPBA.Text.Trim();

            // If user entered PBA use it; otherwise use date from dtPBADate
            DateTime? dateFilter = null;
            if (string.IsNullOrEmpty(pba))
            {
                // Use selected date for searching PBAs in that day
                dateFilter = dtPBADate.Value.Date;
            }

            if (string.IsNullOrEmpty(pba) && dateFilter == null)
            {
                MessageBox.Show(
                    "Please enter a PBA or select a date to search. / Por favor ingrese un PBA o seleccione una fecha para buscar.",
                    "Notice / Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(pba))
            {
                // New behavior: when user types a PBA, fetch full records for that PBA and show all details
                var records = await _scanService.GetRescansByPbaAsync(pba);

                if (records == null || records.Count == 0)
                {
                    MessageBox.Show(
                        $"No records found for PBA [{pba}]. / No se encontraron registros para PBA [{pba}].",
                        "Notice / Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    grSearchPBAdata.DataSource = null;
                    return;
                }

                // Bind full details to grid (explicit columns)
                var bindList = records.Select(r => new
                {
                    r.Id,
                    r.Pba,
                    r.Pid,
                    r.Model_Name,
                    r.Model_Suffix,
                    r.Part_No,
                    r.Work_Order,
                    Scan_At = r.Scan_At?.ToString("yyyy-MM-dd HH:mm:ss"),
                    Rescan_At = r.Rescan_At?.ToString("yyyy-MM-dd HH:mm:ss"),
                    r.Qty
                }).ToList();

                grSearchPBAdata.DataSource = null;
                grSearchPBAdata.DataSource = bindList;
                grSearchPBAdata.Refresh();
            }
            else
            {
                // Existing behavior: search summaries by date
                var results = await _scanService.GetPbaSummariesAsync(
                    string.IsNullOrWhiteSpace(pba) ? null : pba,
                    dateFilter
                );

                if (results == null || results.Count == 0)
                {
                    MessageBox.Show(
                        "No results found. / No se encontraron resultados.",
                        "Notice / Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    grSearchPBAdata.DataSource = null;
                    return;
                }

                // Bind results to grid with required columns:
                var bindList = results.Select(r => new
                {
                    PBA_No = r.Pba,
                    Part_No = r.PartNo,
                    PBA_date = r.RescanAt,
                    Qty = r.Qty
                }).ToList();

                grSearchPBAdata.DataSource = null;
                grSearchPBAdata.DataSource = bindList;
                grSearchPBAdata.Refresh();
            }
        }

        // Play PASS sound from Properties.Resources.PASS
        private void PlayPassSound()
        {
            PlaySoundFromResource(Properties.Resources.PASS);
        }

        // Play FAIL sound from Properties.Resources.FAIL
        private void PlayFailSound()
        {
            PlaySoundFromResource(Properties.Resources.FAIL);
        }

        // helper: accepts UnmanagedMemoryStream, Stream or byte[]
        private void PlaySoundFromResource(object? resource)
        {
            if (resource == null) return;

            try
            {
                byte[]? bytes = null;

                if (resource is UnmanagedMemoryStream ums)
                {
                    using var ms = new MemoryStream();
                    ums.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                else if (resource is Stream s)
                {
                    using var ms = new MemoryStream();
                    s.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                else if (resource is byte[] b)
                {
                    bytes = b;
                }

                if (bytes == null || bytes.Length == 0) return;

                // Play in background to avoid blocking UI
                _ = Task.Run(() =>
                {
                    try
                    {
                        using var ms2 = new MemoryStream(bytes);
                        using var player = new SoundPlayer(ms2);
                        player.PlaySync(); // PlaySync ensures stream remains valid during playback
                    }
                    catch
                    {
                        // ignore sound play errors
                    }
                });
            }
            catch
            {
                // ignore resource handling errors
            }
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            // If grid control itself is null → do nothing (per requirement)
            if (grSearchPBAdata == null)
                return;

            // If there's no data source or no rows → inform and exit
            if (grSearchPBAdata.DataSource == null || grSearchPBAdata.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new SaveFileDialog();
            dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            dlg.FileName = $"search_pba_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var sw = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8);

                // collect visible columns in display order
                var cols = new System.Collections.Generic.List<DataGridViewColumn>();
                for (int i = 0; i < grSearchPBAdata.Columns.Count; i++)
                {
                    var c = grSearchPBAdata.Columns[i];
                    if (c.Visible)
                        cols.Add(c);
                }

                // write header
                for (int i = 0; i < cols.Count; i++)
                {
                    if (i > 0) sw.Write(',');
                    sw.Write(EscapeCsv(cols[i].HeaderText ?? ""));
                }
                sw.WriteLine();

                // write rows
                foreach (DataGridViewRow row in grSearchPBAdata.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int i = 0; i < cols.Count; i++)
                    {
                        if (i > 0) sw.Write(',');
                        var cell = row.Cells[cols[i].Index];
                        var text = cell?.Value?.ToString() ?? "";
                        sw.Write(EscapeCsv(text));
                    }
                    sw.WriteLine();
                }

                MessageBox.Show($"Exported CSV to:\r\n{dlg.FileName}", "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            static string EscapeCsv(string input)
            {
                if (input == null) return "";
                bool mustQuote = input.Contains(',') || input.Contains('"') || input.Contains('\n') || input.Contains('\r');
                if (input.Contains('"'))
                    input = input.Replace("\"", "\"\""); // double quotes
                return mustQuote ? $"\"{input}\"" : input;
            }
        }

        // Add these methods inside the MainForm class

        private void InitSerialFromAppSettings()
        {
            try
            {
                var portName = ConfigurationManager.AppSettings["PortScanner.PortName"];
                if (string.IsNullOrWhiteSpace(portName))
                    return; // scanner not configured

                try
                {
                    ConfigureSerialPort(portName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[WARN] Không thể mở cổng được cấu hình {portName}: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[WARN] InitSerialFromAppSettings: {ex.Message}");
            }
        }



        private void LoadAvailableComPorts()
        {
            try
            {
                var ports = SerialPort
                    .GetPortNames()
                    .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                    .ToArray();

                cbCheckCom.BeginUpdate();
                cbCheckCom.Items.Clear();

                if (ports.Length == 0)
                {
                    cbCheckCom.Items.Add("(Không có cổng COM)");
                    cbCheckCom.SelectedIndex = 0;
                    cbCheckCom.Enabled = false;
                    btnAddCom.Enabled = false;
                    cbCheckCom.EndUpdate();
                    return;
                }

                cbCheckCom.Items.AddRange(ports);
                cbCheckCom.EndUpdate();

                string? preferredPort = _serialPort?.PortName;
                if (string.IsNullOrWhiteSpace(preferredPort))
                {
                    preferredPort = ConfigurationManager.AppSettings["PortScanner.PortName"];
                }

                int selectedIndex = -1;
                if (!string.IsNullOrWhiteSpace(preferredPort))
                {
                    selectedIndex = Array.IndexOf(ports, preferredPort);
                }

                cbCheckCom.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;
                cbCheckCom.Enabled = true;
                btnAddCom.Enabled = true;
            }
            catch (Exception ex)
            {
                cbCheckCom.Items.Clear();
                cbCheckCom.Items.Add("(Lỗi tải cổng COM)");
                cbCheckCom.SelectedIndex = 0;
                cbCheckCom.Enabled = false;
                btnAddCom.Enabled = false;
                cbCheckCom.EndUpdate();
                Debug.WriteLine($"[WARN] LoadAvailableComPorts: {ex.Message}");
            }
        }

        private void CbCheckCom_DropDown(object? sender, EventArgs e)
        {
            LoadAvailableComPorts();
        }

        private void ConfigureSerialPort(string portName)
        {
            CloseSerialPort();

            int baud = int.TryParse(ConfigurationManager.AppSettings["PortScanner.BaudRate"], out var b) ? b : 9600;
            int dataBits = int.TryParse(ConfigurationManager.AppSettings["PortScanner.DataBits"], out var db) ? db : 8;

            Parity parity = Parity.None;
            var parityStr = ConfigurationManager.AppSettings["PortScanner.Parity"];
            if (!string.IsNullOrWhiteSpace(parityStr) && Enum.TryParse(parityStr, true, out Parity parsedParity))
            {
                parity = parsedParity;
            }

            StopBits stopBits = StopBits.One;
            var stopBitsStr = ConfigurationManager.AppSettings["PortScanner.StopBits"];
            if (!string.IsNullOrWhiteSpace(stopBitsStr) && Enum.TryParse(stopBitsStr, true, out StopBits parsedStopBits))
            {
                stopBits = parsedStopBits;
            }

            var serialPort = new SerialPort(portName, baud, parity, dataBits, stopBits)
            {
                NewLine = "\r\n",
                ReadTimeout = 500,
                ReceivedBytesThreshold = 1,
                DtrEnable = true,
                RtsEnable = true
            };

            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                serialPort.Open();
                _serialBuffer.Clear();
                _serialPort = serialPort;
            }
            catch
            {
                serialPort.DataReceived -= SerialPort_DataReceived;
                serialPort.Dispose();
                throw;
            }
        }
        private void CloseSerialPort()
        {
            if (_serialPort == null)
                return;

            try
            {
                _serialPort.DataReceived -= SerialPort_DataReceived;
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                _serialPort.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[WARN] CloseSerialPort: {ex.Message}");
            }
            finally
            {
                _serialPort = null;
            }
        }
        private void btnAddCom_Click(object? sender, EventArgs e)
        {
            if (cbCheckCom.SelectedItem is not string selectedPort || selectedPort.StartsWith("(", StringComparison.Ordinal))
            {
                MessageBox.Show("Vui lòng chọn cổng COM hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ConfigureSerialPort(selectedPort);
                MessageBox.Show($"Đã cấu hình scanner với cổng {selectedPort}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở cổng {selectedPort}:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCheckSQL_Click(object? sender, EventArgs e)
        {
            btnCheckSQL.Enabled = false;
            var previousCursor = Cursor;
            var previousText = btnCheckSQL.Text;
            Cursor = Cursors.WaitCursor;
            btnCheckSQL.Text = "Checking...";

            try
            {
                var (isSuccess, details) = await TryConnectToMySqlAsync();
                if (isSuccess)
                {
                    MessageBox.Show("Kết nối MySQL: OK", "Kiểm tra MySQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var builder = new StringBuilder();
                    builder.AppendLine("Kết nối MySQL: FAIL");

                    if (!string.IsNullOrWhiteSpace(details))
                    {
                        builder.AppendLine();
                        builder.AppendLine(details.Trim());
                    }

                    MessageBox.Show(builder.ToString(), "Kiểm tra MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor = previousCursor;
                btnCheckSQL.Text = previousText;
                btnCheckSQL.Enabled = true;
            }
        }

        private static async Task<(bool Success, string? ErrorDetails)> TryConnectToMySqlAsync()
        {
            string? connectionString = BuildMySqlConnectionStringFromConfig(out var configurationError);

            if (!string.IsNullOrWhiteSpace(configurationError))
            {
                return (false, configurationError);
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return (false, "Không tìm thấy cấu hình kết nối MySQL trong App.config.");
            }

            await using var connection = new MySqlConnection(connectionString);

            try
            {
                await connection.OpenAsync();
                return (true, null);
            }
            catch (MySqlException ex)
            {
                return (false, BuildMySqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                return (false, BuildExceptionDetails(ex));
            }
        }

        private static string? BuildMySqlConnectionStringFromConfig(out string? errorMessage)
        {
            errorMessage = null;

            string? connectionNameFromAppSettings = ConfigurationManager.AppSettings["MySqlConnectionName"];

            if (!string.IsNullOrWhiteSpace(connectionNameFromAppSettings))
            {
                var configuredConnection = ConfigurationManager.ConnectionStrings[connectionNameFromAppSettings];
                if (configuredConnection != null && !string.IsNullOrWhiteSpace(configuredConnection.ConnectionString))
                {
                    return configuredConnection.ConnectionString;
                }
            }

            var defaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (defaultConnection != null && !string.IsNullOrWhiteSpace(defaultConnection.ConnectionString))
            {
                return defaultConnection.ConnectionString;
            }

            var host = ConfigurationManager.AppSettings["MySqlHost"];
            var port = ConfigurationManager.AppSettings["MySqlPort"];
            var user = ConfigurationManager.AppSettings["MySqlUser"];
            var password = ConfigurationManager.AppSettings["MySqlPassword"];
            var database = ConfigurationManager.AppSettings["MySqlDatabase"];

            if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(database))
            {
                errorMessage = "Thiếu cấu hình MySQL (Host/User/Database).";
                return null;
            }

            string resolvedPort = string.IsNullOrWhiteSpace(port) ? "3306" : port;

            return $"server={host};port={resolvedPort};database={database};user={user};password={password};";
        }

        private static string BuildMySqlExceptionMessage(MySqlException ex)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Mã lỗi MySQL: {ex.Number}");
            if (!string.IsNullOrWhiteSpace(ex.SqlState))
            {
                builder.AppendLine($"SQLSTATE: {ex.SqlState}");
            }
            builder.AppendLine(ex.Message);

            if (ex.InnerException != null)
            {
                builder.AppendLine();
                builder.AppendLine(BuildExceptionDetails(ex.InnerException));
            }

            return builder.ToString();
        }

        private static string BuildExceptionDetails(Exception ex)
        {
            var builder = new StringBuilder();
            Exception? current = ex;
            while (current != null)
            {
                if (builder.Length > 0)
                {
                    builder.AppendLine();
                }

                builder.AppendLine(current.Message);
                current = current.InnerException;
            }

            return builder.ToString();
        }


        private void SerialPort_DataReceived(object? sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (sender is not SerialPort sp) return;

                // ⚠️ Đợi 30ms để đảm bảo scanner gửi đủ dữ liệu
                Thread.Sleep(30);

                // Đọc tất cả dữ liệu hiện có trong buffer
                string incoming = sp.ReadExisting();
                if (string.IsNullOrWhiteSpace(incoming)) return;

                lock (_serialBuffer)
                {
                    _serialBuffer.Append(incoming);
                    string buffer = _serialBuffer.ToString();

                    // Scanner gửi kết thúc bằng LF ('\n') hoặc CRLF → tách theo đó
                    var parts = buffer.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var part in parts)
                    {
                        string line = part.Trim('\r', '\n', '\0', ' ');

                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        Debug.WriteLine($"[DEBUG] Line nhận được: '{line}' (Len={line.Length})");

                        // Kiểm tra định dạng EBR + 19 ký tự (tổng 22)
                        if (line.StartsWith("EBR", StringComparison.OrdinalIgnoreCase) && line.Length == 22)
                        {
                            Debug.WriteLine($"[DEBUG] Hợp lệ, xử lý PID: {line}");
                            _serialBuffer.Clear();

                            this.BeginInvoke(async () =>
                            {
                                if (_isProcessingFromSerial) return;
                                _isProcessingFromSerial = true;

                                try
                                {
                                    txtBarcode.Text = line;
                                    await ProcessScannedPidAsync();
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine($"[ERROR] Process PID: {ex.Message}");
                                }
                                finally
                                {
                                    _isProcessingFromSerial = false;
                                }
                            });
                        }
                        else
                        {
                            Debug.WriteLine($"[DEBUG] Chuỗi không hợp lệ hoặc chưa đủ ký tự: '{line}'");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] SerialPort_DataReceived: {ex.Message}");
            }
        }



        // Ensure serial port is closed/disposed when form closes
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseSerialPort();
            base.OnFormClosing(e);
        }
    }
}