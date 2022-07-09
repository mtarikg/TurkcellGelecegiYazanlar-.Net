using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bootshop.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Phones" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Laptops" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "TVs" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreatedDate", "Description", "Discount", "ImageURL", "ModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg", null, "IPhone 12", 25000.0 },
                    { 2, 1, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg", null, "IPhone 13", 25000.0 },
                    { 3, 1, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg", null, "IPhone 14", 25000.0 },
                    { 4, 1, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/41/200-200/10698988879922.jpg", null, "IPhone 16", 25000.0 },
                    { 5, 2, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg", null, "Lenovo Y700", 25000.0 },
                    { 6, 2, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg", null, "Asus Y720", 25000.0 },
                    { 7, 2, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg", null, "Dell Y750", 25000.0 },
                    { 8, 2, null, null, 0.14999999999999999, "https://productimages.hepsiburada.net/s/139/200-200/110000091548721.jpg", null, "Sony Vaio", 25000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
