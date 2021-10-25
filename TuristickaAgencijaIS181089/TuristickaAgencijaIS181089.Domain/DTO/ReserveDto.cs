

using TuristickaAgencijaIS181089.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuristickaAgencijaIS181089.Domain.DTO

{
    public class ReserveDto
    {
        public Line SelectedLine { get; set; }
        public Guid LineId { get; set; }
        public int Quantity { get; set; }
    }
}
