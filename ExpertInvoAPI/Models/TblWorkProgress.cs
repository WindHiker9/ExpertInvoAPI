using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblWorkProgress
    {
        public int EntryId { get; set; }
        public string Name { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public string InProgressWork { get; set; }
        public string FinishedWork { get; set; }
        public string WorkGoals { get; set; }
        public string Notes { get; set; }
    }
}
