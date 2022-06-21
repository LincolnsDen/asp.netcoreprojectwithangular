using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularMonthlyProject.Migrations
{
    public partial class angmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fruitSuppliers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fruitSuppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "fruits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fruits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_fruits_seasons_SeasonID",
                        column: x => x.SeasonID,
                        principalTable: "seasons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vegetables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vegetables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_vegetables_seasons_SeasonID",
                        column: x => x.SeasonID,
                        principalTable: "seasons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fruits_SeasonID",
                table: "fruits",
                column: "SeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_vegetables_SeasonID",
                table: "vegetables",
                column: "SeasonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fruits");

            migrationBuilder.DropTable(
                name: "fruitSuppliers");

            migrationBuilder.DropTable(
                name: "vegetables");

            migrationBuilder.DropTable(
                name: "seasons");
        }
    }
}
