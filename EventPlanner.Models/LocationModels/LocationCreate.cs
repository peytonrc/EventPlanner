using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Models.LocationModels
{
    public class LocationCreate
    {
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Is Inside")]
        public bool IsInside { get; set; }

        [Display(Name = "Travel Time")]
        public string TravelTime { get; set; }
    }
}
