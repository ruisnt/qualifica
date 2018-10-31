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
    public class TrabalhadorsController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public TrabalhadorsController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Trabalhadors
        [HttpGet]
        public IEnumerable<Trabalhador> GetTrabalhador()
        {
            return _context.Trabalhador;
        }

        // GET: api/Trabalhadors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrabalhador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trabalhador = await _context.Trabalhador.FindAsync(id);

            if (trabalhador == null)
            {
                return NotFound();
            }

            return Ok(trabalhador);
        }

        // PUT: api/Trabalhadors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabalhador([FromRoute] int id, [FromBody] Trabalhador trabalhador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trabalhador.id)
            {
                return BadRequest();
            }

            _context.Entry(trabalhador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabalhadorExists(id))
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

        // POST: api/Trabalhadors
        [HttpPost]
        public async Task<IActionResult> PostTrabalhador([FromBody] Trabalhador trabalhador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Trabalhador.Add(trabalhador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabalhador", new { id = trabalhador.id }, trabalhador);
        }

        // DELETE: api/Trabalhadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabalhador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trabalhador = await _context.Trabalhador.FindAsync(id);
            if (trabalhador == null)
            {
                return NotFound();
            }

            _context.Trabalhador.Remove(trabalhador);
            await _context.SaveChangesAsync();

            return Ok(trabalhador);
        }

        private bool TrabalhadorExists(int id)
        {
            return _context.Trabalhador.Any(e => e.id == id);
        }
    }
}