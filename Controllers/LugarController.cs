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
    public class LugarController : Controller
    {
        private readonly Contexto _context;

        public LugarController(Contexto context)
        {
            _context = context;
        }

        // GET: Lugar
        public async Task<IActionResult> Index()
        {
              return _context.Lugar != null ? 
                          View(await _context.Lugar.ToListAsync()) :
                          Problem("Entity set 'Contexto.Lugar'  is null.");
        }

        // GET: Lugar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lugar == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugar
                .FirstOrDefaultAsync(m => m.LugarId == id);
            if (lugar == null)
            {
                return NotFound();
            }

            return View(lugar);
        }

        // GET: Lugar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lugar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LugarId,NomeLugar,HorarioFuncionamento")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lugar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lugar);
        }

        // GET: Lugar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lugar == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugar.FindAsync(id);
            if (lugar == null)
            {
                return NotFound();
            }
            return View(lugar);
        }

        // POST: Lugar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LugarId,NomeLugar,HorarioFuncionamento")] Lugar lugar)
        {
            if (id != lugar.LugarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lugar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LugarExists(lugar.LugarId))
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
            return View(lugar);
        }

        // GET: Lugar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lugar == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugar
                .FirstOrDefaultAsync(m => m.LugarId == id);
            if (lugar == null)
            {
                return NotFound();
            }

            return View(lugar);
        }

        // POST: Lugar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lugar == null)
            {
                return Problem("Entity set 'Contexto.Lugar'  is null.");
            }
            var lugar = await _context.Lugar.FindAsync(id);
            if (lugar != null)
            {
                _context.Lugar.Remove(lugar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LugarExists(int id)
        {
          return (_context.Lugar?.Any(e => e.LugarId == id)).GetValueOrDefault();
        }
    }
}
