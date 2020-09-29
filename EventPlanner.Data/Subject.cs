using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public ActivityType TypeOfActivity { get; set; }

        public enum ActivityType
        {
           Business,
           Social,
           Education,
           Personal
        }

        [Required]
        public string SubjectName { get; set; }

    }
}
