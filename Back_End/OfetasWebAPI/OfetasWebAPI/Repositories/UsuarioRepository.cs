using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using OfetasWebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly OfertasContext ctx;

        public UsuarioRepository(OfertasContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                 if (usuario.Senha.Length != 32 && usuario.Senha.Substring(0, 1) != "$")
                {
                    usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                    ctx.SaveChanges();
                    
                }

               bool confere = Criptografia.Comparar(senha, usuario.Senha);

                if (confere)
                {
                return usuario;
                }
                
            }
           

            return null;
        }
    }
}
