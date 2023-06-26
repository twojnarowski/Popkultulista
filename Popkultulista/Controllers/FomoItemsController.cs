using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Models;
using Popkultulista.Infrastructure;

namespace Popkultulista.Controllers
{
    public class FomoItemsController : Controller
    {
        private readonly Context _context;

        public FomoItemsController(Context context)
        {
            _context = context;
        }

        // GET: FomoItems
        public async Task<IActionResult> Index()
        {
            var Context = _context.FomoItems.Include(f => f.FomoList);
            return View(await Context.ToListAsync());
        }

        // GET: FomoItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FomoItems == null)
            {
                return NotFound();
            }

            var fomoItem = await _context.FomoItems
                .Include(f => f.FomoList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fomoItem == null)
            {
                return NotFound();
            }

            return View(fomoItem);
        }

        // GET: FomoItems/Create
        public IActionResult Create()
        {
            ViewData["FomoListId"] = new SelectList(_context.FomoLists, "Id", "Name");
            return View();
        }

        // POST: FomoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FomoListId,FomoCoreScore,FomoVotesScore,FomoTotalScore,Name,Id,CreatedAt,CreatedBy")] FomoItem fomoItem)
        {
            if (ModelState.IsValid)
            {
                fomoItem.Id = Guid.NewGuid();
                _context.Add(fomoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FomoListId"] = new SelectList(_context.FomoLists, "Id", "Name", fomoItem.FomoListId);
            return View(fomoItem);
        }

        // GET: FomoItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FomoItems == null)
            {
                return NotFound();
            }

            var fomoItem = await _context.FomoItems.FindAsync(id);
            if (fomoItem == null)
            {
                return NotFound();
            }
            ViewData["FomoListId"] = new SelectList(_context.FomoLists, "Id", "Name", fomoItem.FomoListId);
            return View(fomoItem);
        }

        // POST: FomoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FomoListId,FomoCoreScore,FomoVotesScore,FomoTotalScore,Name,Id,CreatedAt,CreatedBy")] FomoItem fomoItem)
        {
            if (id != fomoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fomoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FomoItemExists(fomoItem.Id))
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
            ViewData["FomoListId"] = new SelectList(_context.FomoLists, "Id", "Name", fomoItem.FomoListId);
            return View(fomoItem);
        }

        // GET: FomoItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FomoItems == null)
            {
                return NotFound();
            }

            var fomoItem = await _context.FomoItems
                .Include(f => f.FomoList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fomoItem == null)
            {
                return NotFound();
            }

            return View(fomoItem);
        }

        // POST: FomoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FomoItems == null)
            {
                return Problem("Entity set 'Context.FomoItems'  is null.");
            }
            var fomoItem = await _context.FomoItems.FindAsync(id);
            if (fomoItem != null)
            {
                _context.FomoItems.Remove(fomoItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FomoItemExists(Guid id)
        {
            return (_context.FomoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}