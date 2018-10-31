using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpertInvoAPI.Models
{
    [Table("tblEmployee")]
    public class EmployeeTb
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter your age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter your birthdate")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Enter your personal email")]
        public string PersonalEmail { get; set; }
        [Required(ErrorMessage = "Enter your primary phone")]
        public int PrimaryPhone { get; set; }
        [Required(ErrorMessage = "Enter your secondary phone")]
        public int SecondaryPhone { get; set; }
        [Required(ErrorMessage = "Enter your emergency contact")]
        public string EmergencyContact { get; set; }
        [Required(ErrorMessage = "Enter your emergency contact number")]
        public int EmergencyContactNum { get; set; }
    }
}
