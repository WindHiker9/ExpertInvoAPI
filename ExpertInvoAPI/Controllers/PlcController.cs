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
                        select plcTbsList).toList();

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
    }
}
