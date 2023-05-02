using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using range_ton_ricaud.Data;
using range_ton_ricaud.Models;

namespace range_ton_ricaud.Controllers
{
    public class ToolKeywordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToolKeywordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToolKeywords
        public async Task<IActionResult> Index()
        {
              return _context.ToolKeyword != null ? 
                          View(await _context.ToolKeyword.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ToolKeyword'  is null.");
        }

        // GET: ToolKeywords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToolKeyword == null)
            {
                return NotFound();
            }

            var toolKeyword = await _context.ToolKeyword
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toolKeyword == null)
            {
                return NotFound();
            }

            return View(toolKeyword);
        }

        // GET: ToolKeywords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToolKeywords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ToolKeyword toolKeyword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toolKeyword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toolKeyword);
        }

        // GET: ToolKeywords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToolKeyword == null)
            {
                return NotFound();
            }

            var toolKeyword = await _context.ToolKeyword.FindAsync(id);
            if (toolKeyword == null)
            {
                return NotFound();
            }
            return View(toolKeyword);
        }

        // POST: ToolKeywords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ToolKeyword toolKeyword)
        {
            if (id != toolKeyword.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toolKeyword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolKeywordExists(toolKeyword.Id))
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
            return View(toolKeyword);
        }

        // GET: ToolKeywords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToolKeyword == null)
            {
                return NotFound();
            }

            var toolKeyword = await _context.ToolKeyword
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toolKeyword == null)
            {
                return NotFound();
            }

            return View(toolKeyword);
        }

        // POST: ToolKeywords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToolKeyword == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ToolKeyword'  is null.");
            }
            var toolKeyword = await _context.ToolKeyword.FindAsync(id);
            if (toolKeyword != null)
            {
                _context.ToolKeyword.Remove(toolKeyword);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToolKeywordExists(int id)
        {
          return (_context.ToolKeyword?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
