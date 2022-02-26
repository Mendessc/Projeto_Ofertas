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

        readonly OfertasContext ctx = new();

        /*public UsuarioRepository(OfertasContext appContext)
        {
            ctx = appContext;
        }
        */

        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(idUsuario);

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {


            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
            
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            
            if (usuario != null)
            {
                 if (usuario.Senha.Length != 32)
                {
                    var UsuarioCrypto = Criptografia.GerarHash(usuario.Senha);

                   usuario.Senha = UsuarioCrypto;
                    usuario.Email = email;

                    ctx.Update(usuario);

                    ctx.SaveChangesAsync();
                    
                    
                    
                }

               bool confere = Criptografia.Comparar(senha, usuario.Senha);
                
                if (confere)
                {
                return usuario;
                }
                
            }
           

            return usuario;
        }
    }
}
