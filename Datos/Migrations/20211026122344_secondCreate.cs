using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class secondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infracciones",
                columns: table => new
                {
                    idInfraccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    personaidentificacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infracciones", x => x.idInfraccion);
                    table.ForeignKey(
                        name: "FK_Infracciones_Personas_personaidentificacion",
                        column: x => x.personaidentificacion,
                        principalTable: "Personas",
                        principalColumn: "identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Infracciones_personaidentificacion",
                table: "Infracciones",
                column: "personaidentificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infracciones");
        }
    }
}
