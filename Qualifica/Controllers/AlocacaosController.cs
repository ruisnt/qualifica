using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qualifica.Models;

namespace Qualifica.Controllers
{
    public class AlocacaosController : Controller
    {
        private readonly QualificaContext _context;

        public AlocacaosController(QualificaContext context)
        {
            _context = context;
        }

        // GET: Alocacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alocacao.ToListAsync());
        }

        // GET: Alocacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alocacao = await _context.Alocacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (alocacao == null)
            {
                return NotFound();
            }

            return View(alocacao);
        }

        // GET: Alocacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alocacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,idPosto,idUsuario,Inicio,Termino")] Alocacao alocacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alocacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alocacao);
        }

        // GET: Alocacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alocacao = await _context.Alocacao.FindAsync(id);
            if (alocacao == null)
            {
                return NotFound();
            }
            return View(alocacao);
        }

        // POST: Alocacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,idPosto,idUsuario,Inicio,Termino")] Alocacao alocacao)
        {
            if (id != alocacao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alocacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlocacaoExists(alocacao.id))
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
            return View(alocacao);
        }

        // GET: Alocacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alocacao = await _context.Alocacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (alocacao == null)
            {
                return NotFound();
            }

            return View(alocacao);
        }

        // POST: Alocacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alocacao = await _context.Alocacao.FindAsync(id);
            _context.Alocacao.Remove(alocacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlocacaoExists(int id)
        {
            return _context.Alocacao.Any(e => e.id == id);
        }
    }
}
