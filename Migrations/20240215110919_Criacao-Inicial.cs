using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBancoDados.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    ArtistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeArtista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NacionalidadeArtista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimentoFalecimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.ArtistaId);
                });

            migrationBuilder.CreateTable(
                name: "Lugar",
                columns: table => new
                {
                    LugarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioFuncionamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugar", x => x.LugarId);
                });

            migrationBuilder.CreateTable(
                name: "Visita",
                columns: table => new
                {
                    VisitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVisita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita", x => x.VisitaId);
                });

            migrationBuilder.CreateTable(
                name: "ObraDeArte",
                columns: table => new
                {
                    ObraDeArteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeObra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacaoObra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TecnicaObra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorObra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistaId1 = table.Column<int>(type: "int", nullable: true),
                    LugarId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraDeArte", x => x.ObraDeArteId);
                    table.ForeignKey(
                        name: "FK_ObraDeArte_Artista_ArtistaId1",
                        column: x => x.ArtistaId1,
                        principalTable: "Artista",
                        principalColumn: "ArtistaId");
                    table.ForeignKey(
                        name: "FK_ObraDeArte_Lugar_LugarId1",
                        column: x => x.LugarId1,
                        principalTable: "Lugar",
                        principalColumn: "LugarId");
                });

            migrationBuilder.CreateTable(
                name: "LugarVisita",
                columns: table => new
                {
                    LugarVisitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitaId = table.Column<int>(type: "int", nullable: false),
                    LugarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarVisita", x => x.LugarVisitaId);
                    table.ForeignKey(
                        name: "FK_LugarVisita_Lugar_LugarId",
                        column: x => x.LugarId,
                        principalTable: "Lugar",
                        principalColumn: "LugarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LugarVisita_Visita_VisitaId",
                        column: x => x.VisitaId,
                        principalTable: "Visita",
                        principalColumn: "VisitaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitante",
                columns: table => new
                {
                    VisitanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeVisitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailVisitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneVisitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitante", x => x.VisitanteId);
                    table.ForeignKey(
                        name: "FK_Visitante_Visita_VisitaId1",
                        column: x => x.VisitaId1,
                        principalTable: "Visita",
                        principalColumn: "VisitaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LugarVisita_LugarId",
                table: "LugarVisita",
                column: "LugarId");

            migrationBuilder.CreateIndex(
                name: "IX_LugarVisita_VisitaId",
                table: "LugarVisita",
                column: "VisitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraDeArte_ArtistaId1",
                table: "ObraDeArte",
                column: "ArtistaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ObraDeArte_LugarId1",
                table: "ObraDeArte",
                column: "LugarId1");

            migrationBuilder.CreateIndex(
                name: "IX_Visitante_VisitaId1",
                table: "Visitante",
                column: "VisitaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LugarVisita");

            migrationBuilder.DropTable(
                name: "ObraDeArte");

            migrationBuilder.DropTable(
                name: "Visitante");

            migrationBuilder.DropTable(
                name: "Artista");

            migrationBuilder.DropTable(
                name: "Lugar");

            migrationBuilder.DropTable(
                name: "Visita");
        }
    }
}
