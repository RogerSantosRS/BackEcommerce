using System;
using System.Collections.Generic;

namespace BackEcommerce.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Folio { get; set; } = null!;
        public decimal Iva { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaCreate { get; set; }
        public DateTime? FechaDelete { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
