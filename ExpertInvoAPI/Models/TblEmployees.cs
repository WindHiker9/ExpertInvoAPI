using System;
using System.Collections.Generic;

namespace ExpertInvoAPI.Models
{
    public partial class TblEmployees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string JobDescription { get; set; }
    }
}
