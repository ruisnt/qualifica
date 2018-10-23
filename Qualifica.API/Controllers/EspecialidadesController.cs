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
    public class EspecialidadesController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public EspecialidadesController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Especialidades
        [HttpGet]
        public IEnumerable<Especialidade> GetEspecialidade()
        {
            return _context.Especialidade;
        }

        // GET: api/Especialidades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspecialidade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidade = await _context.Especialidade.FindAsync(id);

            if (especialidade == null)
            {
                return NotFound();
            }

            return Ok(especialidade);
        }

        // PUT: api/Especialidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidade([FromRoute] int id, [FromBody] Especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialidade.id)
            {
                return BadRequest();
            }

            _context.Entry(especialidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadeExists(id))
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

        // POST: api/Especialidades
        [HttpPost]
        public async Task<IActionResult> PostEspecialidade([FromBody] Especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Especialidade.Add(especialidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidade", new { id = especialidade.id }, especialidade);
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidade = await _context.Especialidade.FindAsync(id);
            if (especialidade == null)
            {
                return NotFound();
            }

            _context.Especialidade.Remove(especialidade);
            await _context.SaveChangesAsync();

            return Ok(especialidade);
        }

        private bool EspecialidadeExists(int id)
        {
            return _context.Especialidade.Any(e => e.id == id);
        }
    }
}