using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuristickaAgencijaIS181089.Domain.DomainModels
{
    public class Destination : BaseEntity
    {
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
