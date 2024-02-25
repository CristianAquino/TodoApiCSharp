using Microsoft.EntityFrameworkCore;
using TodoApiCSharp.Models;
namespace TodoApi.Data
{

    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        // mapeamos las entidades de la base de datos
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<LibroPrestado> LibroPrestados { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // añadimos las configuraciones de nuestras entidades
            modelBuilder.ApplyConfiguration(new PrestamoConfig());
            modelBuilder.ApplyConfiguration(new LibroConfig());
            modelBuilder.ApplyConfiguration(new LibroPrestadoConfig());
        }


    }
}