namespace BackEcommerce.Models
{
    public class ClienteDto : Paginacion
    {
        public ICollection<Cliente>? ListaClientes { get; set; }
    }
}
