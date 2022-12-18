using Newtonsoft.Json;
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
        [Display(Name = "Studio ID")]
        public int StudioId { get; set; }

        // Name
        [Required]
        [Display(Name = "Studio Name")]
        [MinLength(3, ErrorMessage = "Studio Name must have 3 letters")]
        public string StudioName { get; set; }

        //List of classes that instructor teaches(potentially)
        [JsonIgnore]
        public virtual ICollection<FitnessClassSchedule>? FitClasses { get; set; }
    }
}
