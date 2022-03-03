using OfetasWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfetasWebAPI.Interfaces
{
    interface IProdutoRepository
    {
        IEnumerable<Produto> Listar();
        Produto Atualzar(Produto pAtualizar);
        Produto Criar(Produto pNovo);
        void Deletar(Produto pDeletar);
    }
}
