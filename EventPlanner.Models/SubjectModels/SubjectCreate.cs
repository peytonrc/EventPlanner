﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventPlanner.Data.Subject;

namespace EventPlanner.Models.SubjectModels
{
    public class SubjectCreate
    {
        [Display(Name = "Type of Event")]
        public string TypeOfEvent { get; set; }

        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
    }
}
