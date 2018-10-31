using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpertInvoAPI.Data;
using ExpertInvoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpertInvoAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/plcController")]
    [ApiController]
    public class PlcController : ControllerBase
    {
        ApplicationDbContext _Context;
        public PlcController(ApplicationDbContext databasecontext)
        {
            _Context = databasecontext; //abstracts dbcontext into _context
        }

        [HttpGet]
        [Route("api/plcController")]
        public IEnumerable<PlcModel> GetEntries()
        {
            return _Context.PlcTb;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entry = await _Context.PlcTb.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry([FromRoute] int id, [FromBody] PlcModel entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != entry.Id)
            {
                return BadRequest();
            }
            _Context.Entry(entry).State = EntityState.Modified;
            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool EntryExists(int id)
        {
            return _Context.PlcTb.Any(e => e.Id == id);
        }

        [BindProperty]
        public PlcModel Entry { get; set; }

        //to delete /api/Plc/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _Context.PlcTb.SingleOrDefaultAsync(m => m.Id == id);
            if (Entry == null)
            {
                return NotFound();
            }
            _Context.Remove(data); //deletes from db
            await _Context.SaveChangesAsync(); //saves changes to db

            return Ok(Entry); //no page to redirect to at the moment
        }

        [HttpPost]
        [Route("api/plcController/post")] //added route
        public IActionResult PostEntry([FromBody] PlcModel entry)
        //old version which tries to sync
        //public async Task<IActionResult> PostEntry([FromBody] PlcModel entry) 

        {
            if (!ModelState.IsValid) //checks model state
            {
                return BadRequest(ModelState);  //no page to redirect to at the moment
            }
            _Context.PlcTb.Add(entry);
            var result = _Context.Add(entry);
            _Context.SaveChanges(); //Saves entries

            return RedirectToPage("insertpagehere"); //no page to redirect to at the moment
        }
    }
}