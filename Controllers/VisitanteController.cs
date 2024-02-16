using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBancoDados.Models;

namespace ProjetoBancoDados.Controllers
{
    public class VisitanteController : Controller
    {
        private readonly Contexto _context;

        public VisitanteController(Contexto context)
        {
            _context = context;
        }

        // GET: Visitante
        public async Task<IActionResult> Index()
        {
              return _context.Visitante != null ? 
                          View(await _context.Visitante.ToListAsync()) :
                          Problem("Entity set 'Contexto.Visitante'  is null.");
        }

        // GET: Visitante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Visitante == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitante
                .FirstOrDefaultAsync(m => m.VisitanteId == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        // GET: Visitante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitanteId,NomeVisitante,EmailVisitante,TelefoneVisitante")] Visitante visitante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitante);
        }

        // GET: Visitante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Visitante == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitante.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }
            return View(visitante);
        }

        // POST: Visitante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitanteId,NomeVisitante,EmailVisitante,TelefoneVisitante")] Visitante visitante)
        {
            if (id != visitante.VisitanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitanteExists(visitante.VisitanteId))
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
            return View(visitante);
        }

        // GET: Visitante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Visitante == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitante
                .FirstOrDefaultAsync(m => m.VisitanteId == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        // POST: Visitante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Visitante == null)
            {
                return Problem("Entity set 'Contexto.Visitante'  is null.");
            }
            var visitante = await _context.Visitante.FindAsync(id);
            if (visitante != null)
            {
                _context.Visitante.Remove(visitante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitanteExists(int id)
        {
          return (_context.Visitante?.Any(e => e.VisitanteId == id)).GetValueOrDefault();
        }
    }
}
