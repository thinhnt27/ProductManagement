using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWP.ProductManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Beverages" },
                    { 2, "Condiments" },
                    { 3, "Confections" },
                    { 4, "Dairy Products" },
                    { 5, "Grains/Cereals" },
                    { 6, "Meat/Poultry" },
                    { 7, "Produce" },
                    { 8, "Seafood" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "Chai", 18.00m, 39 },
                    { 2, 1, "Chang", 19.00m, 17 },
                    { 3, 2, "Aniseed Syrup", 10.00m, 13 },
                    { 4, 2, "Chef Anton's Cajun Seasoning", 22.00m, 53 },
                    { 5, 2, "Chef Anton's Gumbo Mix", 21.35m, 0 },
                    { 6, 2, "Grandma's Boysenberry Spread", 25.00m, 120 },
                    { 7, 7, "Uncle Bob's Organic Dried Pears", 30.00m, 15 },
                    { 8, 2, "Northwoods Cranberry Sauce", 40.00m, 6 },
                    { 9, 6, "Mishi Kobe Niku", 97.00m, 29 },
                    { 10, 8, "Ikura", 31.00m, 31 },
                    { 11, 4, "Queso Cabrales", 21.00m, 22 },
                    { 12, 4, "Queso Manchego La Pastora", 38.00m, 86 },
                    { 13, 8, "Konbu", 6.00m, 24 },
                    { 14, 7, "Tofu", 23.25m, 35 },
                    { 15, 2, "Genen Shouyu", 15.50m, 39 },
                    { 16, 3, "Pavlova", 17.45m, 52 },
                    { 17, 6, "Alice Mutton", 39.00m, 0 },
                    { 18, 8, "Carnarvon Tigers", 62.50m, 8 },
                    { 19, 3, "Teatime Chocolate Biscuits", 9.20m, 25 },
                    { 20, 3, "Sir Rodney's Marmalade", 81.00m, 40 },
                    { 21, 3, "Sir Rodney's Scones", 10.00m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
