using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApiCSharp.Models
{
    public class Libro
    {
        // recordar que ID lo toma como primary key
        public Guid libroId { get; set; }
        public string nombre { get; set; } = "";
        public string autor { get; set; } = "";
        public string descripcion { get; set; } = "";
        public string editorial { get; set; } = "";
        // añadimos la relacion con la tabla libroprestado
        // libro 1 -- * libro prestado
        public List<LibroPrestado> LibrosPrestados { get; set; }

    }

    // definimos cual sera la primary key
    class LibroConfig : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libro");
            builder.HasKey(libro => libro.libroId);

            builder.HasMany(libro => libro.LibrosPrestados).WithOne(libroPrestado => libroPrestado.Libro);
        }
    }
}