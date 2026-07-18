using System.ComponentModel.DataAnnotations;

namespace RastroFinoAPI.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

    }
}
