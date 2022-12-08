using GymModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GymRepository
{
    public class MockDB : IGymRepo
    {
        private static List<FitnessClassSchedule> FitClassSchedule = new List<FitnessClassSchedule>()
        {
            new FitnessClassSchedule{ClassId = 1, ClassName="Pilates", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 45,
                ClassStartTime = "07:45", ClassInstrId = 1, ClassStudioId = 1},
            new FitnessClassSchedule{ClassId = 2, ClassName="Gravity", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 60,
                ClassStartTime = "08:30", ClassInstrId = 2, ClassStudioId = 2},
            new FitnessClassSchedule{ClassId = 3, ClassName="RPM", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 30,
                ClassStartTime = "09:00", ClassInstrId = 1, ClassStudioId = 1},
            new FitnessClassSchedule{ClassId = 4, ClassName="PUMP", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 45,
                ClassStartTime = "20:15", ClassInstrId = 2, ClassStudioId = 2},
            new FitnessClassSchedule{ClassId = 5, ClassName="Pilates", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 55,
                ClassStartTime = "18:00", ClassInstrId = 1, ClassStudioId = 1},
            new FitnessClassSchedule{ClassId = 6, ClassName="Aqua Fit", ClassWeekDay = DayOfWeek.Wednesday, ClassDuration = 45,
                ClassStartTime = "17:45", ClassInstrId = 2, ClassStudioId = 2}
        };

        private static List<FitnessInstructor> FitInstructors = new List<FitnessInstructor>()
        {
            new FitnessInstructor{ InstrId = 1, InstrName = "Margarida", InstrDoB = new DateTime(1990,7,11)},
            new FitnessInstructor{ InstrId = 2, InstrName = "Flavio", InstrDoB = new DateTime(1989,7,22)},
        };

        private static List<FitnessStudio> FitStudio = new List<FitnessStudio>()
        {
            new FitnessStudio{ StudioId = 1, StudioName= "Main Studio"},
            new FitnessStudio{ StudioId = 2, StudioName= "Secondary Studio"}
        };


        /*********************** Fitness Instructor ***********************/
        public void AddInstructor(FitnessInstructor fitinstr)
        {
            FitInstructors.Add(fitinstr);
        }

        public IEnumerable<FitnessInstructor> GetInstructors()
        {
            return FitInstructors;
        }

        public FitnessInstructor GetInstructorbyId(int id)
        {
            return FitInstructors.FirstOrDefault(x => x.InstrId == id);            
        }

        public FitnessInstructor GetInstructorsbyName(string instrname)
        {
            return FitInstructors.FirstOrDefault(x => x.InstrName.ToUpper() == instrname.ToUpper());
        }

        /*********************** Fitness Studio ***********************/
        public void AddStudio(FitnessStudio fitstudio)
        {
            FitStudio.Add(fitstudio);
        }

        public IEnumerable<FitnessStudio> GetStudios()
        {
            return FitStudio;
        }

        public FitnessStudio GetStudiobyId(int id)
        {
            return FitStudio.FirstOrDefault(x => x.StudioId == id);
        }

        public FitnessStudio GetStudiobyName(string name)
        {
            return FitStudio.FirstOrDefault(x => x.StudioName.ToUpper() == name.ToUpper());
        }

        /*********************** Fitness Classes ***********************/
        public void AddFitClass(FitnessClassSchedule fitclass)
        {
            FitClassSchedule.Add(fitclass);
        }

        public void EditFitClass(int id, FitnessClassSchedule fitclass)
        {
            var found = FitClassSchedule.FirstOrDefault(x => x.ClassId == id);
            if (found != null)
            {
                found.ClassName         = fitclass.ClassName;
                found.ClassStudioId     = fitclass.ClassStudioId;
                found.ClassInstrId      = fitclass.ClassInstrId;
                found.ClassDuration     = fitclass.ClassDuration;
                found.ClassStartTime    = fitclass.ClassStartTime;
                found.ClassWeekDay      = fitclass.ClassWeekDay;
            }
        }

        public void DeleteFitClass(int id)
        {
            var found = FitClassSchedule.FirstOrDefault(x => x.ClassId == id);
            if (found != null)
            {
                FitClassSchedule.Remove(found);
            }
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassSchedules()
        {
            return FitClassSchedule;
        }

        public FitnessClassSchedule GetFitClassSchedulesbyId(int id)
        {
            var found = FitClassSchedule.FirstOrDefault(x => x.ClassId == id);
            return found;
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByDay(DayOfWeek day)
        {
            return FitClassSchedule.Where(x=>x.ClassWeekDay == day).OrderBy(x=>x.ClassStartTime).ToList();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByInstrId(int instrid)
        {
            return FitClassSchedule.Where(x => x.ClassInstrId == instrid)
                .OrderBy(x => x.ClassWeekDay)
                .OrderBy(x => x.ClassStartTime)
                .ToList();
        }

        public IEnumerable<FitnessClassSchedule> GetFitClassScheduleByStudio(int studid)
        {
            return FitClassSchedule.Where(x => x.ClassStudioId == studid)
                .OrderBy(x => x.ClassWeekDay)
                .OrderBy(x => x.ClassStartTime)
                .ToList();
        }
    }
}
