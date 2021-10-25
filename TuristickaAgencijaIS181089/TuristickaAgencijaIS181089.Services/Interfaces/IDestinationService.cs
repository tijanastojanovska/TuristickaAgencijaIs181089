using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;

namespace TuristickaAgencijaIS181089.Services.Interfaces
{
    public interface IDestinationService
    {
        List<Destination> GetAllDestinations();
        Destination GetDetailsForDestination(Guid? id);
        void CreateNewDestination(Destination d);
        void UpdateDestination(Destination d);
        void DeleteDestination(Guid id);
    }
}
