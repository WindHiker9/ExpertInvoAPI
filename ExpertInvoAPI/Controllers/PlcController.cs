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
    [Route("api/plcController")]
    [ApiController]
    public class PlcController: ControllerBase
    {
        ApplicationDbContext _Context;
        public PlcController(ApplicationDbContext databasecontext)
        {
            _Context = databasecontext; //abstracts dbcontext into _context
        }

        public List<PlcTb> PlcList { get; set; }
        public void OnGet()
        {
            var data = (from plclist in _Context.PlcKey
                        select plclist).ToList(); //specifies what to grab

            PlcList = data; //grabs data
        }

        [HttpGet]
        [Route("api/plcController/get")]
        public String Indexhome(IEnumerable<PlcTb> Entry)
        {
            if (Entry == null)
            {
                return "No entry selected";
            }
            else
            {
                return "You selected " + string.Join(", ", Entry.Select(p => p.IP_Address));
            }
        }

        [BindProperty]
        public PlcTb Entry { get; set; }

        //to delete
        [HttpDelete]
        [Route("api/plcController/delete")]
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null) //always evaluates to true in warnings?? //fixed with ? before id two lines above
            {
                var data = (from entry in _Context.PlcKey
                            where entry.Id ==id
                            select entry).SingleOrDefault();
                _Context.Remove(data); //deletes from db
                _Context.SaveChanges(); //saves changes to db
            }
            return RedirectToPage("insertpagehere"); //no page to redirect to at the moment
        }
        [HttpPost]
        [Route("api/plcController/post")] //added route
        public ActionResult OnPost()
        {
            var entry = Entry;
            if(!ModelState.IsValid) //checks model state
            {
                return RedirectToPage("insertpagehere");  //no page to redirect to at the moment
            }
            entry.Id = 0;
            var result = _Context.Add(entry);
            _Context.SaveChanges(); //Saves entries

            return RedirectToPage("insertpagehere"); //no page to redirect to at the moment
        }
    }
}
