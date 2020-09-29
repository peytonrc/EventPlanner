using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public string LocationName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool IsInside { get; set; }

        [Required]
        public string TravelTime { get; set; }

    }
}
