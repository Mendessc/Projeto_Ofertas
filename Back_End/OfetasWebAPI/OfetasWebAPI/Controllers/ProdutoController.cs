using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using OfetasWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfetasWebAPI.Utils;

namespace OfetasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly OfertasContext _context;
        private IProdutoRepository _ProdutosRepository { get; set; }

        public ProdutoController(OfertasContext appContext)
        {
            _context = appContext;

           // _ProdutosRepository = new ProdutoRepository();
        }

        /*public ProdutoController()
        {
            _ProdutosRepository = new ProdutoRepository();
        }
        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _context.Produtos.ToListAsync();
        }

        
        [HttpPatch("{id}")]
        public async Task<ActionResult<Produto>> AlterarPreco(int id)
        {
            Produto p = _context.Produtos.FirstOrDefault(p => p.IdProduto == id);

            Double novoPreco = Desconto.Descontar(p);

            p.Preco = novoPreco;

            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            

            return Ok();
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
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(p => p.IdProduto == id);
        }
    }
}
