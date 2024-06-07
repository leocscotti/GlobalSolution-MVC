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
    public class NotificacoesController : Controller
    {
        private readonly VisionaryBlueDbContext _context;

        public NotificacoesController(VisionaryBlueDbContext context)
        {
            _context = context;
        }

        // GET: Notificacoes
        public async Task<IActionResult> Index()
        {
            var visionaryBlueDbContext = _context.Notificacoes.Include(n => n.Comentario);
            return View(await visionaryBlueDbContext.ToListAsync());
        }

        // GET: Notificacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes
                .Include(n => n.Comentario)
                .FirstOrDefaultAsync(m => m.NotificacaoId == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // GET: Notificacoes/Create
        public IActionResult Create()
        {
            ViewData["ComentarioId"] = new SelectList(_context.Comentarios, "ComentarioId", "Descricao");
            return View();
        }

        // POST: Notificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotificacaoId,Descricao,Status,Tipo,ComentarioId")] Notificacao notificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComentarioId"] = new SelectList(_context.Comentarios, "ComentarioId", "Descricao", notificacao.ComentarioId);
            return View(notificacao);
        }

        // GET: Notificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao == null)
            {
                return NotFound();
            }
            ViewData["ComentarioId"] = new SelectList(_context.Comentarios, "ComentarioId", "Descricao", notificacao.ComentarioId);
            return View(notificacao);
        }

        // POST: Notificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotificacaoId,Descricao,Status,Tipo,ComentarioId")] Notificacao notificacao)
        {
            if (id != notificacao.NotificacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacaoExists(notificacao.NotificacaoId))
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
            ViewData["ComentarioId"] = new SelectList(_context.Comentarios, "ComentarioId", "Descricao", notificacao.ComentarioId);
            return View(notificacao);
        }

        // GET: Notificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes
                .Include(n => n.Comentario)
                .FirstOrDefaultAsync(m => m.NotificacaoId == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // POST: Notificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacaoExists(int id)
        {
            return _context.Notificacoes.Any(e => e.NotificacaoId == id);
        }
    }
}
