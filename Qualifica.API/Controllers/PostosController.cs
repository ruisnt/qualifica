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
    public class PostosController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public PostosController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Postos
        [HttpGet]
        public IEnumerable<Posto> GetPosto()
        {
            return _context.Posto;
        }

        // GET: api/Postos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPosto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posto = await _context.Posto.FindAsync(id);

            if (posto == null)
            {
                return NotFound();
            }

            return Ok(posto);
        }

        // PUT: api/Postos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosto([FromRoute] int id, [FromBody] Posto posto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != posto.id)
            {
                return BadRequest();
            }

            _context.Entry(posto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostoExists(id))
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

        // POST: api/Postos
        [HttpPost]
        public async Task<IActionResult> PostPosto([FromBody] Posto posto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Posto.Add(posto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosto", new { id = posto.id }, posto);
        }

        // DELETE: api/Postos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posto = await _context.Posto.FindAsync(id);
            if (posto == null)
            {
                return NotFound();
            }

            _context.Posto.Remove(posto);
            await _context.SaveChangesAsync();

            return Ok(posto);
        }

        private bool PostoExists(int id)
        {
            return _context.Posto.Any(e => e.id == id);
        }
    }
}