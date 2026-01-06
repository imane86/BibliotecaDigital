using System.ComponentModel.DataAnnotations;

namespace BibliotecaDigital.Core.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public ICollection<Rol> Roles { get; set; }
    }
}
