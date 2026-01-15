using BibliotecaDigital.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace BibliotecaDigital.Data.Contexts
{
    public class BibliotecaContext : DbContext
    {
        //definicion de las tablas en la base de datos
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        { 
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            // Aquí puedes agregar lógica personalizada antes de guardar los cambios
            //base es lo mismo que super en otros lenguajes
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        // Configuración del modelo
        // Override del método OnModelCreating
        // Este método se utiliza para configurar las entidades y sus relaciones
        // en la base de datos utilizando el Fluent API de Entity Framework Core
        // Por ejemplo, puedes configurar claves primarias, relaciones,
        // restricciones, etc.
        // En este caso, configuramos la relación muchos a muchos entre Usuario y Rol
        // creando una tabla intermedia llamada "UsuarioRoles"
        // Además, establecemos que los campos NombreUsuario y Email en la entidad Usuario son obligatorios
        // utilizando el método IsRequired()
        // Esto asegura que no se puedan insertar registros en la tabla Usuario sin estos campos
        // completados
        // Puedes agregar más configuraciones según sea necesario para otras entidades
        // en tu modelo de datos
        // Recuerda llamar a base.OnModelCreating(modelBuilder) para asegurarte
        // de que la configuración predeterminada también se aplique
        /* Ejemplo de uso:
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {  
             base.OnModelCreating(modelBuilder);
             // Configuraciones adicionales aquí
         }
         */
        //
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

            modelBuilder.Entity<Libro>().Property(t => t.Titulo).IsRequired();
            modelBuilder.Entity<Libro>().Property(t => t.Autor).IsRequired();
            modelBuilder.Entity<Libro>().Property(t => t.AnioPublicacion).IsRequired();

            modelBuilder.Entity<Rol>().Property(n => n.Nombre).IsRequired();
         
            




        }


    }
}