using System;
using System.Collections.Generic;

namespace BackEcommerce.Models
{
    public partial class DetallePedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public string Producto { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
    }
}
