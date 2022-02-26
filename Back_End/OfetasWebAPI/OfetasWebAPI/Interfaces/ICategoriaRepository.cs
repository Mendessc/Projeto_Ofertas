using OfetasWebAPI.Domains;
using System.Collections.Generic;

namespace OfetasWebAPI.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categorium> Listar();
        Categorium BuscarPorId(int idCategoria);
        void Cadastrar(Categorium novoCategoria);
        void Atualizar(int idCategoria, Categorium CategoriaAtualizado);
        void Deletar(int idCategoria);
    }
}
