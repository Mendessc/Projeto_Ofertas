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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly OfertasContext _context;

        public ReservaController(OfertasContext appContext)
        {
            _context = appContext;
        }
        [Authorize(Roles = "2, 3")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
        {
            return await _context.Reservas.ToListAsync();
        }

        [Authorize(Roles = "2, 3")]
        [HttpGet("Minhas")]
        public async Task<ActionResult<IEnumerable<Reserva>>> MinhasReserva(int id)
        {
            return await _context.Reservas.Include(c => c.IdConsumidorNavigation).Include(c => c.IdProdutoNavigation).Where(p => p.IdConsumidor == id).ToListAsync();
        }
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Reserva>> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }
        [Authorize(Roles = "2")]
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            if (reserva.IdConsumidor == null)
            {
                return BadRequest("A reserva não contem um consumidor");
            }
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { r = reserva.IdReserva }, reserva);
        }
        [Authorize(Roles = "1,2 ")]
        [HttpDelete]
        public async Task<ActionResult<Reserva>> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(r => r.IdReserva == id);
        }
    }
}
