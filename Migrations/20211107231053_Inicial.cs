using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Alvaro_20190269.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposDeTareas",
                columns: table => new
                {
                    TipoDeTareaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoAcomulado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeTareas", x => x.TipoDeTareaId);
                });

            migrationBuilder.InsertData(
                table: "TiposDeTareas",
                columns: new[] { "TipoDeTareaId", "Nombre", "TiempoAcomulado" },
                values: new object[] { 1, "Analisis", 0 });

            migrationBuilder.InsertData(
                table: "TiposDeTareas",
                columns: new[] { "TipoDeTareaId", "Nombre", "TiempoAcomulado" },
                values: new object[] { 2, "Diseno", 0 });

            migrationBuilder.InsertData(
                table: "TiposDeTareas",
                columns: new[] { "TipoDeTareaId", "Nombre", "TiempoAcomulado" },
                values: new object[] { 3, "Programacion", 0 });

            migrationBuilder.InsertData(
                table: "TiposDeTareas",
                columns: new[] { "TipoDeTareaId", "Nombre", "TiempoAcomulado" },
                values: new object[] { 4, "Prueba", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposDeTareas");
        }
    }
}
