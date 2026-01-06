using System.ComponentModel.DataAnnotations;

namespace BibliotecaDigital.Models
{
    public class Rol
    {

        public int Id { get; set; }


        public string Nombre { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    

    public Rol() { 
        }
        public Rol(int Id, String Nombre) {
            this.Id = Id;
            this.Nombre = Nombre;
        }
        }
    }
