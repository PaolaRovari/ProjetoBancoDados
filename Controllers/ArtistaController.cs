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
    public class ArtistaController : Controller
    {
        private readonly Contexto _context;

        public ArtistaController(Contexto context)
        {
            _context = context;
        }

        // GET: Artista
        public async Task<IActionResult> Index()
        {
              return _context.Artista != null ? 
                          View(await _context.Artista.ToListAsync()) :
                          Problem("Entity set 'Contexto.Artista'  is null.");
        }

        // GET: Artista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artista == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista
                .FirstOrDefaultAsync(m => m.ArtistaId == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // GET: Artista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistaId,NomeArtista,NacionalidadeArtista,DataNascimentoFalecimento")] Artista artista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artista);
        }

        // GET: Artista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artista == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        // POST: Artista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistaId,NomeArtista,NacionalidadeArtista,DataNascimentoFalecimento")] Artista artista)
        {
            if (id != artista.ArtistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistaExists(artista.ArtistaId))
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
            return View(artista);
        }

        // GET: Artista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artista == null)
            {
                return NotFound();
            }

            var artista = await _context.Artista
                .FirstOrDefaultAsync(m => m.ArtistaId == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }

        // POST: Artista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artista == null)
            {
                return Problem("Entity set 'Contexto.Artista'  is null.");
            }
            var artista = await _context.Artista.FindAsync(id);
            if (artista != null)
            {
                _context.Artista.Remove(artista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistaExists(int id)
        {
          return (_context.Artista?.Any(e => e.ArtistaId == id)).GetValueOrDefault();
        }
    }
}
