using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class TercerCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaInfraccion",
                table: "Infracciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Liquidaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idInfraccion = table.Column<int>(type: "int", nullable: false),
                    infraccionidInfraccion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Liquidaciones_Infracciones_infraccionidInfraccion",
                        column: x => x.infraccionidInfraccion,
                        principalTable: "Infracciones",
                        principalColumn: "idInfraccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Liquidaciones_infraccionidInfraccion",
                table: "Liquidaciones",
                column: "infraccionidInfraccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Liquidaciones");

            migrationBuilder.DropColumn(
                name: "fechaInfraccion",
                table: "Infracciones");
        }
    }
}
