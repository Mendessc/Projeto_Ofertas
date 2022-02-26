using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using OfetasWebAPI.Repositories;

namespace OfetasWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }
        
        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_UsuarioRepository.Listar());
        }

        
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _UsuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }
        [Authorize(Roles = "1")]
        [HttpPut("{idUsuario}")]
        public IActionResult Alterar(int idUsuario, Usuario usuarioatualizado)
        {
            _UsuarioRepository.Atualizar(idUsuario, usuarioatualizado);

            return StatusCode(200);
        }
    }
}
