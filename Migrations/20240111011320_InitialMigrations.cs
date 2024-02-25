using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApiCSharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    libroId = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    autor = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    editorial = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.libroId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    prestamoId = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fechaVencimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    visitante = table.Column<string>(type: "text", nullable: false),
                    concepto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.prestamoId);
                });

            migrationBuilder.CreateTable(
                name: "LibroPrestado",
                columns: table => new
                {
                    libroId = table.Column<Guid>(type: "uuid", nullable: false),
                    prestamoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroPrestado", x => new { x.libroId, x.prestamoId });
                    table.ForeignKey(
                        name: "FK_LibroPrestado_Libro_libroId",
                        column: x => x.libroId,
                        principalTable: "Libro",
                        principalColumn: "libroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroPrestado_Prestamo_prestamoId",
                        column: x => x.prestamoId,
                        principalTable: "Prestamo",
                        principalColumn: "prestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibroPrestado_prestamoId",
                table: "LibroPrestado",
                column: "prestamoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroPrestado");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Prestamo");
        }
    }
}
