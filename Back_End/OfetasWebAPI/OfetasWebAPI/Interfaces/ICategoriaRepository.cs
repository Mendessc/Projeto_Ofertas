using OfetasWebAPI.Domains;
using System.Collections.Generic;

namespace OfetasWebAPI.Interfaces
{
    interface ICategoriaRepository
    {
        IEnumerable<Categorium> Listar();
        Categorium Atualzar(Categorium cAtualizar);
        Categorium Criar(Categorium cNovo);
        void Deletar(Categorium cDeletar);
    }
}
