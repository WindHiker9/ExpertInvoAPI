using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblTimeCard
    {
        public int TimeCardId { get; set; }
        public string Name { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public string MondayHours { get; set; }
        public string TuesdayHours { get; set; }
        public string WednesdayHours { get; set; }
        public string ThursdayHours { get; set; }
        public string FridayHours { get; set; }
        public string SaturdayHours { get; set; }
        public string SundayHours { get; set; }
        public string Notes { get; set; }
    }
}
