using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.Identity;

namespace TuristickaAgencijaIS181089.Domain.DTO
{
    public class UserDto
    {
        public IEnumerable<TuristickaAgencijaUser> users;
        public TuristickaAgencijaUser user;
    }
}
