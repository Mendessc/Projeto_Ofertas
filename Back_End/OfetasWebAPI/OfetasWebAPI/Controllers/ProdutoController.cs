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
    public class ProdutoController : ControllerBase
    {
        private readonly OfertasContext _context;

        public ProdutoController(OfertasContext appContext)
        {
            _context = appContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> PutProduto(int id, Produto produto)
        {
            if (id != produto.IdProduto)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.IdProduto }, produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto (int id)
        {
            var produto = await _context.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Remove(id);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(p => p.IdProduto == id);
        }
    }
}
