using System;
using System.Collections.Generic;

#nullable disable

namespace OfetasWebAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Consumidors = new HashSet<Consumidor>();
            Fornecedors = new HashSet<Fornecedor>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Consumidor> Consumidors { get; set; }
        public virtual ICollection<Fornecedor> Fornecedors { get; set; }
    }
}
