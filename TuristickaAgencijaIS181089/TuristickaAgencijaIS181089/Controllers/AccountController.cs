
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Domain.DTO;
using TuristickaAgencijaIS181089.Domain.Idenitity;
using TuristickaAgencijaIS181089.Domain.Identity;
using TuristickaAgencijaIS181089.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TuristickaAgencijaIS181089.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<TuristickaAgencijaUser> userManager;
        private readonly SignInManager<TuristickaAgencijaUser> signInManager;
        private readonly IUserService _userService;
        public AccountController(IUserService userservice,UserManager<TuristickaAgencijaUser> userManager, SignInManager<TuristickaAgencijaUser> signInManager)
        {
            _userService = userservice;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    var user = new TuristickaAgencijaUser
                    {
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserReservation = new Reservation(),
                        Role = EnumRoles.User
                    };
                    
                    var result = await userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(request);
                }
            }
            return View(request);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ChangeRoleOfUser()
        {   var user=await userManager.GetUserAsync(HttpContext.User);
            var users = _userService.GetAll();
            ViewBag.users = users;
        
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeRoleOfUser(TuristickaAgencijaUser toChange, string userName)
        {
            /*var user = await userManager.FindByIdAsync(toChange.Id);*/ //go naoga korisnikot
            var user = _userService.GetByEmail(userName);
            var role = user.Role;
            user.Role=change(role);//promena na uloga
            var result = await userManager.UpdateAsync(user); //update na user
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Lines");
            }
            else
            {
                return View(user);
            }
        }
        public EnumRoles change(EnumRoles role)
        {
            switch (role)
            {
                case EnumRoles.User:
                    return EnumRoles.Administrator;
                case EnumRoles.Administrator:
                    return EnumRoles.User;
                default: return EnumRoles.User;
            }
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
