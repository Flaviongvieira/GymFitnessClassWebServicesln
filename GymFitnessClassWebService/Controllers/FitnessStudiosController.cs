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

        // GET: api/FitnessStudios/5
        [HttpGet("GetFitnessStudiobyId/{id}")]
        public async Task<ActionResult<FitnessStudio>> GetFitnessStudiobyId(int id)
        {
            var fitnessStudio = _context.GetStudiobyId(id);

            if (fitnessStudio == null)
            {
                return NotFound();
            }

            return fitnessStudio;
        }

        // GET: api/FitnessStudios/5
        [HttpGet("GetStudiobyName/{name}")]
        public async Task<ActionResult<FitnessStudio>> GetStudiobyName(string name)
        {
            var fitnessStudio = _context.GetStudiobyName(name);

            if (fitnessStudio == null)
            {
                return NotFound();
            }

            return fitnessStudio;
        }

        // POST: api/FitnessStudios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessStudio>> PostFitnessStudio(FitnessStudio fitnessStudio)
        {
            _context.AddStudio(fitnessStudio);
            return CreatedAtAction("GetFitnessStudio", new { id = fitnessStudio.StudioId }, fitnessStudio);
        }
    }
}
