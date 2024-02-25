using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApiCSharp.Models
{
    public class Prestamo
    {
        // recordar que ID lo toma como primary key
        public Guid prestamoId { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string visitante { get; set; } = "";
        public string concepto { get; set; } = "";
        // añadimos la relacion con la tabla libroprestado
        // prestamo 1 -- * libro prestado
        public List<LibroPrestado> LibrosPrestados { get; set; }
    }

    // definimos cual sera la primary key
    class PrestamoConfig : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.ToTable("Prestamo");
            builder.HasKey(prestamo => prestamo.prestamoId);

            builder.HasMany(prestamo => prestamo.LibrosPrestados).WithOne(lprestado => lprestado.Prestamo);
        }
    }
}