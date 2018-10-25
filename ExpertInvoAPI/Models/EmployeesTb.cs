using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Since this page is for a table, this page is probs not necessary for just an API
namespace ExpertInvoAPI.Models
{
    [Table("tblEmployees")]
    public class EmployeesTb
    {
        public int ID { get; set; }
        [Required (ErrorMessage = "First Name is not found!!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is not found!!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is not found!!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Age is not found!!")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Birth Date is not found!!")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Personal Email is not found!!")]
        public string PersonalEmail { get; set; }
        [Required(ErrorMessage = "Primary Phone is not found!!")]
        public int PrimaryPhone { get; set; }
        [Required(ErrorMessage = "Secondary Phone is not found!!")]
        public int SecondaryPhone { get; set; }
        [Required(ErrorMessage = "Emergency Contact is not found!!")]
        public string EmergencyContact { get; set; }
        [Required(ErrorMessage = "Emergency Contact Number is not found!!")]
        public int EmergencyContactNumber { get; set; }
    }
}
