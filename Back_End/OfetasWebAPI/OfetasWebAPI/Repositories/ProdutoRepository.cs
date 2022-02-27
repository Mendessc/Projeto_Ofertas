using OfetasWebAPI.Contexts;
using OfetasWebAPI.Domains;
using OfetasWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OfetasWebAPI.Repositories
{
    public class ProdutoRepository : IProdutosRepository
    {
        readonly OfertasContext ctx = new();
        public void Atualizar(int idProduto, Produto ProdutoAtualizado)
        {
            Produto produtoBuscado = ctx.Produtos.Find(idProduto);

            if (produtoBuscado.NomeProduto != null)
            {
                produtoBuscado.NomeProduto = ProdutoAtualizado.NomeProduto;
                produtoBuscado.Descricao = ProdutoAtualizado.Descricao;
                produtoBuscado.Preco = ProdutoAtualizado.Preco;
                produtoBuscado.DataValidade = ProdutoAtualizado.DataValidade;
                produtoBuscado.ImagemProduto = ProdutoAtualizado.ImagemProduto;

                ctx.Produtos.Update(produtoBuscado);

                ctx.SaveChanges();
            }
        }

        public Produto BuscarPorId(int idProduto)
        {
            return ctx.Produtos.FirstOrDefault(u => u.IdProduto == idProduto);
        }

        public void Cadastrar(Produto novoProduto)
        {
            ctx.Produtos.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int idProduto)
        {
            ctx.Produtos.Remove(BuscarPorId(idProduto));
            ctx.SaveChanges();
        }

        public List<Produto> Listar()
        {
            return ctx.Produtos.ToList();
        }
    }
}
