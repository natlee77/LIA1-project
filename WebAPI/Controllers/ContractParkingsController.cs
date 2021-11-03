using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;
using SharedLibrary.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractParkingsController : ControllerBase
    {
        private readonly LIADbContext _context;

        public ContractParkingsController(LIADbContext context)
        {
            _context = context;
        }

        // GET: api/ContractParkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractParking>>> GetContractParkings()
        {
            return await _context.ContractParkings
                .Include(u => u.UserNavigation)                
                .Include(e => e.ParkingCategoryNavigation)
                .ThenInclude(e => e.ParkingLotsNavigation)
                .ToListAsync();
        }
        
             
               
               
       
        // GET: api/ContractParkings/User/5
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<ContractParking>>> GetContractParkings(int userId)
        {
            return await _context.ContractParkings
                .Where(x => x.UserId == userId)
                .Include(u => u.UserNavigation)
                .Include(e => e.ParkingCategoryNavigation)
                .ThenInclude(e => e.ParkingLotsNavigation)               
                .ToListAsync();
        }

        // GET: api/ContractParkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractParking>> GetContractParking(int id)
        {
            var contractParking = await _context.ContractParkings
                .Include(u => u.UserNavigation)
                .Include(e => e.ParkingCategoryNavigation)
                .ThenInclude(e => e.ParkingLotsNavigation)
                .FirstOrDefaultAsync(e => e.Id == id); 
                 

            if (contractParking == null)
            {
                return NotFound();
            }

            return contractParking;
        }

        // PUT: api/ContractParkings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractParking(int id, ContractParking contractParking)
        {
            if (id != contractParking.Id)
            {
                return BadRequest();
            }

            _context.Entry(contractParking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractParkingExists(id))
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

        // POST: api/ContractParkings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContractParking>> PostContractParking(ContractParking contractParking)
        {
            _context.ContractParkings.Add(contractParking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContractParking", new { id = contractParking.Id }, contractParking);
        }
        
        // DELETE: api/ContractParkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractParking(int id)
        {
            var contractParking = await _context.ContractParkings.FindAsync(id);
            if (contractParking == null)
            {
                return NotFound();
            }

            _context.ContractParkings.Remove(contractParking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContractParkingExists(int id)
        {
            return _context.ContractParkings.Any(e => e.Id == id);
        }
    }
}
