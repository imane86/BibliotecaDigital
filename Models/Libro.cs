using System.ComponentModel.DataAnnotations;
namespace BibliotecaDigital.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }

        public Libro() {
        }
         
        public Libro(int Id, String Titulo, String Autor, int AnioPublicacion) {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.AnioPublicacion = AnioPublicacion;
        }
    }
}