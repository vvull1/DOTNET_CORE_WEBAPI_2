using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOTNET_CORE_WEBAPI_2.Models;

namespace DOTNET_CORE_WEBAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTablesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeTablesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTable>>> GetEmployeeTables()
        {
            return await _context.EmployeeTables.ToListAsync();
        }

        [Route("GetAllUsers")] //Here it gives all usermaster details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMaster>>> GetUserMasters()  //This is the custom method
        {
            return await _context.UserMasters.ToListAsync();
        }

        // GET: api/EmployeeTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTable>> GetEmployeeTable(int id)
        {
            var employeeTable = await _context.EmployeeTables.FindAsync(id);

            if (employeeTable == null)
            {
                return NotFound();
            }

            return employeeTable;
        }

        // PUT: api/EmployeeTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeTable(int id, EmployeeTable employeeTable)
        {
            if (id != employeeTable.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTableExists(id))
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

        // POST: api/EmployeeTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeTable>> PostEmployeeTable(EmployeeTable employeeTable)
        {
            _context.EmployeeTables.Add(employeeTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeTable", new { id = employeeTable.EmployeeId }, employeeTable);
        }

        // DELETE: api/EmployeeTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeTable(int id)
        {
            var employeeTable = await _context.EmployeeTables.FindAsync(id);
            if (employeeTable == null)
            {
                return NotFound();
            }

            _context.EmployeeTables.Remove(employeeTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeTableExists(int id)
        {
            return _context.EmployeeTables.Any(e => e.EmployeeId == id);
        }
    }
}
