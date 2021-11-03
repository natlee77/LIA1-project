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
    public class ParkingCategoriesController : ControllerBase
    {
        private readonly LIADbContext _context;

        public ParkingCategoriesController(LIADbContext context)
        {
            _context = context;
        }

        // GET: api/ParkingCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingCategory>>> GetParkingCategories()
        {
            return await _context.ParkingCategories
                .Include(e=>e.ParkingLotsNavigation)
                .ToListAsync();
        }

        // GET: api/ParkingCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingCategory>> GetParkingCategory(int id)
         {
            var parkingCategory = await _context.ParkingCategories
                .Include(e => e.ParkingLotsNavigation)
                .FirstOrDefaultAsync(e => e.Id == id);
            //.FindAsync(id);


            if (parkingCategory == null)
            {
                return NotFound();
            }     
                 return parkingCategory;

           
        }
        [HttpGet("GetByString")]      //funkar i Swager

        public async Task<IEnumerable<ParkingCategory>> GetParkingCategoryByTyp(string parkingType)
        {
            return  _context.ParkingCategories
                .Where(x => x.ParkingCategory1 == parkingType)  
                .Include(e => e.ParkingLotsNavigation)
                .AsEnumerable();
        }
        [HttpGet("GetByCity")]
        public async Task<IEnumerable<ParkingCategory>> GetParkingCategoryByCity(string cityType)
        {
            return _context.ParkingCategories
                .Where(x => x.ParkingLotsNavigation.City == cityType)
                .Include(e => e.ParkingLotsNavigation)
                .AsEnumerable();
        }



        // PUT: api/ParkingCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingCategory(int id, ParkingCategory parkingCategory)
        {
            if (id != parkingCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(parkingCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingCategoryExists(id))
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

        // POST: api/ParkingCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParkingCategory>> PostParkingCategory(ParkingCategory parkingCategory)
        {
            _context.ParkingCategories.Add(parkingCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingCategory", new { id = parkingCategory.Id }, parkingCategory);
        }

        // DELETE: api/ParkingCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingCategory(int id)
        {
            var parkingCategory = await _context.ParkingCategories.FindAsync(id);
            if (parkingCategory == null)
            {
                return NotFound();
            }

            _context.ParkingCategories.Remove(parkingCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingCategoryExists(int id)
        {
            return _context.ParkingCategories.Any(e => e.Id == id);
        }
    }
}
