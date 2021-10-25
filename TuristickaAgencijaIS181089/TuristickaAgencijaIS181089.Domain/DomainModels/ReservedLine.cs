using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencijaIS181089.Domain.DomainModels
{
    public class ReservedLine : BaseEntity
    {
        public Guid LineId { get; set; }
        public Line Line { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public int Quantity { get; set; }
    }
}
