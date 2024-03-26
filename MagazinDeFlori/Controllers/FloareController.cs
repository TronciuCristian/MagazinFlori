using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinDeFlori.Models;

namespace MagazinDeFlori.Controllers
{
    public class FloareController : Controller
    {
        private readonly FloareContext _context;

        public FloareController(FloareContext context)
        {
            _context = context;
        }

        // GET: Floare
        public async Task<IActionResult> Index()
        {
            return View(await _context.Floarea.ToListAsync());
        }

        // GET: Floare/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floare = await _context.Floarea
                .FirstOrDefaultAsync(m => m.CodFloare == id);
            if (floare == null)
            {
                return NotFound();
            }

            return View(floare);
        }

        // GET: Floare/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Floare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodFloare,Denumire,Descriere,Pret,Imagime")] Floare floare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(floare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(floare);
        }

        // GET: Floare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floare = await _context.Floarea.FindAsync(id);
            if (floare == null)
            {
                return NotFound();
            }
            return View(floare);
        }

        // POST: Floare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodFloare,Denumire,Descriere,Pret,Imagime")] Floare floare)
        {
            if (id != floare.CodFloare)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(floare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FloareExists(floare.CodFloare))
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
            return View(floare);
        }

        // GET: Floare/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floare = await _context.Floarea
                .FirstOrDefaultAsync(m => m.CodFloare == id);
            if (floare == null)
            {
                return NotFound();
            }

            return View(floare);
        }

        // POST: Floare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var floare = await _context.Floarea.FindAsync(id);
            if (floare != null)
            {
                _context.Floarea.Remove(floare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FloareExists(int id)
        {
            return _context.Floarea.Any(e => e.CodFloare == id);
        }
    }
}
