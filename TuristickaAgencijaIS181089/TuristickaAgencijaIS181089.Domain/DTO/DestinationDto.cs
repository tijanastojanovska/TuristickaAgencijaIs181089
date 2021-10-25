using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;

namespace TuristickaAgencijaIS181089.Domain.DTO
{
   public class DestinationDto
    {

        public List<Destination> Destinations { get; set; }
        public string DestinationName { get; set; }
        public string DestinationCountry { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public EnumRoles? CurrentUserRole { get; set; }
    }
}
