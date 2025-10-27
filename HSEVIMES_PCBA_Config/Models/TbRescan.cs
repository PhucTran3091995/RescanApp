using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEVIMES_PCBA_Config.Models
{
    [Table("tb_rescan")]
    public class TbRescan
    {
        public int Id { get; set; }
        public string? Pba { get; set; }
        public string? Model_Name { get; set; }

        public string? Pid { get; set; }
        public string? Part_No { get; set; }
        public string? Work_Order { get; set; }
        public DateTime? Scan_At { get; set; }
        public DateTime? Rescan_At { get; set; }
        public int Qty { get; set; }
        public string? Model_Suffix { get; set; }
    }
}
