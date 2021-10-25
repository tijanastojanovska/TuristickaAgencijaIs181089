using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TuristickaAgencijaAdminApplication.Models
{
    public class TuristickaAgencijaUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
     
        public string NormalizedUserName { get; set; }
      
        public string UserName { get; set; }
        public EnumRoles Role { get; set; }

    }
}
