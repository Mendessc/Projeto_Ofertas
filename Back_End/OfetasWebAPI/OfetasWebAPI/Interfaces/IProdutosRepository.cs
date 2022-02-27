using OfetasWebAPI.Domains;
using System.Collections.Generic;

namespace OfetasWebAPI.Interfaces
{
    public interface IProdutosRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(int idProduto);
        void Cadastrar(Produto novoProduto);
        void Atualizar(int idProduto, Produto ProdutoAtualizado);
        void Deletar(int idProduto);
    }
}
