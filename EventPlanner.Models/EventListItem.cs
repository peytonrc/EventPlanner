using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class EventListItem
    {
        [Display(Name="Event ID")]
        public int EventID { get; set; }

        public string Title { get; set; }

        [Display(Name ="All Day")]
        public bool IsAllDay { get; set; }

    }
}
