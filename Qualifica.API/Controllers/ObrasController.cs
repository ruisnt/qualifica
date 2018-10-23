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
    public class ObrasController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public ObrasController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Obras
        [HttpGet]
        public IEnumerable<Obra> GetObra()
        {
            return _context.Obra;
        }

        // GET: api/Obras/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obra = await _context.Obra.FindAsync(id);

            if (obra == null)
            {
                return NotFound();
            }

            return Ok(obra);
        }

        // PUT: api/Obras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObra([FromRoute] int id, [FromBody] Obra obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != obra.id)
            {
                return BadRequest();
            }

            _context.Entry(obra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraExists(id))
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

        // POST: api/Obras
        [HttpPost]
        public async Task<IActionResult> PostObra([FromBody] Obra obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Obra.Add(obra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObra", new { id = obra.id }, obra);
        }

        // DELETE: api/Obras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obra = await _context.Obra.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }

            _context.Obra.Remove(obra);
            await _context.SaveChangesAsync();

            return Ok(obra);
        }

        private bool ObraExists(int id)
        {
            return _context.Obra.Any(e => e.id == id);
        }
    }
}