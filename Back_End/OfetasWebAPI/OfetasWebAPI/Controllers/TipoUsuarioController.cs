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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_TipoUsuarioRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novaTipoUsuario)
        {
            _TipoUsuarioRepository.Cadastrar(novaTipoUsuario);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idTipoUsuairo}")]
        public IActionResult Deletar(int idTipoUsuairo)
        {
            _TipoUsuarioRepository.Deletar(idTipoUsuairo);

            return StatusCode(204);
        }
        [Authorize(Roles = "1")]
        [HttpPut("{idTipoUsuairo}")]
        public IActionResult Alterar(int idTipoUsuairo, TipoUsuario tipousuarioAtualizado)
        {
            _TipoUsuarioRepository.Atualizar(idTipoUsuairo, tipousuarioAtualizado);

            return StatusCode(200);
        }
    }
}
