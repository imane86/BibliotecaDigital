using BibliotecaDigital.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace BibliotecaDigital.Data.Contexts
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar la relación muchos a muchos entre Usuario y Rol
            modelBuilder.Entity<Usuario>().Property(Roles => Roles.NombreUsuario).IsRequired();
            modelBuilder.Entity<Usuario>().Property(Email => Email.Email).IsRequired();
            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Usuarios)
            .UsingEntity(j => j.ToTable("UsuarioRoles")); // Nombre de la tabla intermedia


        }


    }
}