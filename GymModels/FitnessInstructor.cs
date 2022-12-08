using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        public int InstrId { get; set; }

        // Name
        [Required]
        public string InstrName { get; set; }

        // DOB
        public DateTime InstrDoB { get; set; }

        //List of classes that instructor teaches(potentially)
        public virtual ICollection<FitnessClassSchedule>? FitClasses { get; set; }

    }
}


