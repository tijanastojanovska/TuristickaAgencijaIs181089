
using TuristickaAgencijaIS181089.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencijaIS181089.Domain.DTO
{ 
    public class ReservationDto
    {
        public List<ReservedLine> Lines { get; set; }
        public double TotalPrice { get; set; }
    }
}
