using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models.LocationModels
{
    public class LocationListItem
    {
        [Display(Name="Location ID")]
        public int LocationID { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [Display(Name = "Is Inside")]
        public bool IsInside { get; set; }

    }
}
