using System;
using System.Collections.Generic;

#nullable disable

namespace OfetasWebAPI.Domains
{
    public partial class Categorium
    {
        public Categorium()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
