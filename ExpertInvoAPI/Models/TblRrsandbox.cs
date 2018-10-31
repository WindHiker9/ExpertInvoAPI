using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblRrsandbox
    {
        public int EntryId { get; set; }
        public string Initials { get; set; }
        public string OrderNumber { get; set; }
        public int Temperature { get; set; }
        public int Pressure { get; set; }
        public string InjectionTime { get; set; }
        public int PressNumber { get; set; }
        public string MoldProtection { get; set; }
        public string MoldCleaningInfo { get; set; }
        public string Notes { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public int RevLevelReviewed { get; set; }
    }
}
