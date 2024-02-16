using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBancoDados.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teste_Lugar_LugarId",
                table: "teste");

            migrationBuilder.DropForeignKey(
                name: "FK_teste_Visita_VisitaId",
                table: "teste");

            migrationBuilder.DropIndex(
                name: "IX_teste_LugarId",
                table: "teste");

            migrationBuilder.DropIndex(
                name: "IX_teste_VisitaId",
                table: "teste");

            migrationBuilder.DropColumn(
                name: "LugarId",
                table: "teste");

            migrationBuilder.DropColumn(
                name: "VisitaId",
                table: "teste");

            migrationBuilder.AddColumn<string>(
                name: "NomeTeste",
                table: "teste",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeTeste",
                table: "teste");

            migrationBuilder.AddColumn<int>(
                name: "LugarId",
                table: "teste",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisitaId",
                table: "teste",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_teste_LugarId",
                table: "teste",
                column: "LugarId");

            migrationBuilder.CreateIndex(
                name: "IX_teste_VisitaId",
                table: "teste",
                column: "VisitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_teste_Lugar_LugarId",
                table: "teste",
                column: "LugarId",
                principalTable: "Lugar",
                principalColumn: "LugarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teste_Visita_VisitaId",
                table: "teste",
                column: "VisitaId",
                principalTable: "Visita",
                principalColumn: "VisitaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
