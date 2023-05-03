﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using range_ton_ricaud.Data;
using range_ton_ricaud.Models;

namespace range_ton_ricaud.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tools
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tool.Include(t => t.Garage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tool == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool
                .Include(t => t.Garage)
                .Include(t => t.ToolKeywords)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Tools/Create
        public IActionResult Create()
        {
            ViewData["GarageId"] = new SelectList(_context.Garage, "Id", "Name");
            ViewData["ToolKeywords"] = new SelectList(_context.ToolKeyword, "Id", "Name");
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GarageId,ToolKeywords")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GarageId"] = new SelectList(_context.Garage, "Id", "Name", tool.GarageId);
            return View(tool);
        }

        // GET: Tools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tool == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool.FindAsync(id);
            if (tool == null)
            {
                return NotFound();
            }
            ViewData["GarageId"] = new SelectList(_context.Garage, "Id", "Name", tool.GarageId);
            return View(tool);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BrokenAt,GarageId,ToolKeywords")] Tool tool)
        {
            if (id != tool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolExists(tool.Id))
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
            ViewData["GarageId"] = new SelectList(_context.Garage, "Id", "Name", tool.GarageId);
            return View(tool);
        }

        // GET: Tools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tool == null)
            {
                return NotFound();
            }

            var tool = await _context.Tool
                .Include(t => t.Garage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tool == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tool'  is null.");
            }
            var tool = await _context.Tool.FindAsync(id);
            if (tool != null)
            {
                _context.Tool.Remove(tool);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToolExists(int id)
        {
            return (_context.Tool?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
