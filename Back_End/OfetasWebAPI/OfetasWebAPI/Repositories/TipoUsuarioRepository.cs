using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OfetasWebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        readonly OfertasContext ctx = new();

        public void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(idTipoUsuario);

            if (TipoUsuarioBuscado.NomeTipoUsuario != null)
            {
                TipoUsuarioBuscado.NomeTipoUsuario = TipoUsuarioAtualizado.NomeTipoUsuario;


                ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(u => u.IdTipoUsuario == idTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(idTipoUsuario));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
