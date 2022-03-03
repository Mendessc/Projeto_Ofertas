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
    public class ConsumidorRepository : IConsumidorRepository
    {
        private readonly OfertasContext ctx;

        public ConsumidorRepository (OfertasContext appContext)
        {
            ctx = appContext;
        }

        public IEnumerable<Consumidor> Listar()
        {
            return ctx.Consumidors.ToList();
        }

        public Consumidor Atualzar(Consumidor cAtualizar)
        {
            ctx.Entry(cAtualizar).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return ctx.Consumidors.Find(cAtualizar.IdConsumidor);
        }

        public Consumidor Criar(Consumidor cNovo)
        {
            ctx.Consumidors.Add(cNovo);
            ctx.SaveChangesAsync();
            return cNovo;
        }

        public void Deletar(Consumidor cDeletar)
        {
            ctx.Consumidors.Remove(cDeletar);
            ctx.SaveChangesAsync();
        }
    }
}
