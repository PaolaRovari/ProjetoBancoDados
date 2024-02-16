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
    public class LugarVisitaController : Controller
    {
        private readonly Contexto _context;

        public LugarVisitaController(Contexto context)
        {
            _context = context;
        }

        // GET: LugarVisita
        public async Task<IActionResult> Index()
        {
            var contexto = _context.LugarVisita.Include(l => l.Lugar).Include(l => l.Visita);
            return View(await contexto.ToListAsync());
        }

        // GET: LugarVisita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LugarVisita == null)
            {
                return NotFound();
            }

            var lugarVisita = await _context.LugarVisita
                .Include(l => l.Lugar)
                .Include(l => l.Visita)
                .FirstOrDefaultAsync(m => m.LugarVisitaId == id);
            if (lugarVisita == null)
            {
                return NotFound();
            }

            return View(lugarVisita);
        }
        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.LugarVisita == null)
            {
                return NotFound();
            }

            var LugarVisita = await _context.LugarVisita
                .Include(c => c.Visita)
                .Include(c => c.Lugar)
                .FirstOrDefaultAsync(m => m.LugarVisitaId == id);

            LugarVisita.ObraDeArte = await _context.ObraDeArte
                                        .Include(c => c.Artista)                                        
                                        .Where(c => c.LugarId == LugarVisita.LugarId).ToListAsync();

            if (LugarVisita == null)
            {
                return NotFound();
            }

            return View(LugarVisita);
        }

        // GET: LugarVisita/Create
        public IActionResult Create()
        {
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar");
            ViewData["VisitaId"] = new SelectList(_context.Visita, "VisitaId", "DataVisita");
            return View();
        }

        // POST: LugarVisita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LugarVisitaId,VisitaId,LugarId")] LugarVisita lugarVisita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lugarVisita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar", lugarVisita.LugarId);
            ViewData["VisitaId"] = new SelectList(_context.Visita, "VisitaId", "DataVisita", lugarVisita.VisitaId);
            return View(lugarVisita);
        }

        // GET: LugarVisita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LugarVisita == null)
            {
                return NotFound();
            }

            var lugarVisita = await _context.LugarVisita.FindAsync(id);
            if (lugarVisita == null)
            {
                return NotFound();
            }
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar", lugarVisita.LugarId);
            ViewData["VisitaId"] = new SelectList(_context.Visita, "VisitaId", "DataVisita", lugarVisita.VisitaId);
            return View(lugarVisita);
        }

        // POST: LugarVisita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LugarVisitaId,VisitaId,LugarId")] LugarVisita lugarVisita)
        {
            if (id != lugarVisita.LugarVisitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lugarVisita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LugarVisitaExists(lugarVisita.LugarVisitaId))
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
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar", lugarVisita.LugarId);
            ViewData["VisitaId"] = new SelectList(_context.Visita, "VisitaId", "DataVisita", lugarVisita.VisitaId);
            return View(lugarVisita);
        }

        // GET: LugarVisita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LugarVisita == null)
            {
                return NotFound();
            }

            var lugarVisita = await _context.LugarVisita
                .Include(l => l.Lugar)
                .Include(l => l.Visita)
                .FirstOrDefaultAsync(m => m.LugarVisitaId == id);
            if (lugarVisita == null)
            {
                return NotFound();
            }

            return View(lugarVisita);
        }

        // POST: LugarVisita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LugarVisita == null)
            {
                return Problem("Entity set 'Contexto.LugarVisita'  is null.");
            }
            var lugarVisita = await _context.LugarVisita.FindAsync(id);
            if (lugarVisita != null)
            {
                _context.LugarVisita.Remove(lugarVisita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LugarVisitaExists(int id)
        {
          return (_context.LugarVisita?.Any(e => e.LugarVisitaId == id)).GetValueOrDefault();
        }
    }
}
