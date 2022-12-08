using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymModels
{
    public class FitnessClassSchedule
    {
        // ID - primary key
        [Key]
        public int ClassId { get; set; }

        // Fitness Class name
        [Required]
        public string ClassName { get; set; }

        // Weekday
        [Required]
        public DayOfWeek ClassWeekDay{ get; set; }

        // Start Time
        [Required]
        public string ClassStartTime { get; set; }

        // Duration
        public int ClassDuration { get; set; }

        // Studio(foreign Key from Fitness Studio table)
        public int ClassStudioId { get; set; }
        public FitnessStudio? ClassStudio { get; set; }

        // Instructor(foreign Key from the Fitness Instructor table)
        public int ClassInstrId { get; set; }
        public FitnessInstructor? ClassInstr { get; set; }

    }
}
