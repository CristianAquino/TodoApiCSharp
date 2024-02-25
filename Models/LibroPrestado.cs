using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApiCSharp.Models
{
    public class LibroPrestado
    {
        // recordar que ID lo toma como primary key
        public Guid libroId { get; set; }
        public Guid prestamoId { get; set; }
        // añadimos la relacion con la tabla libro y prestamo
        // prestamo 1 -- 1 libro prestado
        // libro 1 -- 1 libro prestado
        public Prestamo Prestamo { get; set; }
        public Libro Libro { get; set; }
    }

    // definimos cual sera la primary key
    class LibroPrestadoConfig : IEntityTypeConfiguration<LibroPrestado>
    {
        public void Configure(EntityTypeBuilder<LibroPrestado> builder)
        {
            builder.ToTable("LibroPrestado");
            builder.HasKey(c => new { c.libroId, c.prestamoId });

            builder.HasOne(lprestado => lprestado.Prestamo).WithMany(prestamo => prestamo.LibrosPrestados);

            builder.HasOne(lprestado => lprestado.Libro).WithMany(libro => libro.LibrosPrestados);
        }
    }
}