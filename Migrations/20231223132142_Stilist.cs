using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectSteiler.Migrations
{
    public partial class Stilist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stilist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stilist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stilist_Salon_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salon",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stilist_SalonID",
                table: "Stilist",
                column: "SalonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stilist");
        }
    }
}
