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
    public class PlcController: ControllerBase
    {
        ApplicationDbContext _Context;
        public PlcController(ApplicationDbContext databasecontext)
        {
            _Context = databasecontext;
        }

        public List<PlcTb> plcTbsList { get; set; }
        public void OnGet()
        {
            var data = (from plcTbsList in _Context.PlcKey
                        select plcTbsList).ToList();

            plcTbsList = data;
        }

        [HttpPost]
        public String Indexhome(IEnumerable<PlcTb> Entry)
        {
            if (Entry == null)
            {
                return "No entry selected";
            }
            else
            {
                return "You selected " + string.Join(", ", Entry.Select(p => p.Register));
            }
        }

        [BindProperty]
        public PlcTb Entry { get; set; }

        //to delete
        public ActionResult OnGetDelete(int id)
        {
            if (id != null)
            {
                var data = (from Entry in _Context.PlcKey
                            where Entry.Id ==id
                            select Entry).SingleOrDefault();
                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("insertpagehere");
        }

        public ActionResult OnPost()
        {
            var entry = Entry;
            if(!ModelState.IsValid)
            {
                return RedirectToPage("insertpagehere"); 
            }
            entry.Id = 0;
            var result = _Context.Add(entry);
            _Context.SaveChanges(); //Saves entries

            return RedirectToPage("insertpagehere");
        }
    }
}
