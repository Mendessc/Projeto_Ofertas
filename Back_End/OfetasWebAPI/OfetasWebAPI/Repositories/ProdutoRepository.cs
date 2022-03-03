using Microsoft.EntityFrameworkCore;
using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly OfertasContext ctx;

        public ProdutoRepository(OfertasContext appContext)
        {
            ctx = appContext;
        }

        public Produto Atualzar(Produto pAtualizar)
        {
            ctx.Entry(pAtualizar).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return ctx.Produtos.Find(pAtualizar.IdProduto);
        }

        public Produto Criar(Produto pNovo)
        {
            ctx.Produtos.Add(pNovo);
            ctx.SaveChangesAsync();
            return pNovo;
        }

        public void Deletar(Produto pDeletar)
        {
            ctx.Produtos.Remove(pDeletar);
            ctx.SaveChangesAsync();
        }

        public IEnumerable<Produto> Listar()
        {
             return ctx.Produtos.ToList();
        }
    }
}
