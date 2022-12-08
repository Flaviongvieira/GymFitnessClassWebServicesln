using GymModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymRepository
{
    public class RealDB: IGymRepo
    {


        /*********************** Fitness Instructor ***********************/
        public void AddInstructor(FitnessInstructor fitinstr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessInstructor> GetInstructors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessInstructor> GetAllInstructorsbyName(string instrname)
        {
            throw new NotImplementedException();
        }

        public FitnessInstructor GetInstructorbyId(int id)
        {
            throw new NotImplementedException();
        }

        /*********************** Fitness Studio ***********************/
        public void AddStudio(FitnessStudio fitstudio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessStudio> GetStudios()
        {
            throw new NotImplementedException();
        }

        public FitnessStudio GetStudiobyId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessStudio> GetStudiosbyName(string sutdname)
        {
            throw new NotImplementedException();
        }

        /*********************** Fitness Classes ***********************/
        public void AddFitClass(FitnessClassSchedule fitclass)
        {
            throw new NotImplementedException();
        }

        public void EditFitClass(int id, FitnessClassSchedule fitclass)
        {
            throw new NotImplementedException();
        }

        public void DeleteFitClass(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassSchedules()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByDay(DayOfWeek day)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByInstrId(int instrid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByStudio(string studname)
        {
            throw new NotImplementedException();
        }
    }
}
