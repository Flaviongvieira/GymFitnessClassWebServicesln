using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymModels
{
    public class FitnessStudio
    {

        // ID
        [Key]
        public int StudioId { get; set; }

        // Name
        [Required]
        public string StudioName { get; set; }

        //List of classes that instructor teaches(potentially)
        public virtual ICollection<FitnessClassSchedule>? FitClasses { get; set; }
    }
}
