using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class EventEdit
    {
        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Is All Day")]
        public bool IsAllDay { get; set; }
    }
}
