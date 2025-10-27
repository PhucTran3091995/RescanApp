using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEVIMES_PCBA_Config.Models
{
    [Table("tb_scan_out")]
    public class TbScanOut
    {
        public int Id { get; set; }
        public string? Pid { get; set; }
        public string? Model_Name { get; set; }
        public string? Model_Suffix { get; set; }
        public string? Work_Order { get; set; }
        public string? Part_No { get; set; }
        public DateTime? Scan_At { get; set; }
        public DateTime? Print_At { get; set; }
        public int Qty { get; set; }
        public DateTime? Scan_Date { get; set; }
        public DateTime? Print_Date { get; set; }
    }
}
