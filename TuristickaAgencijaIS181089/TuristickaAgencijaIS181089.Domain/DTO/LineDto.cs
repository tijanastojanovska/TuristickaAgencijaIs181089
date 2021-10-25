using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;

namespace TuristickaAgencijaIS181089.Domain.DTO
{
   public class LineDto
    {
        public List<Line> Lines { get; set; }
        public double LinePrice { get; set; }

        public DestinationDto StartingDestination { get; set; }
        public DestinationDto FinalDestination { get; set; }
        public CompanyDto CompanyName { get; set; }
        public EnumRoles? CurrentUserRole { get; set; }
    }
}
