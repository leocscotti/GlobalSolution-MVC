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
    public class DenunciasController : Controller
    {
        private readonly VisionaryBlueDbContext _context;

        public DenunciasController(VisionaryBlueDbContext context)
        {
            _context = context;
        }

        // GET: Denuncias
        public async Task<IActionResult> Index()
        {
            var visionaryBlueDbContext = _context.Denuncias.Include(d => d.Localizacao).Include(d => d.Usuario);
            return View(await visionaryBlueDbContext.ToListAsync());
        }

        // GET: Denuncias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncias
                .Include(d => d.Localizacao)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.DenunciaId == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // GET: Denuncias/Create
        public IActionResult Create()
        {
            ViewData["LocalizacaoId"] = new SelectList(_context.Locais, "LocalizacaoId", "CEP");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Denuncias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DenunciaId,TipoPoluicao,DataHora,Descricao,Status,UsuarioId,LocalizacaoId")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denuncia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalizacaoId"] = new SelectList(_context.Locais, "LocalizacaoId", "CEP", denuncia.LocalizacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", denuncia.UsuarioId);
            return View(denuncia);
        }

        // GET: Denuncias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncias.FindAsync(id);
            if (denuncia == null)
            {
                return NotFound();
            }
            ViewData["LocalizacaoId"] = new SelectList(_context.Locais, "LocalizacaoId", "CEP", denuncia.LocalizacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", denuncia.UsuarioId);
            return View(denuncia);
        }

        // POST: Denuncias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DenunciaId,TipoPoluicao,DataHora,Descricao,Status,UsuarioId,LocalizacaoId")] Denuncia denuncia)
        {
            if (id != denuncia.DenunciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denuncia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaExists(denuncia.DenunciaId))
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
            ViewData["LocalizacaoId"] = new SelectList(_context.Locais, "LocalizacaoId", "CEP", denuncia.LocalizacaoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", denuncia.UsuarioId);
            return View(denuncia);
        }

        // GET: Denuncias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncias
                .Include(d => d.Localizacao)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.DenunciaId == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // POST: Denuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denuncia = await _context.Denuncias.FindAsync(id);
            if (denuncia != null)
            {
                _context.Denuncias.Remove(denuncia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciaExists(int id)
        {
            return _context.Denuncias.Any(e => e.DenunciaId == id);
        }
    }
}
