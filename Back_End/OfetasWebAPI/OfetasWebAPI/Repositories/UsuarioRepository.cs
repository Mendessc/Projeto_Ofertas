using Microsoft.EntityFrameworkCore;
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

        public Usuario Atualzar(Usuario uAtualizar)
        {
            ctx.Entry(uAtualizar).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return ctx.Usuarios.Find(uAtualizar.IdUsuario);
        }

        public Usuario Criar(Usuario uNovo)
        {
            ctx.Usuarios.Add(uNovo);
            ctx.SaveChangesAsync();
            return uNovo;
        }

        public void Deletar(Usuario uDeletar)
        {
            ctx.Usuarios.Remove(uDeletar);
            ctx.SaveChangesAsync();
        }

        public IEnumerable<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                 if (usuario.Senha == senha)
                {
                    usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                    ctx.SaveChanges();
                    
                    

                }

               bool confere = Criptografia.Comparar(senha, usuario.Senha);
                                if (confere)
                                    return usuario;
                
            }
           

            return null;
        }
    }
}
