using GymModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymRepository
{
    public class MockDB : IGymRepo
    {
        private static List<FitnessClassSchedule> ClassSchedule = new List<FitnessClassSchedule>()
        {
            new FitnessClassSchedule{ClassId = 1, ClassName="Pilates", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 45,
                ClassStartTime = new TimeOnly(7,45), ClassInstrId = 1, ClassStudioId = 1},
            new FitnessClassSchedule{ClassId = 2, ClassName="Gravity", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 60,
                ClassStartTime = new TimeOnly(8,45), ClassInstrId = 2, ClassStudioId = 2},
            new FitnessClassSchedule{ClassId = 1, ClassName="RPM", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 30,
                ClassStartTime = new TimeOnly(9), ClassInstrId = 1, ClassStudioId = 1},
            new FitnessClassSchedule{ClassId = 1, ClassName="PUMP", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 45,
                ClassStartTime = new TimeOnly(7,45), ClassInstrId = 2, ClassStudioId = 2},
            new FitnessClassSchedule{ClassId = 1, ClassName="Pilates", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 55,
                ClassStartTime = new TimeOnly(13,25), ClassInstrId = 1, ClassStudioId = 1},
            new FitnessClassSchedule{ClassId = 1, ClassName="Aqua Fit", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 45,
                ClassStartTime = new TimeOnly(17,45), ClassInstrId = 2, ClassStudioId = 2}
        };

        private static List<FitnessInstructor> FitInstructors = new List<FitnessInstructor>()
        {
            new FitnessInstructor{ InstrId = 1, InstrName = "Margarida", InstrDoB = new DateOnly(1990,7,11)},
            new FitnessInstructor{ InstrId = 2, InstrName = "Flavio", InstrDoB = new DateOnly(1989,7,22)},
        };

        private static List<FitnessStudio> FitStudio = new List<FitnessStudio>()
        {
            new FitnessStudio{ StudioId = 1, StudioName= "Main Studio"},
            new FitnessStudio{ StudioId = 2, StudioName= "Secondary Studio"}
        };


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
