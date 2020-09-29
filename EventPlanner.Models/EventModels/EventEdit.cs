﻿using EventPlanner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models
{
    public class EventEdit
    {
        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [ForeignKey("Subject")] // Foreign Key
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public string Time { get; set; }

        [Display(Name = "Is All Day")]
        public bool IsAllDay { get; set; }

        [ForeignKey("Location")] // Foreign Key
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

    }
}
