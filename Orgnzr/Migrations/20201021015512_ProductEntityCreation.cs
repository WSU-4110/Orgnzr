using Microsoft.EntityFrameworkCore.Migrations;

namespace Orgnzr.Migrations
{
    public partial class ProductEntityCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    clientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    emailAddress = table.Column<string>(nullable: true),
                    preferredContact = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.clientId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(nullable: true),
                    productDescription = table.Column<string>(nullable: true),
                    productBrand = table.Column<string>(nullable: true),
                    productCategory = table.Column<string>(nullable: true),
                    buyPrice = table.Column<double>(nullable: false),
                    sellPrice = table.Column<double>(nullable: false),
                    inStockAmount = table.Column<short>(nullable: false),
                    restockAmount = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact"); 

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
