using System;
using System.Collections.Generic;

#nullable disable

namespace OfetasWebAPI.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdConsumidor { get; set; }
        public int? IdProduto { get; set; }

        public virtual Consumidor IdConsumidorNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
