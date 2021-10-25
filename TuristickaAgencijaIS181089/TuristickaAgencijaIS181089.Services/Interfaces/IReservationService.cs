using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DTO;

namespace TuristickaAgencijaIS181089.Services.Interfaces
{
    public interface IReservationService
    {
        ReservationDto getReservationInfo(string userId);
        bool deleteReservedLine(string userId, Guid id);
        bool orderNow(string userId);
    }
}
