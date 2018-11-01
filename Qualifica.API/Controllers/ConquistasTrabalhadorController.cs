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
    public class ConquistasTrabalhadorController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public ConquistasTrabalhadorController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/ConquistasTrabalhador
        [HttpGet]
        public IEnumerable<ConquistaTrabalhador> GetConquistaTrabalhador()
        {
            return _context.ConquistaTrabalhador;
        }

        // GET: api/ConquistasTrabalhador/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConquistaTrabalhador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conquistaTrabalhador = await _context.ConquistaTrabalhador.FindAsync(id);

            if (conquistaTrabalhador == null)
            {
                return NotFound();
            }

            return Ok(conquistaTrabalhador);
        }

        // PUT: api/ConquistasTrabalhador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConquistaTrabalhador([FromRoute] int id, [FromBody] ConquistaTrabalhador conquistaTrabalhador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conquistaTrabalhador.id)
            {
                return BadRequest();
            }

            _context.Entry(conquistaTrabalhador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConquistaTrabalhadorExists(id))
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

        // POST: api/ConquistasTrabalhador
        [HttpPost]
        public async Task<IActionResult> PostConquistaTrabalhador([FromBody] ConquistaTrabalhador conquistaTrabalhador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConquistaTrabalhador.Add(conquistaTrabalhador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConquistaTrabalhador", new { id = conquistaTrabalhador.id }, conquistaTrabalhador);
        }

        // DELETE: api/ConquistasTrabalhador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConquistaTrabalhador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conquistaTrabalhador = await _context.ConquistaTrabalhador.FindAsync(id);
            if (conquistaTrabalhador == null)
            {
                return NotFound();
            }

            _context.ConquistaTrabalhador.Remove(conquistaTrabalhador);
            await _context.SaveChangesAsync();

            return Ok(conquistaTrabalhador);
        }

        private bool ConquistaTrabalhadorExists(int id)
        {
            return _context.ConquistaTrabalhador.Any(e => e.id == id);
        }
    }
}