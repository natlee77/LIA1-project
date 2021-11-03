using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartmentMaintancesController : ControllerBase
    {
        private readonly LIADbContext _context;

        public AppartmentMaintancesController(LIADbContext context)
        {
            _context = context;
        }

        // GET: api/AppartmentMaintances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppartmentMaintance>>> GetAppartmentMaintances()
        {
            return await _context.AppartmentMaintances.ToListAsync();
        }

        // GET: api/AppartmentMaintances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppartmentMaintance>> GetAppartmentMaintance(int id)
        {
            var appartmentMaintance = await _context.AppartmentMaintances.FindAsync(id);

            if (appartmentMaintance == null)
            {
                return NotFound();
            }

            return appartmentMaintance;
        }

        // PUT: api/AppartmentMaintances/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppartmentMaintance(int id, AppartmentMaintance appartmentMaintance)
        {
            if (id != appartmentMaintance.Id)
            {
                return BadRequest();
            }

            _context.Entry(appartmentMaintance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppartmentMaintanceExists(id))
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

        // POST: api/AppartmentMaintances       
        [HttpPost]
        public async Task<ActionResult<AppartmentMaintance>> PostAppartmentMaintance(AppartmentMaintance appartmentMaintance)
        {
            _context.AppartmentMaintances.Add(appartmentMaintance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppartmentMaintance", new { id = appartmentMaintance.Id }, appartmentMaintance);
        }

        // DELETE: api/AppartmentMaintances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppartmentMaintance(int id)
        {
            var appartmentMaintance = await _context.AppartmentMaintances.FindAsync(id);
            if (appartmentMaintance == null)
            {
                return NotFound();
            }

            _context.AppartmentMaintances.Remove(appartmentMaintance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppartmentMaintanceExists(int id)
        {
            return _context.AppartmentMaintances.Any(e => e.Id == id);
        }
    }
}
