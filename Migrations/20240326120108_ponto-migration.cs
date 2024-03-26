using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiGerenciador.Migrations
{
    /// <inheritdoc />
    public partial class pontomigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ponto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colaboradorId = table.Column<int>(type: "int", nullable: false),
                    hEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hSaida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponto", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ponto");
        }
    }
}
