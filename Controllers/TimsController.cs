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
    public class TimsController : Controller
    {
        private readonly AutoskolaContext _context;

        public TimsController(AutoskolaContext context)
        {
            _context = context;
        }

        // GET: Tims
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Timovi.ToListAsync());
            var autoskolaContext = _context.Timovi.Include(t => t.Automobil).Include(t => t.Zaposlenik).Include(t => t.Autoskola).Include(t => t.Kandidat);
            return View(await autoskolaContext.ToListAsync());
        }

        // GET: Tims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tim = await _context.Timovi
                .Include(t => t.Automobil)
                .Include(t => t.Autoskola)
                .Include(t => t.Kandidat)
                .Include(t => t.Zaposlenik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tim == null)
            {
                return NotFound();
            }

            return View(tim);
        }

        // GET: Tims/Create
        public IActionResult Create()
        {
            //return View();
            ViewData["Automobil_Id"] = new SelectList(_context.Autoskole, "Id", "Id");
            ViewData["Autoskola_Id"] = new SelectList(_context.Autoskole, "Id", "Id");
            ViewData["Kandidat_Id"] = new SelectList(_context.Autoskole, "Id", "Id");
            ViewData["Zaposlenik_Id"] = new SelectList(_context.Zaposlenici, "Id", "Id");
            return View();
        }

        // POST: Tims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Automobil_Id,Autoskola_Id,Kandidat_Id,Zaposlenik_Id")] Tim tim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(tim);
            ViewData["Automobil_Id"] = new SelectList(_context.Automobili, "Id", "Id", tim.Automobil_Id);
            ViewData["Autoskola_Id"] = new SelectList(_context.Autoskole, "Id", "Id", tim.Autoskola_Id);
            ViewData["Kandidat_Id"] = new SelectList(_context.Kandidati, "Id", "Id", tim.Kandidat_Id);
            ViewData["Zaposlenik_Id"] = new SelectList(_context.Zaposlenici, "Id", "Id", tim.Zaposlenik_Id);
            return View(tim);
        }

        // GET: Tims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tim = await _context.Timovi.FindAsync(id);
            if (tim == null)
            {
                return NotFound();
            }
            //return View(tim);
            ViewData["Automobil_Id"] = new SelectList(_context.Automobili, "Id", "Id", tim.Automobil_Id);
            ViewData["Autoskola_Id"] = new SelectList(_context.Autoskole, "Id", "Id", tim.Autoskola_Id);
            ViewData["Kandidat_Id"] = new SelectList(_context.Kandidati, "Id", "Id", tim.Kandidat_Id);
            ViewData["Zaposlenik_Id"] = new SelectList(_context.Zaposlenici, "Id", "Id", tim.Zaposlenik_Id);
            return View(tim);
        }

        // POST: Tims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Automobil_Id,Autoskola_Id,Kandidat_Id,Zaposlenik_Id")] Tim tim)
        {
            if (id != tim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimExists(tim.Id))
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
            //return View(tim);
            ViewData["Automobil_Id"] = new SelectList(_context.Automobili, "Id", "Id", tim.Automobil_Id);
            ViewData["Autoskola_Id"] = new SelectList(_context.Autoskole, "Id", "Id", tim.Autoskola_Id);
            ViewData["Kandidat_Id"] = new SelectList(_context.Kandidati, "Id", "Id", tim.Kandidat_Id);
            ViewData["Zaposlenik_Id"] = new SelectList(_context.Zaposlenici, "Id", "Id", tim.Zaposlenik_Id);
            return View(tim);
        }

        // GET: Tims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tim = await _context.Timovi
                .Include(t => t.Automobil)
                .Include(t => t.Autoskola)
                .Include(t => t.Kandidat)
                .Include(t => t.Zaposlenik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tim == null)
            {
                return NotFound();
            }

            return View(tim);
        }

        // POST: Tims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tim = await _context.Timovi.FindAsync(id);
            _context.Timovi.Remove(tim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimExists(int id)
        {
            return _context.Timovi.Any(e => e.Id == id);
        }
    }
}
