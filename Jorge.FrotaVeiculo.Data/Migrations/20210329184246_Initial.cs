using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jorge.FrotaVeiculo.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chassi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    NumeroPassageiros = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Chassi",
                table: "Veiculo",
                column: "Chassi",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
