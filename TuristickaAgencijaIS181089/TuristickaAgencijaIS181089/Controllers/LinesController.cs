using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using TuristickaAgencijaIS181089.Services.Implementation;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Web.Controllers
{
    public class LinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILineService _lineService;
        private readonly UserManager<TuristickaAgencijaUser> _userManager;
       
      

        public LinesController(ApplicationDbContext context, ILineService lineService,UserManager<TuristickaAgencijaUser> userManager)
        {
            _context = context;
            _lineService = lineService;
            _userManager = userManager;
           
           
        }

        // GET: Lines
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            var applicationDbContext = _context.Lines.Include(l => l.Company).Include(l => l.FinalDestination).Include(l => l.StartingDestination);
            return View(await applicationDbContext.ToListAsync());
           
        }
  

        [Authorize]
        public IActionResult Reserve(Guid? id)
        {

            var model = this._lineService.GetReservationInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Reserve(ReserveDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._lineService.Reserve(item, userId);

            if (result)
            {
                return RedirectToAction("Index", "Lines");
            }

            return View(item);
        }
        // GET: Lines/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines
                .Include(l => l.Company)
                .Include(l => l.FinalDestination)
                .Include(l => l.StartingDestination)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // GET: Lines/Create
        [Authorize]
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName");
            ViewData["FinalDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationName");
            ViewData["StartingDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationName");
            return View();
        }

        // POST: Lines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateTime,LinePrice,LineImage,StartingDestinationId,FinalDestinationId,CompanyId,Id")] Line line)
        {
            if (ModelState.IsValid)
            {
                line.Id = Guid.NewGuid();
                _context.Add(line);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "CompanyName", line.CompanyId);
            ViewData["FinalDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationName", line.FinalDestinationId);
            ViewData["StartingDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationName", line.StartingDestinationId);
            return View(line);
        }

        // GET: Lines/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            var line = await _context.Lines.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", line.CompanyId);
            ViewData["FinalDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationCountry", line.FinalDestinationId);
            ViewData["StartingDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationCountry", line.StartingDestinationId);
            return View(line);
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DateTime,LinePrice,LineImage,StartingDestinationId,FinalDestinationId,CompanyId,Id")] Line line)
        {
            if (id != line.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(line);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineExists(line.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", line.CompanyId);
            ViewData["FinalDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationCountry", line.FinalDestinationId);
            ViewData["StartingDestinationId"] = new SelectList(_context.Destinations, "Id", "DestinationCountry", line.StartingDestinationId);
            return View(line);
        }

        // GET: Lines/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            var line = await _context.Lines
                .Include(l => l.Company)
                .Include(l => l.FinalDestination)
                .Include(l => l.StartingDestination)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var line = await _context.Lines.FindAsync(id);
            _context.Lines.Remove(line);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineExists(Guid id)
        {
            return _context.Lines.Any(e => e.Id == id);
        }

       
        }

    }

