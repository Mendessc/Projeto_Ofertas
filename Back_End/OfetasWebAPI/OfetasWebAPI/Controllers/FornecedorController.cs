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
    public class FornecedorController : ControllerBase
    {
        private readonly OfertasContext _context;

        public FornecedorController(OfertasContext appContext)
        {
            _context = appContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedor()
        {
            return await _context.Fornecedors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetConsumidor(int id)
        {
            var fornecedor = await _context.Fornecedors.FirstOrDefaultAsync(p => p.IdUsuario == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        [Authorize(Roles = "1, 3")]
        [HttpPut]
        public async Task<ActionResult<Fornecedor>> PutFornecedor(int id, Fornecedor fornecedor)
        {
            if (fornecedor!= null)
            {
                return NotFound();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
                {
                    return NotFound();
                }                
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedors.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.IdFornecedor }, fornecedor);
        }
        [Authorize(Roles = "1")]
        [HttpDelete]
        public async Task<ActionResult<Fornecedor>> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedors.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedors.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedors.Any(e => e.IdFornecedor == id);
        }
    }
}
