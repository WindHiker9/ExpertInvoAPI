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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ApplicationDbContext _Context;
        public EmployeeController(ApplicationDbContext databasecontext)
        {
            _Context = databasecontext;
        }

        public List<EmployeeKey> EmployeeList { get; set; }

        public void OnGet()
        {
            var data = (from employeelist in _Context.EmployeeKey
                        select employeelist).ToList();

            EmployeeList = data;
        }

        [HttpGet]
        [Route("api/employeeController/get")]
        public String Indexhome(IEnumerable<EmployeeKey> Entry)
        {
            if (Entry == null)
            {
                return "No entry selected";
            }
            else
            {
                return "You selected " + string.Join(", ", Entry.Select(s => s.FirstName));
            }
        }

        [BindProperty]
        public EmployeeKey Entry { get; set; }

        //to delete
        [HttpDelete]
        [Route("api/plcController/delete")]
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from entry in _Context.EmployeeKey
                            where entry.EmployeeID == id
                            select entry).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("insertpagehere"); //no page to redirect to at the moment
        }

        [HttpPost]
        [Route("api/plcController/post")] //added route
        public ActionResult OnPost()
        {
            var entry = Entry;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("insertpagehere");  //no page to redirect to at the moment
            }

            entry.EmployeeID = 0;
            var result = _Context.Add(entry);
            //The following "_Context.Entry(entry)" lines may be capable of updating; testing required
            //_Context.Entry(entry).Property(x => x.FirstName).IsModified = true;
            //_Context.Entry(entry).Property(x => x.LastName).IsModified = true;
            //_Context.Entry(entry).Property(x => x.Address).IsModified = true;
            //_Context.Entry(entry).Property(x => x.Age).IsModified = true;
            //_Context.Entry(entry).Property(x => x.Birthdate).IsModified = true;
            //_Context.Entry(entry).Property(x => x.PersonalEmail).IsModified = true;
            //_Context.Entry(entry).Property(x => x.PrimaryPhone).IsModified = true;
            //_Context.Entry(entry).Property(x => x.SecondaryPhone).IsModified = true;
            //_Context.Entry(entry).Property(x => x.EmergencyContact).IsModified = true;
            //_Context.Entry(entry).Property(x => x.EmergencyContactNumber).IsModified = true;
            _Context.SaveChanges(); // Saving Data in database 

            return RedirectToPage("insertpagehere"); //no page to redirect to at the moment
        }
    }
}
