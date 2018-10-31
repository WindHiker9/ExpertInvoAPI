using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class PlcdataTest
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public int Register { get; set; }
        public int Value { get; set; }
        public DateTime TimeWritten { get; set; }
    }
}
