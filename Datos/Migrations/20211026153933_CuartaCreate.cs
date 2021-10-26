using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class CuartaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValoraPagar",
                table: "Liquidaciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "valorMulta",
                table: "Liquidaciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValoraPagar",
                table: "Liquidaciones");

            migrationBuilder.DropColumn(
                name: "valorMulta",
                table: "Liquidaciones");
        }
    }
}
