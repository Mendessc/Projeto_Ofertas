using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumidorController : ControllerBase
    {
        private readonly OfertasContext _context;

        public ConsumidorController(OfertasContext appContext)
        {
            _context = appContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumidor>>> GetConsumidor()
        {
            return await _context.Consumidors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consumidor>> GetConsumidor(int id)
        {
            var consumidor = await _context.Consumidors.FirstOrDefaultAsync(c => c.IdUsuario == id);

            if (consumidor == null)
            {
                return NotFound();
            }

            return consumidor;
        }


        [Authorize(Roles = "1,2")]
        [HttpPut]
        public async Task<ActionResult<Consumidor>> PutConsumidor(int id, Consumidor cAtualizar)
        {
            if (id != cAtualizar.IdConsumidor)
            {
                return BadRequest();
            }

            _context.Entry(cAtualizar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumidorExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Consumidor>> PostConsumidor(Consumidor consumidor)
        {
            _context.Consumidors.Add(consumidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumidor", new { id = consumidor.IdConsumidor }, consumidor);
        }
        [Authorize(Roles = "1")]
        [HttpDelete]
        public async Task<ActionResult> DeleteConsumidor(int id)
        {
            var consumidor = await _context.Consumidors.FindAsync(id);
            if (consumidor != null)
            {
                return NotFound();
            }

            _context.Consumidors.Remove(consumidor);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool ConsumidorExists(int id)
        {
            return _context.Consumidors.Any(e => e.IdConsumidor == id);
        }
    }
}
