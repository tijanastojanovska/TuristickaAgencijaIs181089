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
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Order> _orderRepositorty;
        private readonly IRepository<OrderedLine> _orderedLineRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<EmailMessage> _mailRepository;

        public ReservationService(IRepository<EmailMessage> mailRepository, IRepository<Reservation> reservationRepository, IRepository<OrderedLine> orderedLineRepository, IRepository<Order> orderRepositorty, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _orderRepositorty = orderRepositorty;
            _orderedLineRepository = orderedLineRepository;
            _mailRepository = mailRepository;
        }

 

        public bool deleteReservedLine(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {


                var loggedInUser = this._userRepository.Get(userId);

                var userReservation = loggedInUser.UserReservation;

                var itemToDelete = userReservation.ReservedLines.Where(z => z.LineId.Equals(id)).FirstOrDefault();

                userReservation.ReservedLines.Remove(itemToDelete);

                this._reservationRepository.Update(userReservation);

                return true;
            }

            return false;
        }

        public ReservationDto getReservationInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userReservation = loggedInUser.UserReservation;


            var AllLines = userReservation.ReservedLines.ToList();

            var allLinesPrice = AllLines.Select(z => new
            {
                LinePrice = z.Line.LinePrice,
                Quanitity = z.Quantity
            }).ToList();

            double totalPrice = 0;


            foreach (var item in allLinesPrice)
            {
                totalPrice += item.Quanitity * item.LinePrice;
            }


            ReservationDto rDto = new ReservationDto
            {
                Lines = AllLines,
                TotalPrice = totalPrice
            };


            return rDto;

        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {


                var loggedInUser = this._userRepository.Get(userId);

                var userReservation = loggedInUser.UserReservation;

                EmailMessage mail = new EmailMessage();
                mail.MailTo = loggedInUser.Email;
                mail.Subject = "Successfully created order";
                mail.Status = false;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepositorty.Insert(order);

                List<OrderedLine> LineInOrders = new List<OrderedLine>();

                var result = userReservation.ReservedLines.Select(z => new OrderedLine
                {
                    Id = Guid.NewGuid(),
                    LineId = z.Line.Id,
                    LineInOrder = z.Line,
                    OrderId = order.Id,
                    UserOrder = order,
                    Quantity = z.Quantity
                }).ToList();

                StringBuilder sb = new StringBuilder();

                double totalPrice = 0;

                sb.AppendLine("Your order is completed. The order conains: ");

                for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i - 1];

                    totalPrice += item.Quantity * item.LineInOrder.LinePrice;

                    sb.AppendLine(i.ToString() + ". " + "Line with price of: " + item.LineInOrder.LinePrice + " and quantity of: " + item.Quantity 
                        + "with starting destination" + item.LineInOrder.StartingDestination.DestinationName +"and final destination" 
                        + item.LineInOrder.FinalDestination.DestinationName);
                }

                sb.AppendLine("Total price: " + totalPrice.ToString());


                mail.Content = sb.ToString();


                LineInOrders.AddRange(result);

                foreach (var item in LineInOrders)
                {
                    this._orderedLineRepository.Insert(item);
                }

                loggedInUser.UserReservation.ReservedLines.Clear();

                this._userRepository.Update(loggedInUser);
                this._mailRepository.Insert(mail);

                return true;
            }
            return false;
        }


    }
}
