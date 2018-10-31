using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpertInvoAPI.Data;
using ExpertInvoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ExpertInvoAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext databasecontext)
        {
            _context = databasecontext;
        }

        // GET: api/Employee
        [HttpGet]
        [Route("api/Employee")]
        public IEnumerable<EmployeeTb> GetEmployees()
        {
                return _context.EmployeeModel;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = await _context.EmployeeModel.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] EmployeeModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        private bool EmployeeExists(int id)
        {
            return _context.EmployeeModel.Any(e => e.EmployeeID == id);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = await _context.EmployeeModel.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.EmployeeModel.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeTb employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.EmployeeModel.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeID }, employee);
        }
    }
}
