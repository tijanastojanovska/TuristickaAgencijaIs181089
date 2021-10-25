using System.Collections.Generic;
using TuristickaAgencijaIS181089.Domain.Identity;

namespace TuristickaAgencijaIS181089.Domain.DomainModels
{
    public class Reservation : BaseEntity
    {

        public string OwnerId { get; set; }
        public TuristickaAgencijaUser Owner { get; set; }
        public virtual ICollection<ReservedLine> ReservedLines { get; set; }
    }
}
