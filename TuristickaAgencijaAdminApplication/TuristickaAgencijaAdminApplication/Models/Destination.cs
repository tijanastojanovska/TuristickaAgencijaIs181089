using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuristickaAgencijaAdminApplication.Models
{
    public class Destination
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name ="Destination")]
        public string DestinationName { get; set; }
      
        [Required]
        public string DestinationCountry { get; set; }
        public string DestinationImage { get; set; }
        public IEnumerable<Line> LinesS { get; set; }
        public IEnumerable<Line> LinesF { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
       

    }
}
