using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblIdeas
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int OwnerEmployeeId { get; set; }
        public string Description { get; set; }
        public decimal InitialCost { get; set; }
        public TimeSpan InitialStartTime { get; set; }
    }
}
