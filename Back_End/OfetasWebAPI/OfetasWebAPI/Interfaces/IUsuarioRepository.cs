using OfetasWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
