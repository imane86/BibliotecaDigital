using BibliotecaDigital.Models;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDigital.Models
{
    public class Usuario

    {

        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Rol> Roles { get; set; }
 
    public Usuario() { 
        }

        public Usuario(int Id, String NombreUsuario, String Email, String PasswordHash) {
            this.Id = Id;
            this.NombreUsuario = NombreUsuario;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
        }
    }
}