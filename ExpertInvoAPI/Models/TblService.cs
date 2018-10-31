using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblService
    {
        public string ServiceName { get; set; }
        public decimal? ServiceCost { get; set; }
        public string ServiceMaterials { get; set; }
        public int ServiceId { get; set; }
        public decimal? ServiceTime { get; set; }
        public decimal? ServicePrice { get; set; }
    }
}
