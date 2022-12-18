using Newtonsoft.Json;
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
        [Display(Name = "Fitness Class ID")]
        public int ClassId { get; set; }

        // Fitness Class name
        [Required]
        [Display(Name = "Ftiness Class Name")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string ClassName { get; set; }

        // Weekday
        [Required]
        [Display(Name = "Fitness Class Week Day")]
        public DayOfWeek ClassWeekDay{ get; set; }

        // Start Time
        [Required]
        [Display(Name = "Fitness Class Start Time")]
        public string ClassStartTime { get; set; }

        // Duration
        [Display(Name = "Fitness Class Duration")]
        public int ClassDuration { get; set; }

        // Studio(foreign Key from Fitness Studio table)
        [Display(Name = "Fitness Class Studio ID")]
        public int ClassStudioId { get; set; }
        [JsonIgnore]
        public FitnessStudio? ClassStudio { get; set; }

        // Instructor(foreign Key from the Fitness Instructor table)
        [Display(Name = "Fitness Class Instructor ID")]
        public int ClassInstrId { get; set; }
        [JsonIgnore]
        public FitnessInstructor? ClassInstr { get; set; }

    }
}
