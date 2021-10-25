using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.Identity;
using TuristickaAgencijaIS181089.Repository.Interfaces;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public TuristickaAgencijaUser GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }
        public IEnumerable<TuristickaAgencijaUser> GetAll()
        {
            return _userRepository.GetAll();
        }
        public TuristickaAgencijaUser Get(string id)
        {
            return _userRepository.Get(id);
        }

        public void Insert(TuristickaAgencijaUser entity)
        {
             _userRepository.Insert(entity);
        }
    }
}
