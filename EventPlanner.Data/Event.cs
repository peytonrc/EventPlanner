using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //[ForeignKey("Subject")] // Foreign Key
        //[Display(Name = "Subject ID")]
        //public int SubjectID { get; set; }
        //public virtual Subject Subject { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public bool IsAllDay { get; set; }

        //[ForeignKey("Destination")] // Foreign Key
        //[Display(Name = "Destination ID")]
        //public int DestinationID { get; set; }
        //public virtual Destination Destination { get; set; }

    }
}
