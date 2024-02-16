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
    public class ObraDeArteController : Controller
    {
        private readonly Contexto _context;

        public ObraDeArteController(Contexto context)
        {
            _context = context;
        }

        // GET: ObraDeArte
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ObraDeArte.Include(o => o.Artista).Include(o => o.Lugar);
            return View(await contexto.ToListAsync());
        }

        // GET: ObraDeArte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ObraDeArte == null)
            {
                return NotFound();
            }

            var obraDeArte = await _context.ObraDeArte
                .Include(o => o.Artista)
                .Include(o => o.Lugar)
                .FirstOrDefaultAsync(m => m.ObraDeArteId == id);
            if (obraDeArte == null)
            {
                return NotFound();
            }

            return View(obraDeArte);
        }

        // GET: ObraDeArte/Create
        public IActionResult Create()
        {
            ViewData["ArtistaId"] = new SelectList(_context.Artista, "ArtistaId", "NomeArtista");
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar");
            return View();
        }

        // POST: ObraDeArte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObraDeArteId,NomeObra,DataCriacaoObra,TecnicaObra,ValorObra,ArtistaId,LugarId")] ObraDeArte obraDeArte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obraDeArte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artista, "ArtistaId", "NomeArtista", obraDeArte.ArtistaId);
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar", obraDeArte.LugarId);
            return View(obraDeArte);
        }

        // GET: ObraDeArte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ObraDeArte == null)
            {
                return NotFound();
            }

            var obraDeArte = await _context.ObraDeArte.FindAsync(id);
            if (obraDeArte == null)
            {
                return NotFound();
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artista, "ArtistaId", "NomeArtista", obraDeArte.ArtistaId);
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar", obraDeArte.LugarId);
            return View(obraDeArte);
        }

        // POST: ObraDeArte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObraDeArteId,NomeObra,DataCriacaoObra,TecnicaObra,ValorObra,ArtistaId,LugarId")] ObraDeArte obraDeArte)
        {
            if (id != obraDeArte.ObraDeArteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obraDeArte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraDeArteExists(obraDeArte.ObraDeArteId))
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
            ViewData["ArtistaId"] = new SelectList(_context.Artista, "ArtistaId", "NomeArtista", obraDeArte.ArtistaId);
            ViewData["LugarId"] = new SelectList(_context.Lugar, "LugarId", "NomeLugar", obraDeArte.LugarId);
            return View(obraDeArte);
        }

        // GET: ObraDeArte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ObraDeArte == null)
            {
                return NotFound();
            }

            var obraDeArte = await _context.ObraDeArte
                .Include(o => o.Artista)
                .Include(o => o.Lugar)
                .FirstOrDefaultAsync(m => m.ObraDeArteId == id);
            if (obraDeArte == null)
            {
                return NotFound();
            }

            return View(obraDeArte);
        }

        // POST: ObraDeArte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ObraDeArte == null)
            {
                return Problem("Entity set 'Contexto.ObraDeArte'  is null.");
            }
            var obraDeArte = await _context.ObraDeArte.FindAsync(id);
            if (obraDeArte != null)
            {
                _context.ObraDeArte.Remove(obraDeArte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraDeArteExists(int id)
        {
          return (_context.ObraDeArte?.Any(e => e.ObraDeArteId == id)).GetValueOrDefault();
        }
    }
}
