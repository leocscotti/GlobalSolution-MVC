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
    public class ResiduosController : Controller
    {
        private readonly VisionaryBlueDbContext _context;

        public ResiduosController(VisionaryBlueDbContext context)
        {
            _context = context;
        }

        // GET: Residuos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Residuos.ToListAsync());
        }

        // GET: Residuos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residuo = await _context.Residuos
                .FirstOrDefaultAsync(m => m.ResiduoId == id);
            if (residuo == null)
            {
                return NotFound();
            }

            return View(residuo);
        }

        // GET: Residuos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Residuos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResiduoId,Descricao,Tipo")] Residuo residuo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(residuo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(residuo);
        }

        // GET: Residuos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residuo = await _context.Residuos.FindAsync(id);
            if (residuo == null)
            {
                return NotFound();
            }
            return View(residuo);
        }

        // POST: Residuos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResiduoId,Descricao,Tipo")] Residuo residuo)
        {
            if (id != residuo.ResiduoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residuo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResiduoExists(residuo.ResiduoId))
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
            return View(residuo);
        }

        // GET: Residuos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residuo = await _context.Residuos
                .FirstOrDefaultAsync(m => m.ResiduoId == id);
            if (residuo == null)
            {
                return NotFound();
            }

            return View(residuo);
        }

        // POST: Residuos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var residuo = await _context.Residuos.FindAsync(id);
            if (residuo != null)
            {
                _context.Residuos.Remove(residuo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResiduoExists(int id)
        {
            return _context.Residuos.Any(e => e.ResiduoId == id);
        }
    }
}
