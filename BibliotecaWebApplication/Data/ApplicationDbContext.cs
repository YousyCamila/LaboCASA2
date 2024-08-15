using BibliotecaWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>()
                       .HasKey(ul => new { ul.UserId, ul.LoginProvider, ul.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

            modelBuilder.Entity<Autorlibro>()
                .HasKey(al => new { al.AutorId, al.LibroId });

            modelBuilder.Entity<Autorlibro>()
                .HasOne(al => al.Autor)
                .WithMany(a => a.AutorLibros) // Debe coincidir con el nombre de la propiedad en Autor
                .HasForeignKey(al => al.AutorId);

            modelBuilder.Entity<Autorlibro>()
                .HasOne(al => al.Libro)
                .WithMany(l => l.LibroAutores) // Debe coincidir con el nombre de la propiedad en Libro
                .HasForeignKey(al => al.LibroId);
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autorlibro> Autorlibro { get; set; }
    }
}
