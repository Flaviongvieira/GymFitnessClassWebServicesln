using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymModels
{
    public class FitnessInstructor
    {
        // ID
        [Key]
        [Display(Name = "Instructor ID")]
        public int InstrId { get; set; }

        // Name
        [Required]
        [Display(Name = "Instructor Name")]
        [MinLength(2, ErrorMessage = "Instructor Name must have 2 letters")]
        public string InstrName { get; set; }

        // DOB
        [Display(Name = "Instructor Date of Birth")]
        public DateTime InstrDoB { get; set; }

        //List of classes that instructor teaches(potentially)
        [JsonIgnore]
        public virtual ICollection<FitnessClassSchedule>? FitClasses { get; set; }

    }
}


