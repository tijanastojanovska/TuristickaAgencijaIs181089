using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Domain.DTO;
using TuristickaAgencijaIS181089.Repository.Interfaces;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Services.Implementation
{
       public class LineService : ILineService
        {
            private readonly IRepository<Line> _lineRepository;
            private readonly IRepository<Destination> _destinationRepository;
            private readonly IRepository<ReservedLine> _reservedLineRepository;
            private readonly IRepository<Company> _companyRepository;
            private readonly IUserRepository _userRepository;
            private readonly ILogger<LineService> _logger;
            public LineService(IRepository<Line> lineRepository, IRepository<Company> companyRepository, IRepository<Destination> destinationRepository, ILogger<LineService> logger, IRepository<ReservedLine> reservedLineRepository, IUserRepository userRepository)
            {
                _lineRepository = lineRepository;
               _destinationRepository = destinationRepository;
            _companyRepository = companyRepository;
                _userRepository = userRepository;
                _reservedLineRepository = reservedLineRepository;
                _logger = logger;
            }

            public bool Reserve(ReserveDto item, string userID)
            {
            var user = this._userRepository.Get(userID);

            var userReservation = user.UserReservation;

            if (item.LineId != null && userReservation != null)
            {
                var line = this.GetDetailsForLine(item.LineId);

                if (line != null)
                {
                    ReservedLine reservedLine = new ReservedLine
                    {
                        Id = Guid.NewGuid(),
                        Line = line,
                        LineId = line.Id,
                        Reservation = userReservation,
                        ReservationId = userReservation.Id,
                        Quantity = item.Quantity
                    };

                    this._reservedLineRepository.Insert(reservedLine);
                    _logger.LogInformation("Line was successfully reserved");
                    return true;
                }
                return false;
            }
            _logger.LogInformation("Something was wrong. LineId or Reservation may be unaveliable!");
            return false;
        }

            public void CreateNewLine(Line l)
            {
                this._lineRepository.Insert(l);
            }

            public void DeleteLine(Guid id)
            {
                var Line = this.GetDetailsForLine(id);
                this._lineRepository.Delete(Line);
            }

            public List<Line> GetAllLines()
        { 
                return this._lineRepository.GetAll().ToList();
            }

            public Line GetDetailsForLine(Guid? id)
            {
                var Line= this._lineRepository.Get(id);
            var StartingDestintion = _destinationRepository.Get(Line.StartingDestinationId);
            var FinalDestination = _destinationRepository.Get(Line.FinalDestinationId);
            var Company = _companyRepository.Get(Line.CompanyId);
            Line.StartingDestination = StartingDestintion;
            Line.FinalDestination = FinalDestination;
            Line.Company = Company;
            return Line;
        }

            public ReserveDto GetReservationInfo(Guid? id)
            {
                var Line = this.GetDetailsForLine(id);
            //var StartingDestintion = _destinationRepository.Get(Line.StartingDestinationId);
            //var FinalDestination = _destinationRepository.Get(Line.FinalDestinationId);
            //var Company = _companyRepository.Get(Line.CompanyId);
            //Line.StartingDestination = StartingDestintion;
            //Line.FinalDestination = FinalDestination;
            //Line.Company = Company;


                ReserveDto model = new ReserveDto
                {
                    SelectedLine = Line,
                    LineId = Line.Id,
                    Quantity = 1
                };

                return model;
            }

            public void UpdeteExistingLine(Line l)
            {
                this._lineRepository.Update(l);
            }
        }
    }
