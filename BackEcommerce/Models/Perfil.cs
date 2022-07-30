using System;
using System.Collections.Generic;

namespace BackEcommerce.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Estatus { get; set; } = null!;
        public DateTime FechaCreate { get; set; }
        public DateTime? FechaDelete { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
