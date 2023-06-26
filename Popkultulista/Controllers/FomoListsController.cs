using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Models;
using Popkultulista.Domain.Models.Identity;
using Popkultulista.Infrastructure;

namespace Popkultulista.Controllers
{
    public class FomoListsController : Controller
    {
        private readonly Context _context;

        public FomoListsController(Context context)
        {
            _context = context;
        }

        // GET: FomoLists
        public async Task<IActionResult> Index()
        {
            var Context = _context.FomoLists.Include(f => f.User);
            return View(await Context.ToListAsync());
        }

        // GET: FomoLists/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FomoLists == null)
            {
                return NotFound();
            }

            var fomoList = await _context.FomoLists
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fomoList == null)
            {
                return NotFound();
            }

            return View(fomoList);
        }

        // GET: FomoLists/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username");
            return View();
        }

        // POST: FomoLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Id,CreatedAt,CreatedBy")] FomoList fomoList)
        {
            if (ModelState.IsValid)
            {
                fomoList.Id = Guid.NewGuid();
                _context.Add(fomoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username", fomoList.UserId);
            return View(fomoList);
        }

        // GET: FomoLists/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FomoLists == null)
            {
                return NotFound();
            }

            var fomoList = await _context.FomoLists.FindAsync(id);
            if (fomoList == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username", fomoList.UserId);
            return View(fomoList);
        }

        // POST: FomoLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserId,Name,Id,CreatedAt,CreatedBy")] FomoList fomoList)
        {
            if (id != fomoList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fomoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FomoListExists(fomoList.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username", fomoList.UserId);
            return View(fomoList);
        }

        // GET: FomoLists/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FomoLists == null)
            {
                return NotFound();
            }

            var fomoList = await _context.FomoLists
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fomoList == null)
            {
                return NotFound();
            }

            return View(fomoList);
        }

        // POST: FomoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FomoLists == null)
            {
                return Problem("Entity set 'Context.FomoLists'  is null.");
            }
            var fomoList = await _context.FomoLists.FindAsync(id);
            if (fomoList != null)
            {
                _context.FomoLists.Remove(fomoList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FomoListExists(Guid id)
        {
            return (_context.FomoLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}