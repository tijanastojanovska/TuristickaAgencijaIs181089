using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Repository.Interfaces;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Services.Implementation
{
   public class DestinationService:IDestinationService
    {
        private readonly IRepository<Destination> _DestinationRepository;
        public DestinationService(IRepository<Destination> DestinationRepository)
        {
            _DestinationRepository = DestinationRepository;
        }
        public void CreateNewDestination(Destination c)
        {
            this._DestinationRepository.Insert(c);
        }

        public void DeleteDestination(Guid id)
        {
            var Destination = this.GetDetailsForDestination(id);
            this._DestinationRepository.Delete(Destination);
        }

        public List<Destination> GetAllDestinations()
        {
            return this._DestinationRepository.GetAll().ToList();
        }
        public Destination GetDetailsForDestination(Guid? id)
        {
            return this._DestinationRepository.Get(id);
        }
        public void UpdateDestination(Destination d)
        {
            this._DestinationRepository.Update(d);
        }

    }
}

