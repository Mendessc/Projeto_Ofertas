using OfetasWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Interfaces
{
    interface IFornecedorRepository
    {
        IEnumerable<Fornecedor> Listar();
        Fornecedor Atualzar(Fornecedor fAtualizar);
        void Criar (Fornecedor fNovo);
        void Deletar (Fornecedor fDeletar);
    }
}
