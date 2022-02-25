using System;
using System.Collections.Generic;

#nullable disable

namespace OfetasWebAPI.Domains
{
    public partial class Consumidor
    {
        public Consumidor()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdConsumidor { get; set; }
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Tefelone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
