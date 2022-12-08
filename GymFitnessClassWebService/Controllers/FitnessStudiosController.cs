using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymModels;
using GymRepository;

namespace GymFitnessClassWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessStudiosController : ControllerBase
    {
        /*private readonly GymContext _context;

        public FitnessStudiosController(GymContext context)
        {
            _context = context;
        }*/

        // use repository with dependency injection
        IGymRepo _context;
        public FitnessStudiosController(IGymRepo repo)
        {
            _context = repo;
        }

        // GET: api/FitnessStudios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessStudio>>> GetFitnessStudio()
        {
            return _context.GetStudios().ToList();
        }

        /*// GET: api/FitnessStudios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessStudio>> GetFitnessStudio(int id)
        {
            var fitnessStudio = await _context.FitnessStudio.FindAsync(id);

            if (fitnessStudio == null)
            {
                return NotFound();
            }

            return fitnessStudio;
        }

        // PUT: api/FitnessStudios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessStudio(int id, FitnessStudio fitnessStudio)
        {
            if (id != fitnessStudio.StudioId)
            {
                return BadRequest();
            }

            _context.Entry(fitnessStudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessStudioExists(id))
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

        // POST: api/FitnessStudios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessStudio>> PostFitnessStudio(FitnessStudio fitnessStudio)
        {
            _context.FitnessStudio.Add(fitnessStudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFitnessStudio", new { id = fitnessStudio.StudioId }, fitnessStudio);
        }

        // DELETE: api/FitnessStudios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessStudio(int id)
        {
            var fitnessStudio = await _context.FitnessStudio.FindAsync(id);
            if (fitnessStudio == null)
            {
                return NotFound();
            }

            _context.FitnessStudio.Remove(fitnessStudio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FitnessStudioExists(int id)
        {
            return _context.FitnessStudio.Any(e => e.StudioId == id);
        }*/
    }
}
