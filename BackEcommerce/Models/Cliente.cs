using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEcommerce.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        
        public string Correo { get; set; }
        public string? Estatus { get; set; } = null!;
     
        public DateTime? FechaCreate { get; set; }
        public DateTime? FechaDelete { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
