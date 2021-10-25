using System;
using System.Collections.Generic;
using System.Text;


namespace TuristickaAgencijaAdminApplication.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public virtual IEnumerable<Line> Lines { get; set; }
    }
}
