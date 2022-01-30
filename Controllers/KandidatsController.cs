using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autoskola_Mia.Data;
using Autoskola_Mia.Models;

namespace Autoskola_Mia.Controllers
{
    public class KandidatsController : Controller
    {
        private readonly AutoskolaContext _context;

        public KandidatsController(AutoskolaContext context)
        {
            _context = context;
        }

        // GET: Kandidats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kandidati.ToListAsync());
        }

        // GET: Kandidats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kandidat = await _context.Kandidati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kandidat == null)
            {
                return NotFound();
            }

            return View(kandidat);
        }

        // GET: Kandidats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kandidats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Spol,Email")] Kandidat kandidat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kandidat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kandidat);
        }

        // GET: Kandidats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kandidat = await _context.Kandidati.FindAsync(id);
            if (kandidat == null)
            {
                return NotFound();
            }
            return View(kandidat);
        }

        // POST: Kandidats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Spol,Email")] Kandidat kandidat)
        {
            if (id != kandidat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kandidat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KandidatExists(kandidat.Id))
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
            return View(kandidat);
        }

        // GET: Kandidats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kandidat = await _context.Kandidati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kandidat == null)
            {
                return NotFound();
            }

            return View(kandidat);
        }

        // POST: Kandidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kandidat = await _context.Kandidati.FindAsync(id);
            _context.Kandidati.Remove(kandidat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KandidatExists(int id)
        {
            return _context.Kandidati.Any(e => e.Id == id);
        }
    }
}
