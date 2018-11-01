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
    public class GerentesObraController : ControllerBase
    {
        private readonly QualificaAPIContext _context;

        public GerentesObraController(QualificaAPIContext context)
        {
            _context = context;
        }

        // GET: api/GerentesObra
        [HttpGet]
        public IEnumerable<GerenteObra> GetGerenteObra()
        {
            return _context.GerenteObra;
        }

        // GET: api/GerentesObra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGerenteObra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gerenteObra = await _context.GerenteObra.FindAsync(id);

            if (gerenteObra == null)
            {
                return NotFound();
            }

            return Ok(gerenteObra);
        }

        // PUT: api/GerentesObra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGerenteObra([FromRoute] int id, [FromBody] GerenteObra gerenteObra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gerenteObra.id)
            {
                return BadRequest();
            }

            _context.Entry(gerenteObra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerenteObraExists(id))
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

        // POST: api/GerentesObra
        [HttpPost]
        public async Task<IActionResult> PostGerenteObra([FromBody] GerenteObra gerenteObra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GerenteObra.Add(gerenteObra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGerenteObra", new { id = gerenteObra.id }, gerenteObra);
        }

        // DELETE: api/GerentesObra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGerenteObra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gerenteObra = await _context.GerenteObra.FindAsync(id);
            if (gerenteObra == null)
            {
                return NotFound();
            }

            _context.GerenteObra.Remove(gerenteObra);
            await _context.SaveChangesAsync();

            return Ok(gerenteObra);
        }

        private bool GerenteObraExists(int id)
        {
            return _context.GerenteObra.Any(e => e.id == id);
        }
    }
}