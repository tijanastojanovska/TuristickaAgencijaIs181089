using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Domain.Idenitity;
using TuristickaAgencijaIS181089.Domain.Identity;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<TuristickaAgencijaUser> userManager;

        public AdminController(IOrderService orderService, UserManager<TuristickaAgencijaUser> userManager)
        {
            _orderService = orderService;
            this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            return this._orderService.getAllOrders();
        }

        [HttpGet("[action]")]
        public async Task<TuristickaAgencijaUser> GetUser()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return user;
        }

        [HttpPost("[action]")]
        public Order GetDetailsForLine(BaseEntity model)
        {
            return this._orderService.getOrderDetails(model);
        }

        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;

            foreach (var item in model)
            {
                var userCheck = userManager.FindByEmailAsync(item.Email).Result;

                if (userCheck == null)
                {
                    var user = new TuristickaAgencijaUser
                    {
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserReservation = new Reservation()
                       
                    };
                    var result = userManager.CreateAsync(user, item.Password).Result;

                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }

    }
}
