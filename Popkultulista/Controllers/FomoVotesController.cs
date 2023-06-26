using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Models;
using Popkultulista.Domain.Models.Identity;
using Popkultulista.Infrastructure;

namespace Popkultulista.Controllers
{
    public class FomoVotesController : Controller
    {
        private readonly Context _context;

        public FomoVotesController(Context context)
        {
            _context = context;
        }

        // GET: FomoVotes
        public async Task<IActionResult> Index()
        {
            var Context = _context.FomoVotes.Include(f => f.FomoItem).Include(f => f.User);
            return View(await Context.ToListAsync());
        }

        // GET: FomoVotes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FomoVotes == null)
            {
                return NotFound();
            }

            var fomoVote = await _context.FomoVotes
                .Include(f => f.FomoItem)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fomoVote == null)
            {
                return NotFound();
            }

            return View(fomoVote);
        }

        // GET: FomoVotes/Create
        public IActionResult Create()
        {
            ViewData["FomoItemId"] = new SelectList(_context.FomoItems, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username");
            return View();
        }

        // POST: FomoVotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FomoItemId,Value,UserId,Id,CreatedAt,CreatedBy")] FomoVote fomoVote)
        {
            if (ModelState.IsValid)
            {
                fomoVote.Id = Guid.NewGuid();
                _context.Add(fomoVote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FomoItemId"] = new SelectList(_context.FomoItems, "Id", "Name", fomoVote.FomoItemId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username", fomoVote.UserId);
            return View(fomoVote);
        }

        // GET: FomoVotes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FomoVotes == null)
            {
                return NotFound();
            }

            var fomoVote = await _context.FomoVotes.FindAsync(id);
            if (fomoVote == null)
            {
                return NotFound();
            }
            ViewData["FomoItemId"] = new SelectList(_context.FomoItems, "Id", "Name", fomoVote.FomoItemId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username", fomoVote.UserId);
            return View(fomoVote);
        }

        // POST: FomoVotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FomoItemId,Value,UserId,Id,CreatedAt,CreatedBy")] FomoVote fomoVote)
        {
            if (id != fomoVote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fomoVote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FomoVoteExists(fomoVote.Id))
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
            ViewData["FomoItemId"] = new SelectList(_context.FomoItems, "Id", "Name", fomoVote.FomoItemId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Username", fomoVote.UserId);
            return View(fomoVote);
        }

        // GET: FomoVotes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FomoVotes == null)
            {
                return NotFound();
            }

            var fomoVote = await _context.FomoVotes
                .Include(f => f.FomoItem)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fomoVote == null)
            {
                return NotFound();
            }

            return View(fomoVote);
        }

        // POST: FomoVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FomoVotes == null)
            {
                return Problem("Entity set 'Context.FomoVotes'  is null.");
            }
            var fomoVote = await _context.FomoVotes.FindAsync(id);
            if (fomoVote != null)
            {
                _context.FomoVotes.Remove(fomoVote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FomoVoteExists(Guid id)
        {
            return (_context.FomoVotes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}