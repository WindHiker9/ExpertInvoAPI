using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertInvoAPI.Models
{
    public class EmployeeKey
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public string PersonalEmail { get; set; }
        public int PrimaryPhone { get; set; }
        public int SecondaryPhone { get; set; }
        public string EmergencyContact { get; set; }
        public int EmergencyContactNumber { get; set; }
    }
}
