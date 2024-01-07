using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tonko_Zsanett_Proiect.Migrations
{
    public partial class Furnizor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FurnizorID",
                table: "Produs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Furnizor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeFurnizor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnizor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_FurnizorID",
                table: "Produs",
                column: "FurnizorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Furnizor_FurnizorID",
                table: "Produs",
                column: "FurnizorID",
                principalTable: "Furnizor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Furnizor_FurnizorID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "Furnizor");

            migrationBuilder.DropIndex(
                name: "IX_Produs_FurnizorID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "FurnizorID",
                table: "Produs");
        }
    }
}
