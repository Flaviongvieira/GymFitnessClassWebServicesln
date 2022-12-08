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
    public class FitnessClassSchedulesController : ControllerBase
    {
        private readonly GymContext _context;

        public FitnessClassSchedulesController(GymContext context)
        {
            _context = context;
        }

        // GET: api/FitnessClassSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessClassSchedule>>> GetFitnessClassSchedule()
        {
            return await _context.FitnessClassSchedule.ToListAsync();
        }

        // GET: api/FitnessClassSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessClassSchedule>> GetFitnessClassSchedule(int id)
        {
            var fitnessClassSchedule = await _context.FitnessClassSchedule.FindAsync(id);

            if (fitnessClassSchedule == null)
            {
                return NotFound();
            }

            return fitnessClassSchedule;
        }

        // PUT: api/FitnessClassSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessClassSchedule(int id, FitnessClassSchedule fitnessClassSchedule)
        {
            if (id != fitnessClassSchedule.ClassId)
            {
                return BadRequest();
            }

            _context.Entry(fitnessClassSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessClassScheduleExists(id))
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

        // POST: api/FitnessClassSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessClassSchedule>> PostFitnessClassSchedule(FitnessClassSchedule fitnessClassSchedule)
        {
            _context.FitnessClassSchedule.Add(fitnessClassSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFitnessClassSchedule", new { id = fitnessClassSchedule.ClassId }, fitnessClassSchedule);
        }

        // DELETE: api/FitnessClassSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessClassSchedule(int id)
        {
            var fitnessClassSchedule = await _context.FitnessClassSchedule.FindAsync(id);
            if (fitnessClassSchedule == null)
            {
                return NotFound();
            }

            _context.FitnessClassSchedule.Remove(fitnessClassSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FitnessClassScheduleExists(int id)
        {
            return _context.FitnessClassSchedule.Any(e => e.ClassId == id);
        }
    }
}
