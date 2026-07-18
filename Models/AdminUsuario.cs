using System.ComponentModel.DataAnnotations;

namespace RastroFinoAPI.Models
{
    public class AdminUsuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; }
    }
}
