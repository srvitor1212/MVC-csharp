using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cerveja.Data;
using Cerveja.Models;

namespace Cerveja.Controllers
{
    public class RotulosController : Controller
    {
        private readonly CervejaContext _context;

        public RotulosController(CervejaContext context)
        {
            _context = context;
        }

        // GET: Rotulos
        public async Task<IActionResult> Index()
        {
              return _context.Rotulo != null ? 
                          View(await _context.Rotulo.ToListAsync()) :
                          Problem("Entity set 'CervejaContext.Rotulo'  is null.");
        }

        // GET: Rotulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rotulo == null)
            {
                return NotFound();
            }

            var rotulo = await _context.Rotulo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rotulo == null)
            {
                return NotFound();
            }

            return View(rotulo);
        }

        // GET: Rotulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rotulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Rotulo rotulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rotulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rotulo);
        }

        // GET: Rotulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rotulo == null)
            {
                return NotFound();
            }

            var rotulo = await _context.Rotulo.FindAsync(id);
            if (rotulo == null)
            {
                return NotFound();
            }
            return View(rotulo);
        }

        // POST: Rotulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Rotulo rotulo)
        {
            if (id != rotulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rotulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotuloExists(rotulo.Id))
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
            return View(rotulo);
        }

        // GET: Rotulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rotulo == null)
            {
                return NotFound();
            }

            var rotulo = await _context.Rotulo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rotulo == null)
            {
                return NotFound();
            }

            return View(rotulo);
        }

        // POST: Rotulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rotulo == null)
            {
                return Problem("Entity set 'CervejaContext.Rotulo'  is null.");
            }
            var rotulo = await _context.Rotulo.FindAsync(id);
            if (rotulo != null)
            {
                _context.Rotulo.Remove(rotulo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RotuloExists(int id)
        {
          return (_context.Rotulo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
