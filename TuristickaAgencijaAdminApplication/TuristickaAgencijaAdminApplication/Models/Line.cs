using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencijaAdminApplication.Models
{
   public class Line
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public double LinePrice { get; set; }
        public string LineImage { get; set; }
        public Destination StartingDestination { get; set; }
        public Guid StartingDestinationId { get; set; }
        public Guid FinalDestinationId { get; set; }
        public Destination FinalDestination { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public IEnumerable<OrderedLine> OrderedLines { get; set; }

    }
}
