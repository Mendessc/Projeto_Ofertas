using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using OfetasWebAPI.Repositories;

namespace OfetasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository _CategoriaRepository { get; set; }
        public CategoriasController()
        {
            _CategoriaRepository = new CategoriaRepository();
        }

        
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_CategoriaRepository.Listar());
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Categorium novoCategoria)
        {
            _CategoriaRepository.Criar(novoCategoria);

            return StatusCode(201);
        }


        [Authorize(Roles = "1")]
        [HttpPut("{idCategoria}")]
        public IActionResult Atualizar(Categorium CategoriaAtualizado)
        {
            _CategoriaRepository.Atualzar(CategoriaAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idCategoria}")]
        public IActionResult Deletar(Categorium idCategoria)
        {
            _CategoriaRepository.Deletar(idCategoria);

            return StatusCode(204);
        }
    }
}

