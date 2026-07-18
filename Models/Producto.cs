using System.ComponentModel.DataAnnotations;

namespace RastroFinoAPI.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Imagen { get; set; }
        public int IdCategoria { get; set; }
        public int? IdGenero { get; set; }
        public int? Ml { get; set; }
        public bool Activo { get; set; }
    }
}
