using System;
using System.Collections.Generic;

#nullable disable

namespace OfetasWebAPI.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdProduto { get; set; }
        public int? IdFornecedor { get; set; }
        public int? IdCategoria { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataValidade { get; set; }
        public string ImagemProduto { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Fornecedor IdFornecedorNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
