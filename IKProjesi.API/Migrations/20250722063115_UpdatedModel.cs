using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKProjesi.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_PozisyonID",
                table: "Calisanlar",
                column: "PozisyonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Pozisyonlar_PozisyonID",
                table: "Calisanlar",
                column: "PozisyonID",
                principalTable: "Pozisyonlar",
                principalColumn: "PozisyonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Pozisyonlar_PozisyonID",
                table: "Calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_PozisyonID",
                table: "Calisanlar");
        }
    }
}
