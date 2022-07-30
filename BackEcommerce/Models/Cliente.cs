using System;
using System.Collections.Generic;

namespace BackEcommerce.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Estatus { get; set; } = null!;
        public DateTime FechaCreate { get; set; }
        public DateTime? FechaDelete { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
