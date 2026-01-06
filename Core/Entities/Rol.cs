using System.ComponentModel.DataAnnotations;

namespace BibliotecaDigital.Core.Entities
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public ICollection<Usuario> Usuarios { get; set; }
        public Rol() { }

    }
}
