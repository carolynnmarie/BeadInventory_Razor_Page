using Microsoft.EntityFrameworkCore.Migrations;

namespace BeadDotNetApp.Migrations.Finding
{
    public partial class InitialCreateFinding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finding",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FindingCategory = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Length_CM = table.Column<double>(nullable: false),
                    Price_Point = table.Column<double>(nullable: false),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finding", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finding");
        }
    }
}
