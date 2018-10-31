using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpertInvoAPI.Models
{
    [Table("PLCDataTest")]
    public class PlcTb
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the IP address")]
        public string IP_Address { get; set; }
        [Required(ErrorMessage = "Enter the register")]
        public int Register { get; set; }
        [Required(ErrorMessage = "Enter the value")]
        public int Value { get; set; }
        [Required(ErrorMessage = "Enter the time written")]
        public DateTime TimeWritten { get; set; }
    }
}
