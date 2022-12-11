using GymModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymRepository
{
    public class RealDB: IGymRepo
    {
        GymContext _context;
        public RealDB()
        {
            _context = new GymContext();
        }

        /*********************** Fitness Instructor ***********************/
        public void AddInstructor(FitnessInstructor fitinstr)
        {
            _context.FitnessInstructor.Add(fitinstr);
            _context.SaveChanges();
        }

        public IEnumerable<FitnessInstructor> GetInstructors()
        {
            return _context.FitnessInstructor.ToList();
        }

        public FitnessInstructor GetInstructorbyId(int id)
        {
            return _context.FitnessInstructor.FirstOrDefault(x => x.InstrId == id);
        }

        public FitnessInstructor GetInstructorsbyName(string instrname)
        {
            return _context.FitnessInstructor.FirstOrDefault(x => x.InstrName.ToUpper() == instrname.ToUpper());
        }

        /*********************** Fitness Studio ***********************/
        public void AddStudio(FitnessStudio fitstudio)
        {
            _context.FitnessStudio.Add(fitstudio);
            _context.SaveChanges();
        }

        public IEnumerable<FitnessStudio> GetStudios()
        {
            return _context.FitnessStudio;
        }

        public FitnessStudio GetStudiobyId(int id)
        {
            return _context.FitnessStudio.FirstOrDefault(x => x.StudioId == id);
        }

        public FitnessStudio GetStudiobyName(string name)
        {
            return _context.FitnessStudio.FirstOrDefault(x => x.StudioName.ToUpper() == name.ToUpper());
        }

        /*********************** Fitness Classes ***********************/
        public void AddFitClass(FitnessClassSchedule fitclass)
        {
            _context.FitnessClassSchedule.Add(fitclass);
            _context.SaveChanges();
        }

        public void EditFitClass(int id, FitnessClassSchedule fitclass)
        {
            var found = _context.FitnessClassSchedule.FirstOrDefault(x => x.ClassId == id);
            if (found != null)
            {
                found.ClassName = fitclass.ClassName;
                found.ClassStudioId = fitclass.ClassStudioId;
                found.ClassInstrId = fitclass.ClassInstrId;
                found.ClassDuration = fitclass.ClassDuration;
                found.ClassStartTime = fitclass.ClassStartTime;
                found.ClassWeekDay = fitclass.ClassWeekDay;
                _context.SaveChanges();
            }
        }

        public void DeleteFitClass(int id)
        {
            var found = _context.FitnessClassSchedule.FirstOrDefault(x => x.ClassId == id);
            if (found != null)
            {
                _context.FitnessClassSchedule.Remove(found);
                _context.SaveChanges();
            }
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassSchedules()
        {
            return _context.FitnessClassSchedule
                .OrderBy(x => x.ClassWeekDay)
                .ThenBy(x => x.ClassStartTime)
                .ToList();
        }

        public FitnessClassSchedule GetFitClassSchedulesbyId(int id)
        {
            var found = _context.FitnessClassSchedule.FirstOrDefault(x => x.ClassId == id);
            return found;
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByDay(DayOfWeek day)
        {
            return _context.FitnessClassSchedule.Where(x => x.ClassWeekDay == day).OrderBy(x => x.ClassStartTime).ToList();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByInstrId(int instrid)
        {
            return _context.FitnessClassSchedule.Where(x => x.ClassInstrId == instrid)
                .OrderBy(x => x.ClassWeekDay)
                .OrderBy(x => x.ClassStartTime)
                .ToList();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByStudio(int studid)
        {
            return _context.FitnessClassSchedule.Where(x => x.ClassStudioId == studid)
                .OrderBy(x => x.ClassWeekDay)
                .OrderBy(x => x.ClassStartTime)
                .ToList();
        }
    }
}
