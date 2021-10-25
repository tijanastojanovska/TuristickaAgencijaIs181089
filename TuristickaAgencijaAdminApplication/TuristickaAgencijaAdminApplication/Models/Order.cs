
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencijaAdminApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public TuristickaAgencijaUser User { get; set; }

        public IEnumerable<OrderedLine> OrderedLines { get; set; }
    }
}
