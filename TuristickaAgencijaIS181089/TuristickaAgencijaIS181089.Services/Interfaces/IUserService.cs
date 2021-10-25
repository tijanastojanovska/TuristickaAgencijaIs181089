using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.Identity;

namespace TuristickaAgencijaIS181089.Services.Interfaces
{
    public interface IUserService
    {
        TuristickaAgencijaUser GetByEmail(string email);
        TuristickaAgencijaUser Get(string email);
        void Insert(TuristickaAgencijaUser entity);
        IEnumerable<TuristickaAgencijaUser> GetAll();
    }
}
