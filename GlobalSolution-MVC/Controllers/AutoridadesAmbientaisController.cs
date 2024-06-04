using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalSolution_MVC.Models;
using GlobalSolution_MVC.Persistencia;

namespace GlobalSolution_MVC.Controllers
{
    public class AutoridadesAmbientaisController : Controller
    {
        private readonly VisionaryBlueDbContext _context;

        public AutoridadesAmbientaisController(VisionaryBlueDbContext context)
        {
            _context = context;
        }

        // GET: AutoridadesAmbientais
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutoridadesAmbientais.ToListAsync());
        }

        // GET: AutoridadesAmbientais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoridadeAmbiental = await _context.AutoridadesAmbientais
                .FirstOrDefaultAsync(m => m.AutoridadeId == id);
            if (autoridadeAmbiental == null)
            {
                return NotFound();
            }

            return View(autoridadeAmbiental);
        }

        // GET: AutoridadesAmbientais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutoridadesAmbientais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoridadeId,Nome,Email")] AutoridadeAmbiental autoridadeAmbiental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoridadeAmbiental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoridadeAmbiental);
        }

        // GET: AutoridadesAmbientais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoridadeAmbiental = await _context.AutoridadesAmbientais.FindAsync(id);
            if (autoridadeAmbiental == null)
            {
                return NotFound();
            }
            return View(autoridadeAmbiental);
        }

        // POST: AutoridadesAmbientais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoridadeId,Nome,Email")] AutoridadeAmbiental autoridadeAmbiental)
        {
            if (id != autoridadeAmbiental.AutoridadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoridadeAmbiental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoridadeAmbientalExists(autoridadeAmbiental.AutoridadeId))
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
            return View(autoridadeAmbiental);
        }

        // GET: AutoridadesAmbientais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoridadeAmbiental = await _context.AutoridadesAmbientais
                .FirstOrDefaultAsync(m => m.AutoridadeId == id);
            if (autoridadeAmbiental == null)
            {
                return NotFound();
            }

            return View(autoridadeAmbiental);
        }

        // POST: AutoridadesAmbientais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoridadeAmbiental = await _context.AutoridadesAmbientais.FindAsync(id);
            if (autoridadeAmbiental != null)
            {
                _context.AutoridadesAmbientais.Remove(autoridadeAmbiental);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoridadeAmbientalExists(int id)
        {
            return _context.AutoridadesAmbientais.Any(e => e.AutoridadeId == id);
        }
    }
}
