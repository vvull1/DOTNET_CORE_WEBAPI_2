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
    public class EducationalDetailsTablesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EducationalDetailsTablesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/EducationalDetailsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationalDetailsTable>>> GetEducationalDetailsTables()
        {
            return await _context.EducationalDetailsTables.ToListAsync();
        }

        // GET: api/EducationalDetailsTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationalDetailsTable>> GetEducationalDetailsTable(int id)
        {
            var educationalDetailsTable = await _context.EducationalDetailsTables.FindAsync(id);

            if (educationalDetailsTable == null)
            {
                return NotFound();
            }

            return educationalDetailsTable;
        }

        // PUT: api/EducationalDetailsTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationalDetailsTable(int id, EducationalDetailsTable educationalDetailsTable)
        {
            if (id != educationalDetailsTable.EducationalDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(educationalDetailsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationalDetailsTableExists(id))
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

        // POST: api/EducationalDetailsTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducationalDetailsTable>> PostEducationalDetailsTable(EducationalDetailsTable educationalDetailsTable)
        {
            _context.EducationalDetailsTables.Add(educationalDetailsTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationalDetailsTable", new { id = educationalDetailsTable.EducationalDetailsId }, educationalDetailsTable);
        }

        // DELETE: api/EducationalDetailsTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationalDetailsTable(int id)
        {
            var educationalDetailsTable = await _context.EducationalDetailsTables.FindAsync(id);
            if (educationalDetailsTable == null)
            {
                return NotFound();
            }

            _context.EducationalDetailsTables.Remove(educationalDetailsTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationalDetailsTableExists(int id)
        {
            return _context.EducationalDetailsTables.Any(e => e.EducationalDetailsId == id);
        }
    }
}
