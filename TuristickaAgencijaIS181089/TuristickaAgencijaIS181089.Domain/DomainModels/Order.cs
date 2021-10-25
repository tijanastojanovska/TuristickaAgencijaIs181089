
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencijaIS181089.Domain.Identity;

namespace TuristickaAgencijaIS181089.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public TuristickaAgencijaUser User { get; set; }

        public IEnumerable<OrderedLine> OrderedLines { get; set; }
    }
}
