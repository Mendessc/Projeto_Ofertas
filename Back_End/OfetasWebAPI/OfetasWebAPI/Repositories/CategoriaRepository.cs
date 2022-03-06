using Microsoft.EntityFrameworkCore;
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

        public Categorium Atualzar(Categorium cAtualizar)
        {
            ctx.Entry(cAtualizar).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return ctx.Categoria.Find(cAtualizar.IdCategoria);
        }

        public Categorium Criar(Categorium cNovo)
        {
            ctx.Categoria.Add(cNovo);
            ctx.SaveChangesAsync();
            return cNovo;
        }

        public void Deletar(Categorium cDeletar)
        {
            ctx.Categoria.Remove(cDeletar);
            ctx.SaveChangesAsync();
        }

        public IEnumerable<Categorium> Listar()
        {
            return ctx.Categoria.ToList();
        }
    }
}
