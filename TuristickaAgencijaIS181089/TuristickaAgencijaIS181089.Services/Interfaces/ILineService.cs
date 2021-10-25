using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Domain.DTO;

namespace TuristickaAgencijaIS181089.Services.Interfaces
{
   public interface ILineService
    {
        List<Line> GetAllLines();
        Line GetDetailsForLine(Guid? id);
        void CreateNewLine(Line l);
        void UpdeteExistingLine(Line l);
        ReserveDto GetReservationInfo(Guid? id);
        void DeleteLine(Guid id);
        bool Reserve(ReserveDto item, string userID);
    }
}
