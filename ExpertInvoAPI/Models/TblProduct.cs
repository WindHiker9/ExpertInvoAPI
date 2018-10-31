using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductCost { get; set; }
        public string ProductMaterial { get; set; }
    }
}
