using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qualifica.API.Models;

namespace Qualifica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConquistasController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public ConquistasController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Conquistas
        [HttpGet]
        public IEnumerable<Conquista> GetConquista()
        {
            return _context.Conquista;
        }

        // GET: api/Conquistas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConquista([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conquista = await _context.Conquista.FindAsync(id);

            if (conquista == null)
            {
                return NotFound();
            }

            return Ok(conquista);
        }

        // PUT: api/Conquistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConquista([FromRoute] int id, [FromBody] Conquista conquista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conquista.id)
            {
                return BadRequest();
            }

            _context.Entry(conquista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConquistaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Conquistas
        [HttpPost]
        public async Task<IActionResult> PostConquista([FromBody] Conquista conquista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Conquista.Add(conquista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConquista", new { id = conquista.id }, conquista);
        }

        // DELETE: api/Conquistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConquista([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conquista = await _context.Conquista.FindAsync(id);
            if (conquista == null)
            {
                return NotFound();
            }

            _context.Conquista.Remove(conquista);
            await _context.SaveChangesAsync();

            return Ok(conquista);
        }

        private bool ConquistaExists(int id)
        {
            return _context.Conquista.Any(e => e.id == id);
        }
    }
}