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
    public class ReservaRepository : IReservaRepository
    {
        private readonly OfertasContext ctx;

        public ReservaRepository(OfertasContext appContext)
        {
            ctx = appContext;
        }

        public Reserva Atualzar(Reserva rAtualizar)
        {
            ctx.Entry(rAtualizar).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return ctx.Reservas.Find(rAtualizar.IdReserva);
        }

        public void Criar(Reserva rNovo)
        {
            ctx.Reservas.Add(rNovo);
            ctx.SaveChangesAsync();
        }

        public void Deletar(Reserva rDeletar)
        {
            ctx.Reservas.Remove(rDeletar);
        }

        public IEnumerable<Reserva> Listar()
        {
            return ctx.Reservas.ToList();
        }
    }
}
