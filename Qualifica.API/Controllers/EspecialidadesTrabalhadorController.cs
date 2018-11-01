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
    public class EspecialidadesTrabalhadorController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public EspecialidadesTrabalhadorController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/EspecialidadesTrabalhador
        [HttpGet]
        public IEnumerable<EspecialidadeTrabalhador> GetEspecialidadeTrabalhador()
        {
            return _context.EspecialidadeTrabalhador;
        }

        // GET: api/EspecialidadesTrabalhador/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspecialidadeTrabalhador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidadeTrabalhador = await _context.EspecialidadeTrabalhador.FindAsync(id);

            if (especialidadeTrabalhador == null)
            {
                return NotFound();
            }

            return Ok(especialidadeTrabalhador);
        }

        // PUT: api/EspecialidadesTrabalhador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidadeTrabalhador([FromRoute] int id, [FromBody] EspecialidadeTrabalhador especialidadeTrabalhador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialidadeTrabalhador.id)
            {
                return BadRequest();
            }

            _context.Entry(especialidadeTrabalhador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadeTrabalhadorExists(id))
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

        // POST: api/EspecialidadesTrabalhador
        [HttpPost]
        public async Task<IActionResult> PostEspecialidadeTrabalhador([FromBody] EspecialidadeTrabalhador especialidadeTrabalhador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EspecialidadeTrabalhador.Add(especialidadeTrabalhador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidadeTrabalhador", new { id = especialidadeTrabalhador.id }, especialidadeTrabalhador);
        }

        // DELETE: api/EspecialidadesTrabalhador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidadeTrabalhador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidadeTrabalhador = await _context.EspecialidadeTrabalhador.FindAsync(id);
            if (especialidadeTrabalhador == null)
            {
                return NotFound();
            }

            _context.EspecialidadeTrabalhador.Remove(especialidadeTrabalhador);
            await _context.SaveChangesAsync();

            return Ok(especialidadeTrabalhador);
        }

        private bool EspecialidadeTrabalhadorExists(int id)
        {
            return _context.EspecialidadeTrabalhador.Any(e => e.id == id);
        }
    }
}