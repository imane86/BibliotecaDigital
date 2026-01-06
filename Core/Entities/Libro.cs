using System.ComponentModel.DataAnnotations;

namespace BibliotecaDigital.Core.Entities

{
    public class Libro 

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public int AnioPublicacion { get; set; }
    }
}
