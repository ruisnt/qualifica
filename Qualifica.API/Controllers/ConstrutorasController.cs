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
    public class ConstrutorasController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public ConstrutorasController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Construtoras
        [HttpGet]
        public IEnumerable<Construtora> GetConstrutora()
        {
            return _context.Construtora;
        }

        // GET: api/Construtoras/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConstrutora([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var construtora = await _context.Construtora.FindAsync(id);

            if (construtora == null)
            {
                return NotFound();
            }

            return Ok(construtora);
        }

        // PUT: api/Construtoras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstrutora([FromRoute] int id, [FromBody] Construtora construtora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != construtora.id)
            {
                return BadRequest();
            }

            _context.Entry(construtora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstrutoraExists(id))
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

        // POST: api/Construtoras
        [HttpPost]
        public async Task<IActionResult> PostConstrutora([FromBody] Construtora construtora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Construtora.Add(construtora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstrutora", new { id = construtora.id }, construtora);
        }

        // DELETE: api/Construtoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstrutora([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var construtora = await _context.Construtora.FindAsync(id);
            if (construtora == null)
            {
                return NotFound();
            }

            _context.Construtora.Remove(construtora);
            await _context.SaveChangesAsync();

            return Ok(construtora);
        }

        private bool ConstrutoraExists(int id)
        {
            return _context.Construtora.Any(e => e.id == id);
        }
    }
}