using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Management;

namespace HSEVIMES_PCBA_Config.Services
{
    public static class PrinterDiagnostics
    {
        public static List<string> GetInstalledPrinters()
        {
            var list = new List<string>();
            foreach (string name in PrinterSettings.InstalledPrinters)
                list.Add(name);
            return list;
        }

        public static List<(string Name, string Port)> GetPrintersWithPorts()
        {
            var result = new List<(string, string)>();
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT Name, PortName FROM Win32_Printer");
                foreach (ManagementObject mo in searcher.Get())
                {
                    var name = mo["Name"]?.ToString() ?? "";
                    var port = mo["PortName"]?.ToString() ?? "";
                    result.Add((name, port));
                }
            }
            catch (ManagementException)
            {
                // WMI unavailable or not supported on this platform
            }
            return result;
        }
    }
}