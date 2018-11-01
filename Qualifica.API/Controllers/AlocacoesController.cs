using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qualifica.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualifica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlocacoesController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public AlocacoesController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Alocacoes
        [HttpGet]
        public IEnumerable<Alocacao> GetAlocacao()
        {
            return _context.Alocacao;
        }

        // GET: api/Alocacoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlocacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alocacao = await _context.Alocacao.FindAsync(id);

            if (alocacao == null)
            {
                return NotFound();
            }

            return Ok(alocacao);
        }

        // PUT: api/Alocacoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlocacao([FromRoute] int id, [FromBody] Alocacao alocacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alocacao.id)
            {
                return BadRequest();
            }

            _context.Entry(alocacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlocacaoExists(id))
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

        // POST: api/Alocacoes
        [HttpPost]
        public async Task<IActionResult> PostAlocacao([FromBody] Alocacao alocacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Alocacao.Add(alocacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlocacao", new { id = alocacao.id }, alocacao);
        }

        // DELETE: api/Alocacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlocacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alocacao = await _context.Alocacao.FindAsync(id);
            if (alocacao == null)
            {
                return NotFound();
            }

            _context.Alocacao.Remove(alocacao);
            await _context.SaveChangesAsync();

            return Ok(alocacao);
        }

        private bool AlocacaoExists(int id)
        {
            return _context.Alocacao.Any(e => e.id == id);
        }
    }
}