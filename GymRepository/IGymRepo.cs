using GymModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymRepository
{
    public interface IGymRepo
    {
        /*********************** Fitness Instructor ***********************/
        // create new instructor
        public void AddInstructor(FitnessInstructor fitinstr);

        // get list of all instructors
        public IEnumerable<FitnessInstructor> GetInstructors();

        // get instructor by name
        public IEnumerable<FitnessInstructor> GetAllInstructorsbyName(string instrname);

        // get instructor by id
        public FitnessInstructor GetInstructorbyId(int id);

        /*********************** Fitness Studio ***********************/
        // create new studio
        public void AddStudio(FitnessStudio fitstudio);

        // get list of all sutdios
        public IEnumerable<FitnessStudio> GetStudios();

        // get studio by name
        public IEnumerable<FitnessStudio> GetStudiosbyName(string sutdname);

        // get studio by id
        public FitnessStudio GetStudiobyId(int id);

        /*********************** Fitness Classes ***********************/
        // create Fitness Class
        public void AddFitClass(FitnessClassSchedule fitclass);

        // editing existing class
        public void EditFitClass(int id, FitnessClassSchedule fitclass);

        // delete existing class
        public void DeleteFitClass(int id);

        // get all classes order by weekday, starttime
        public IEnumerable<FitnessClassSchedule> GetFitClassSchedules();

        // get fitness classes for a specific day
        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByDay(DayOfWeek day);

        // get fitness classes for a specific fitness instructor (id)
        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByInstrId(int instrid);

        // get fitness classes for a specific studio (id)
        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByStudio(string studname);

    }
}
