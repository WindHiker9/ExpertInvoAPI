using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpertInvoAPI.Data;
using ExpertInvoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpertInvoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDbContext _Context;
        public EmployeesController(ApplicationDbContext databasecontext)
        {
            _Context = databasecontext;
        }

        public List<EmployeesTb> RRSandboxList { get; set; }

        public void OnGet()
        {
            var data = (from rrsandboxlist in _Context.EmployeesKey
                        select rrsandboxlist).ToList();

            RRSandboxList = data;
        }

        [HttpPost]
        public String Indexhome(IEnumerable<EmployeesTb> Employee)
        {
            if (Employee == null)
            {
                return "You didn't select an entry";
            }
            else
            {
                return "You selected " + string.Join(", ", Employee.Select(s => s.FirstName));
            }
        }

        [BindProperty]
        public EmployeesTb Employee { get; set; }

        //To delete
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from employee in _Context.EmployeesKey
                            where employee.ID == id
                            select employee).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("AdminView");
        }

        public ActionResult OnPost()
        {
            //RRSandbox.TimeSubmitted = DateTimeOffset;
            var employee = Employee;
            if (!ModelState.IsValid)
            {
                return Acti; // return page

            }

            employee.ID = 0;
            var result = _Context.Add(employee);
            _Context.SaveChanges(); // Saving Data in database 

            return RedirectToPage("AdminView");
        }
    }
}
