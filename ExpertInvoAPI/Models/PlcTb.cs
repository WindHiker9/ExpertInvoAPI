using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Since this page is for a table, this page is probs not necessary for just an API
namespace ExpertInvoAPI.Models
{
    [Table("PLCDataTest")]
    public class PlcTb
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "IP Address not found!")]
        public string IP_Address { get; set; }
        [Required(ErrorMessage = "PLC register is not found!!")]
        public int Register { get; set; }
        [Required(ErrorMessage = "PLC Value is not found!!")]
        public int Value { get; set; }
        [Required(ErrorMessage = "Time Written is not found!!")]
        public DateTime TimeWritten { get; set; }

    }
}
