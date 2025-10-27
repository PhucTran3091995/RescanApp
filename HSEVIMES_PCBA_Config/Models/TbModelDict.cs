using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSEVIMES_PCBA_Config.Models
{
    [Table("tb_model_dict")]
    public class TbModelDict
    {
        public int Id { get; set; }
        public string? Part_No { get; set; }
        public string? Model_Name { get; set; }
        public string? Model_Suffix { get; set; }
    }
}
