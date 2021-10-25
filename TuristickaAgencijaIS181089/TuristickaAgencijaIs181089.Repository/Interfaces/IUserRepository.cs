using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.Identity;

namespace TuristickaAgencijaIS181089.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<TuristickaAgencijaUser> GetAll();
        TuristickaAgencijaUser Get(string id);
        TuristickaAgencijaUser GetByEmail(string email);
        void Insert(TuristickaAgencijaUser entity);
        void Update(TuristickaAgencijaUser entity);
        void Delete(TuristickaAgencijaUser entity);
    }
}
