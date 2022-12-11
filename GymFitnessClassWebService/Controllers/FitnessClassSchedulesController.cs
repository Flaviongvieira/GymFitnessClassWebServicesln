using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymModels;
using GymRepository;
using NuGet.Protocol.Core.Types;

namespace GymFitnessClassWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessClassSchedulesController : ControllerBase
    {
        // use repository with dependency injection
        IGymRepo _context;
        public FitnessClassSchedulesController(IGymRepo repo)
        { 
            _context = repo; 
        }


        // GET: api/FitnessClassSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessClassSchedule>>> GetFitnessClassSchedule()
        {
            return  _context.GetFitClassSchedules().ToList();
        }

        // GET: api/FitnessClassSchedules/5
        [HttpGet("GetFitnessClassbyId/{id}")]
        public async Task<ActionResult<FitnessClassSchedule>> GetFitnessClassbyId(int id)
        {
            var fitnessClass = _context.GetFitClassSchedulesbyId(id);

            if (fitnessClass == null)
            {
                return NotFound();
            }

            return fitnessClass;
        }

        // GET: api/FitnessClassSchedules/Monday
        [HttpGet("GetFitClassScheduleByDay/{day}")]
        public async Task<ActionResult<FitnessClassSchedule>> GetFitClassScheduleByDay(DayOfWeek day)
        {
            var fitnessClassSchedule = _context.GetFitClassScheduleByDay(day);

            if (fitnessClassSchedule == null)
            {
                return NotFound();
            }

            return Ok(fitnessClassSchedule);
        }

        // GET: api/FitnessClassSchedules/2
        [HttpGet("GetFitClassScheduleByInstr/{instrId}")]
        public async Task<ActionResult<FitnessClassSchedule>> GetFitClassScheduleByInstr(int instrId)
        {
            var fitnessClassSchedule = _context.GetFitClassScheduleByInstrId(instrId);

            if (fitnessClassSchedule == null)
            {
                return NotFound();
            }

            return Ok(fitnessClassSchedule);
        }

        // GET: api/FitnessClassSchedules/2
        [HttpGet("GetFitClassScheduleByStuId/{studId}")]
        public async Task<ActionResult<FitnessClassSchedule>> GetFitClassScheduleByStuId(int studId)
        {
            var fitnessClassSchedule = _context.GetFitClassScheduleByStudio(studId);

            if (fitnessClassSchedule == null)
            {
                return NotFound();
            }

            return Ok(fitnessClassSchedule);
        }

        // PUT: api/FitnessClassSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessClassSchedule(int id, FitnessClassSchedule fitnessClassSchedule)
        {
            FitnessClassSchedule found = _context.GetFitClassSchedulesbyId(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                _context.EditFitClass(id, fitnessClassSchedule);
                return NoContent();
            }
        }

        // POST: api/FitnessClassSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessClassSchedule>> PostFitnessClassSchedule(FitnessClassSchedule fitnessClassSchedule)
        {
            _context.AddFitClass(fitnessClassSchedule);
            return CreatedAtAction("GetFitnessClassSchedule", new { id = fitnessClassSchedule.ClassId }, fitnessClassSchedule);
        }

        // DELETE: api/FitnessClassSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessClassSchedule(int id)
        {
            FitnessClassSchedule found = _context.GetFitClassSchedulesbyId(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                _context.DeleteFitClass(id);
                return NoContent();
            }
        }
    }
}
