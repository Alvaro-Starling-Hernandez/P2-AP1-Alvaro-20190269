using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Alvaro_20190269.Migrations
{
    public partial class Secundaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

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

            migrationBuilder.CreateTable(
                name: "ProyectosDetalle",
                columns: table => new
                {
                    ProyectoDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoDeTareaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDetalle", x => x.ProyectoDetalleId);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_TiposDeTareas_TipoDeTareaId",
                        column: x => x.TipoDeTareaId,
                        principalTable: "TiposDeTareas",
                        principalColumn: "TipoDeTareaId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_ProyectoId",
                table: "ProyectosDetalle",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_TipoDeTareaId",
                table: "ProyectosDetalle",
                column: "TipoDeTareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectosDetalle");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "TiposDeTareas");
        }
    }
}
