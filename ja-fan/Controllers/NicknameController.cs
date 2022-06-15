using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ja_fan.Data;
using ja_fan.Models;

namespace ja_fan.Controllers
{
    public class NicknameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NicknameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nickname
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nickname.Include(n => n.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nickname/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nickname == null)
            {
                return NotFound();
            }

            var nickname = await _context.Nickname
                .Include(n => n.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nickname == null)
            {
                return NotFound();
            }

            return View(nickname);
        }

        // GET: Nickname/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name");
            return View();
        }

        // POST: Nickname/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TeamId")] Nickname nickname)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nickname);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name", nickname.TeamId);
            return View(nickname);
        }

        // GET: Nickname/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nickname == null)
            {
                return NotFound();
            }

            var nickname = await _context.Nickname.FindAsync(id);
            if (nickname == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name", nickname.TeamId);
            return View(nickname);
        }

        // POST: Nickname/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TeamId")] Nickname nickname)
        {
            if (id != nickname.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nickname);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NicknameExists(nickname.Id))
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
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name", nickname.TeamId);
            return View(nickname);
        }

        // GET: Nickname/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nickname == null)
            {
                return NotFound();
            }

            var nickname = await _context.Nickname
                .Include(n => n.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nickname == null)
            {
                return NotFound();
            }

            return View(nickname);
        }

        // POST: Nickname/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nickname == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nickname'  is null.");
            }
            var nickname = await _context.Nickname.FindAsync(id);
            if (nickname != null)
            {
                _context.Nickname.Remove(nickname);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NicknameExists(int id)
        {
          return (_context.Nickname?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
