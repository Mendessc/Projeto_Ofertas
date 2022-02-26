using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OfetasWebAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        readonly OfertasContext ctx = new();

        public void Atualizar(int idCategoria, Categorium CategoriaAtualizado)
        {
            Categorium CategoriaBuscado = ctx.Categoria.Find(idCategoria);

            if (CategoriaBuscado.NomeCategoria != null)
            {
                CategoriaBuscado.NomeCategoria = CategoriaAtualizado.NomeCategoria;
                

                ctx.Categoria.Update(CategoriaBuscado);

                ctx.SaveChanges();
            }
        }

        public Categorium BuscarPorId(int idCategoria)
        {
            return ctx.Categoria.FirstOrDefault(u => u.IdCategoria == idCategoria);
        }

        public void Cadastrar(Categorium novoCategoria)
        {
            ctx.Categoria.Add(novoCategoria);

            ctx.SaveChanges();
        }

        public void Deletar(int idCategoria)
        {
            ctx.Categoria.Remove(BuscarPorId(idCategoria));

            ctx.SaveChanges();
        }

        public List<Categorium> Listar()
        {
            return ctx.Categoria.ToList();   
        }
    }
}
