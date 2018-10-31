using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblCustomer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
