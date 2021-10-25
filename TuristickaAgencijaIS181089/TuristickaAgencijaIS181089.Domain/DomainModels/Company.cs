using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencijaIS181089.Domain.DomainModels
{
    public class Company:BaseEntity
    {
        public string CompanyName { get; set; }
        public virtual IEnumerable<Line> Lines { get; set; }
    }
}
