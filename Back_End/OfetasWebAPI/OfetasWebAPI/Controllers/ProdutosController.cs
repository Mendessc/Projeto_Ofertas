using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using OfetasWebAPI.Repositories;

namespace OfetasWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutosRepository _ProdutoRepository { get; set; }

        public ProdutosController()
        {
            _ProdutoRepository = new ProdutoRepository();
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_ProdutoRepository.Listar());
        }

        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Cadastrar(Produto novaProduto)
        {
            _ProdutoRepository.Cadastrar(novaProduto);

            return StatusCode(201);
        }

        [Authorize(Roles = "3")]
        [HttpDelete("{idProduto}")]
        public IActionResult Deletar(int idProduto)
        {
            _ProdutoRepository.Deletar(idProduto);

            return StatusCode(204);
        }
        [Authorize(Roles = "3")]
        [HttpPut("{idProduto}")]
        public IActionResult Alterar(int idProduto, Produto produtoAtualizado)
        {
            _ProdutoRepository.Atualizar(idProduto, produtoAtualizado);

            return StatusCode(200);
        }
    }
}
