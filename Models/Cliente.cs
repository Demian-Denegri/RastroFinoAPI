using System.ComponentModel.DataAnnotations;

namespace RastroFinoAPI.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
       public string Nombre { get; set; }

       public string Apellido { get; set; }

       public string Email { get; set; }

       public string Telefono { get; set; }
       public string Direccion { get; set; }



    }
}
