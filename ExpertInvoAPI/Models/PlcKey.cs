using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertInvoAPI.Models
{
    public class PlcKey
    {
        public int Id { get; set; }
        public string IP_Address { get; set; }
        public int Register { get; set; }
        public int Value { get; set; }
        public DateTime TimeWritten { get; set; }
    }
}

