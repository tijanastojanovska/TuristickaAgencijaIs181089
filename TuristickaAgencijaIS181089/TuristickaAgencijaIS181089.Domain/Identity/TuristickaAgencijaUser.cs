
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;

namespace TuristickaAgencijaIS181089.Domain.Identity
{
    public class TuristickaAgencijaUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public EnumRoles Role { get; set; }
        public virtual Reservation UserReservation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
