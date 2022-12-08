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
    public class FitnessInstructorsController : ControllerBase
    {
        // use repository with dependency injection
        IGymRepo _context;
        public FitnessInstructorsController(IGymRepo repo)
        {
            _context = repo;
        }

        // GET: api/FitnessInstructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessInstructor>>> GetFitnessInstructor()
        {
            return _context.GetInstructors().ToList();
        }

        // GET: api/FitnessInstructors/5
        [HttpGet("GetFitnessInstructorbyId/{id}")]
        public async Task<ActionResult<FitnessInstructor>> GetFitnessInstructorbyId(int id)
        {
            var fitnessInstructor = _context.GetInstructorbyId(id);

            if (fitnessInstructor == null)
            {
                return NotFound();
            }

            return fitnessInstructor;
        }

        // GET: api/FitnessInstructors/5
        [HttpGet("GetFitnessInstructorbyName/{name}")]
        public async Task<ActionResult<FitnessInstructor>> GetFitnessInstructorbyName(string name)
        {
            var fitnessInstructor = _context.GetInstructorsbyName(name);

            if (fitnessInstructor == null)
            {
                return NotFound();
            }

            return fitnessInstructor;
        }

        // POST: api/FitnessInstructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessInstructor>> PostFitnessInstructor(FitnessInstructor fitnessInstructor)
        {
            _context.AddInstructor(fitnessInstructor);
            return CreatedAtAction("GetFitnessInstructor", new { id = fitnessInstructor.InstrId }, fitnessInstructor);
        }
    }
}
