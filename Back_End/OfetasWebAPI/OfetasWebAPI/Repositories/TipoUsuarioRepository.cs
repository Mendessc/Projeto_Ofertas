using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OfetasWebAPI.Repositories
{
    public class TipoUsuarioRepository
    {
        private readonly OfertasContext ctx;

        public IEnumerable<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
