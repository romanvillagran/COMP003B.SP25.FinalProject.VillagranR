using COMP003B.SP25.FinalProject.VillagranR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.VillagranR.Data;

namespace COMP003B.SP25.FinalProject.VillagranR.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor: Dependency Injection of the database context
        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events (Lists all events)
        public async Task<IActionResult> Index()
        {
            // Include related data (Category and Venue) for display
            var events = await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Venue)
                .ToListAsync();
            return View(events);
        }

        // GET: Events/Details/5 (Shows a single event)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create (Displays the create form)
        public IActionResult Create()
        {
            // Pass dropdown data to the view
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name");
            return View();
        }

        // POST: Events/Create (Handles form submission)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,Description,CategoryId,VenueId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Repopulate dropdowns if validation fails
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", @event.CategoryId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name", @event.VenueId);
            return View(@event);
        }

        // GET: Events/Edit/5 (Displays edit form)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", @event.CategoryId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name", @event.VenueId);
            return View(@event);
        }

        // POST: Events/Edit/5 (Handles edit submission)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,Description,CategoryId,VenueId")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", @event.CategoryId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name", @event.VenueId);
            return View(@event);
        }

        // GET: Events/Delete/5 (Delete confirmation)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5 (Handles delete)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Helper method to check if event exists
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
