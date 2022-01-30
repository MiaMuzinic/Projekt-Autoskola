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
    public class AutoskolasController : Controller
    {
        private readonly AutoskolaContext _context;

        public AutoskolasController(AutoskolaContext context)
        {
            _context = context;
        }

        // GET: Autoskolas
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AdressSortParm"] = String.IsNullOrEmpty(sortOrder) ? "adress_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var autoskole = from a in _context.Autoskole
                            select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                autoskole = autoskole.Where(a => a.Naziv.Contains(searchString)
                                       || a.Adresa.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    autoskole = autoskole.OrderByDescending(a => a.Naziv);
                    break;
                case "Adresa":
                    autoskole = autoskole.OrderBy(a => a.Adresa);
                    break;
                case "adress_desc":
                    autoskole = autoskole.OrderByDescending(a => a.Adresa);
                    break;
                default:
                    autoskole = autoskole.OrderBy(a => a.Naziv);
                    break;
            }
            return View(await autoskole.AsNoTracking().ToListAsync());
        }
    

        // GET: Autoskolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoskola = await _context.Autoskole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoskola == null)
            {
                return NotFound();
            }

            return View(autoskola);
        }

        // GET: Autoskolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autoskolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Adresa,Email")] Autoskola autoskola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoskola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoskola);
        }

        // GET: Autoskolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoskola = await _context.Autoskole.FindAsync(id);
            if (autoskola == null)
            {
                return NotFound();
            }
            return View(autoskola);
        }

        // POST: Autoskolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Adresa,Email")] Autoskola autoskola)
        {
            if (id != autoskola.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoskola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoskolaExists(autoskola.Id))
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
            return View(autoskola);
        }

        // GET: Autoskolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoskola = await _context.Autoskole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoskola == null)
            {
                return NotFound();
            }

            return View(autoskola);
        }

        // POST: Autoskolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoskola = await _context.Autoskole.FindAsync(id);
            _context.Autoskole.Remove(autoskola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoskolaExists(int id)
        {
            return _context.Autoskole.Any(e => e.Id == id);
        }
    }
}
