using Microsoft.EntityFrameworkCore.Migrations;

namespace BeadDotNetApp.Migrations.StoreList
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bead",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Material = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    SizeMM = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PricePoint = table.Column<decimal>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    StoreListID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bead", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bead_StoreList_StoreListID",
                        column: x => x.StoreListID,
                        principalTable: "StoreList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Brand = table.Column<string>(nullable: true),
                    StoreListID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finding", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Finding_StoreList_StoreListID",
                        column: x => x.StoreListID,
                        principalTable: "StoreList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StringingMaterial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Price_Per_Foot = table.Column<double>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StoreListID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringingMaterial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StringingMaterial_StoreList_StoreListID",
                        column: x => x.StoreListID,
                        principalTable: "StoreList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bead_StoreListID",
                table: "Bead",
                column: "StoreListID");

            migrationBuilder.CreateIndex(
                name: "IX_Finding_StoreListID",
                table: "Finding",
                column: "StoreListID");

            migrationBuilder.CreateIndex(
                name: "IX_StringingMaterial_StoreListID",
                table: "StringingMaterial",
                column: "StoreListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bead");

            migrationBuilder.DropTable(
                name: "Finding");

            migrationBuilder.DropTable(
                name: "StringingMaterial");

            migrationBuilder.DropTable(
                name: "StoreList");
        }
    }
}
