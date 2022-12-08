using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymFitnessClassWebService.Data;
using GymModels;

namespace GymFitnessClassWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessInstructorsController : ControllerBase
    {
        private readonly GymContext _context;

        public FitnessInstructorsController(GymContext context)
        {
            _context = context;
        }

        // GET: api/FitnessInstructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessInstructor>>> GetFitnessInstructor()
        {
            return await _context.FitnessInstructor.ToListAsync();
        }

        // GET: api/FitnessInstructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessInstructor>> GetFitnessInstructor(int id)
        {
            var fitnessInstructor = await _context.FitnessInstructor.FindAsync(id);

            if (fitnessInstructor == null)
            {
                return NotFound();
            }

            return fitnessInstructor;
        }

        // PUT: api/FitnessInstructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessInstructor(int id, FitnessInstructor fitnessInstructor)
        {
            if (id != fitnessInstructor.InstrId)
            {
                return BadRequest();
            }

            _context.Entry(fitnessInstructor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessInstructorExists(id))
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

        // POST: api/FitnessInstructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessInstructor>> PostFitnessInstructor(FitnessInstructor fitnessInstructor)
        {
            _context.FitnessInstructor.Add(fitnessInstructor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFitnessInstructor", new { id = fitnessInstructor.InstrId }, fitnessInstructor);
        }

        // DELETE: api/FitnessInstructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessInstructor(int id)
        {
            var fitnessInstructor = await _context.FitnessInstructor.FindAsync(id);
            if (fitnessInstructor == null)
            {
                return NotFound();
            }

            _context.FitnessInstructor.Remove(fitnessInstructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FitnessInstructorExists(int id)
        {
            return _context.FitnessInstructor.Any(e => e.InstrId == id);
        }
    }
}
