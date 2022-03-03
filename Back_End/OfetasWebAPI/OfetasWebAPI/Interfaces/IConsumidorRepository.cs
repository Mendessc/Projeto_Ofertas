using OfetasWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Interfaces
{
    interface IConsumidorRepository
    {
        IEnumerable<Consumidor> Listar();
        Consumidor Atualzar (Consumidor cAtualizar);
        Consumidor Criar (Consumidor cNovo);
        void Deletar (Consumidor cDeletar);
            
    }
}
