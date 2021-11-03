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
    public class ContractApartmentsController : ControllerBase
    {
        private readonly LIADbContext _context;

        public ContractApartmentsController(LIADbContext context)
        {
            _context = context;
        }

        // GET: api/ContractApartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractApartment>>> GetContractApartments()
        {
            return await _context.ContractApartments.ToListAsync();
        }

        // GET: api/ContractApartments/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<ContractApartment>>> GetContractApartments(int userId)
        {
            return await _context.ContractApartments.Where(x => x.UserId == userId).ToListAsync();
        }

        // GET: api/ContractApartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractApartment>> GetContractApartment(int id)
        {
            var contractApartment = await _context.ContractApartments.FindAsync(id);

            if (contractApartment == null)
            {
                return NotFound();
            }

            return contractApartment;
        }

        // PUT: api/ContractApartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractApartment(int id, ContractApartment contractApartment)
        {
            if (id != contractApartment.Id)
            {
                return BadRequest();
            }

            _context.Entry(contractApartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractApartmentExists(id))
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

        // POST: api/ContractApartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContractApartment>> PostContractApartment(ContractApartment contractApartment)
        {
            _context.ContractApartments.Add(contractApartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContractApartment", new { id = contractApartment.Id }, contractApartment);
        }

        // DELETE: api/ContractApartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractApartment(int id)
        {
            var contractApartment = await _context.ContractApartments.FindAsync(id);
            if (contractApartment == null)
            {
                return NotFound();
            }

            _context.ContractApartments.Remove(contractApartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContractApartmentExists(int id)
        {
            return _context.ContractApartments.Any(e => e.Id == id);
        }
    }
}
