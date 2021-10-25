using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Web.Controllers
{
    public class ReservationController : Controller
    {


        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rd= this._reservationService.getReservationInfo(userId);
            return View(rd);
        }
        [Authorize]
        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = this._reservationService.getReservationInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "Line Payment",
                Currency = "usd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                var result = this.Order();

                if (result)
                {

                    return RedirectToAction("Index", "Reservation");
                }
                else
                {
                    return RedirectToAction("Index", "Reservation");
                }
            }

            return RedirectToAction("Index", "Reservation");
        }
        [Authorize]
        public IActionResult DeleteFromReservations(Guid id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._reservationService.deleteReservedLine(userId, id);

            if (result)
            {
                _reservationService.orderNow(userId);
                return RedirectToAction("Index", "Reservation");
            }
            else
            {
                return RedirectToAction("Index", "Reservation");
            }
        }

        private Boolean Order()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._reservationService.orderNow(userId);

            return result;
        }
    }
}
