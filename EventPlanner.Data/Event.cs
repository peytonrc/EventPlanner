using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey("Subject")] // Foreign Key
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; }

        [Required]
        public bool IsAllDay { get; set; }

        [ForeignKey("Location")] // Foreign Key
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

    }
}
