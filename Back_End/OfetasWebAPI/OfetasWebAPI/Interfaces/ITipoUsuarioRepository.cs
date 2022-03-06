using OfetasWebAPI.Domains;
using System.Collections.Generic;

namespace OfetasWebAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        IEnumerable<TipoUsuario> Listar();
    }
}
