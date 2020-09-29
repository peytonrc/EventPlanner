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
    public class EventCreate
    {
        [ForeignKey("Subject")] // Foreign Key
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "You have entered too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(5000)]
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]

        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Is All Day")]
        public bool IsAllDay { get; set; }

        [ForeignKey("Location")] // Foreign Key
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

    }
}
