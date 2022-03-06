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
using Microsoft.AspNetCore.Authorization;
using OfetasWebAPI.ViewModels;

namespace OfetasWebAPI.Controllers
{
    [Produces("application/json")]
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
            var produto = await _context.Produtos.ToListAsync();
            foreach (var item in produto)
            {                
                DeletaProdutoVencido(item);
            }
            
            return await _context.Produtos.ToListAsync();
        }
        [Authorize(Roles = "2, 3")]
        [HttpGet("Minhas")]
        public async Task<ActionResult<IEnumerable<Produto>>> MeusProdutos(int id)
        {
            return await _context.Produtos.Include(c => c.IdFornecedorNavigation).Include(c => c.IdCategoriaNavigation).Where(p => p.IdFornecedor == id).ToListAsync();
        }

        [HttpGet("SemReservas")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarProdutoNaoReservados()
        {
            var produto = await _context.Produtos.ToListAsync();

            foreach (var item in produto)
            {
                DeletaProdutoVencido(item);
            }

            var novalista = FiltroDeReservas(produto);

            return novalista.ToList();
            
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
        [Authorize(Roles = "3")]
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
        [Authorize(Roles = "3")]
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto([FromForm] Produto produto, IFormFile arquivo)
        {
            #region Upload da Imagem com extensões permitidas apenas
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

            if (uploadResultado == "")
            {
                return BadRequest("Arquivo não encontrado");
            }

            if (uploadResultado == "Extensão não permitida")
            {
                return BadRequest("Extensão de arquivo não permitida");
            }

            produto.ImagemProduto = uploadResultado;
            #endregion


            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.IdProduto }, produto);
        }
        [Authorize(Roles = "3")]
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

        private void DeletaProdutoVencido(Produto p)
        {
            if (p.IdCategoria == 1 )
            {
                if (p.DataValidade <= DateTime.Now)
                {
                    _context.Produtos.Remove(p);
                    _context.SaveChanges();
                }
            }
            
        }

        private List<Produto> FiltroDeReservas(List<Produto> p)
        {
            var reservas = _context.Reservas.ToList();

            List<Produto> Listasemrese = new();

            foreach (var item in reservas)
            {
                foreach (var prod in p)
                {
                    if (item.IdProduto != prod.IdProduto)
                    {
                        Listasemrese.Add(prod);
                    }
                }
                
            }

            return Listasemrese;     

        }

        private void MetodoDesconta(Produto p)
        {
            Double novoPreco = Desconto.Descontar(p);

            p.Preco = novoPreco;
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();

        }

        
    }
}
