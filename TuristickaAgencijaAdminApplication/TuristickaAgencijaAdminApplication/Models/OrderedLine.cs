using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TuristickaAgencijaAdminApplication.Models
{
    public class OrderedLine 
    {
        public Guid Id { get; set; }
        public Guid LineId { get; set; }
        public Line LineInOrder { get; set; }

        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
        public int Quantity { get; set; }
    }
}
