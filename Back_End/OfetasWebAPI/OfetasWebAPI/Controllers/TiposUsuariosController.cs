using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfetasWebAPI.Interfaces;
using OfetasWebAPI.Repositories;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Contexts;
using System.Linq;

namespace OfetasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private readonly OfertasContext ctx;
        public TiposUsuariosController(OfertasContext appContext)
        {
            ctx = appContext;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ctx.TipoUsuarios.ToList());
        }

    }
}
