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
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly OfertasContext ctx;

        public FornecedorRepository(OfertasContext appcontext)
        {
            ctx = appcontext;
        }

        public Fornecedor Atualzar(Fornecedor fAtualizar)
        {
            ctx.Entry(fAtualizar).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return ctx.Fornecedors.Find(fAtualizar.IdFornecedor);
        }

        public void Criar(Fornecedor fNovo)
        {
            ctx.Fornecedors.Add(fNovo);
            ctx.SaveChangesAsync();
        }

        public void Deletar(Fornecedor fDeletar)
        {
            ctx.Fornecedors.Remove(fDeletar);
            ctx.SaveChangesAsync();
        }

        public IEnumerable<Fornecedor> Listar()
        {
            return ctx.Fornecedors.ToList();
        }
    }
}
