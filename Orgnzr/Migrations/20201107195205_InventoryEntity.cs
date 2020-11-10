using Microsoft.EntityFrameworkCore.Migrations;

namespace Orgnzr.Migrations
{
    public partial class InventoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productID1",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    inventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inStockAmount = table.Column<short>(nullable: false),
                    restockAmount = table.Column<short>(nullable: false),
                    productID = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.inventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_productID",
                        column: x => x.productID,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_productID1",
                table: "Product",
                column: "productID1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_productID",
                table: "Inventory",
                column: "productID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_productID1",
                table: "Product",
                column: "productID1",
                principalTable: "Product",
                principalColumn: "productID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_productID1",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Product_productID1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "productID1",
                table: "Product");
        }
    }
}
