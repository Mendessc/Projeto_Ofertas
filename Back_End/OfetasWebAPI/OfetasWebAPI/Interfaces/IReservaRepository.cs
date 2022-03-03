using OfetasWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Interfaces
{
    interface IReservaRepository
    {
        IEnumerable<Reserva> Listar();
        Reserva Atualzar (Reserva rAtualizar);
        void Criar (Reserva rNovo);
        void Deletar (Reserva rDeletar);
    }
}
