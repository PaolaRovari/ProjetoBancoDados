using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBancoDados.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObraDeArte_Artista_ArtistaId1",
                table: "ObraDeArte");

            migrationBuilder.DropForeignKey(
                name: "FK_ObraDeArte_Lugar_LugarId1",
                table: "ObraDeArte");

            migrationBuilder.DropIndex(
                name: "IX_ObraDeArte_ArtistaId1",
                table: "ObraDeArte");

            migrationBuilder.DropIndex(
                name: "IX_ObraDeArte_LugarId1",
                table: "ObraDeArte");

            migrationBuilder.DropColumn(
                name: "ArtistaId1",
                table: "ObraDeArte");

            migrationBuilder.DropColumn(
                name: "LugarId1",
                table: "ObraDeArte");

            migrationBuilder.AddColumn<int>(
                name: "ArtistaId",
                table: "ObraDeArte",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LugarId",
                table: "ObraDeArte",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ObraDeArte_ArtistaId",
                table: "ObraDeArte",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraDeArte_LugarId",
                table: "ObraDeArte",
                column: "LugarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObraDeArte_Artista_ArtistaId",
                table: "ObraDeArte",
                column: "ArtistaId",
                principalTable: "Artista",
                principalColumn: "ArtistaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObraDeArte_Lugar_LugarId",
                table: "ObraDeArte",
                column: "LugarId",
                principalTable: "Lugar",
                principalColumn: "LugarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObraDeArte_Artista_ArtistaId",
                table: "ObraDeArte");

            migrationBuilder.DropForeignKey(
                name: "FK_ObraDeArte_Lugar_LugarId",
                table: "ObraDeArte");

            migrationBuilder.DropIndex(
                name: "IX_ObraDeArte_ArtistaId",
                table: "ObraDeArte");

            migrationBuilder.DropIndex(
                name: "IX_ObraDeArte_LugarId",
                table: "ObraDeArte");

            migrationBuilder.DropColumn(
                name: "ArtistaId",
                table: "ObraDeArte");

            migrationBuilder.DropColumn(
                name: "LugarId",
                table: "ObraDeArte");

            migrationBuilder.AddColumn<int>(
                name: "ArtistaId1",
                table: "ObraDeArte",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LugarId1",
                table: "ObraDeArte",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObraDeArte_ArtistaId1",
                table: "ObraDeArte",
                column: "ArtistaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ObraDeArte_LugarId1",
                table: "ObraDeArte",
                column: "LugarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ObraDeArte_Artista_ArtistaId1",
                table: "ObraDeArte",
                column: "ArtistaId1",
                principalTable: "Artista",
                principalColumn: "ArtistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObraDeArte_Lugar_LugarId1",
                table: "ObraDeArte",
                column: "LugarId1",
                principalTable: "Lugar",
                principalColumn: "LugarId");
        }
    }
}
