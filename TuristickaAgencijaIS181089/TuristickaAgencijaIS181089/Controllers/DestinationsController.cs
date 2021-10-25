using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Domain.DTO;
using TuristickaAgencijaIS181089.Domain.Identity;
using TuristickaAgencijaIS181089.Repository.Data;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Web.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<TuristickaAgencijaUser> _userManager;

        public DestinationsController(IDestinationService destinationService, ApplicationDbContext context,UserManager<TuristickaAgencijaUser>userManager)
        {
            _context = context;
            _userManager = userManager;
            _destinationService = destinationService;
        }

        // GET: Destinations
        //[Authorize]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Destinations.ToListAsync());
        //}
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var toFilter = new DestinationDto
            {
                Destinations = _destinationService.GetAllDestinations(),
               CurrentUserRole = user.Role
            };
            return View(toFilter);
        }
        [HttpPost]
        public IActionResult Index(DestinationDto toFilter)
        {
            var destinations = _destinationService.GetAllDestinations()
                .Where(z => z.DestinationCountry == toFilter.DestinationCountry).ToList(); //ako e ist datumot so odbraniot
            var filtered = new DestinationDto
            {
                Destinations = destinations,
               
            };
            return View(filtered); //vrati filtirani
        }

        // GET: Destinations/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: Destinations/Create
        [Authorize]
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationName,DestinationCountry,DestinationImage,Latitude,Longitude,Id")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                destination.Id = Guid.NewGuid();
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        // GET: Destinations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations.FindAsync(id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DestinationName,DestinationCountry,DestinationImage,Latitude,Longitude,Id")] Destination destination)
        {
            if (id != destination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationExists(destination.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        // GET: Destinations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(Guid id)
        {
            return _context.Destinations.Any(e => e.Id == id);
        }
    }
}
