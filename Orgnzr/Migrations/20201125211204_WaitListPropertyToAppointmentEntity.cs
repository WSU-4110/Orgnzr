using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orgnzr.Migrations
{
    public partial class WaitListPropertyToAppointmentEntity : Migration
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
                    restockAmount = table.Column<short>(nullable: false),
                    productID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productID);
                    table.ForeignKey(
                        name: "FK_Product_Product_productID1",
                        column: x => x.productID1,
                        principalTable: "Product",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    serviceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceName = table.Column<string>(nullable: true),
                    serviceDescription = table.Column<string>(nullable: true),
                    serviceCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.serviceID);
                });

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

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    appointmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointmentStartTime = table.Column<DateTime>(nullable: false),
                    appointmentFinishTime = table.Column<DateTime>(nullable: false),
                    clientId = table.Column<int>(nullable: true),
                    serviceId = table.Column<int>(nullable: true),
                    waitlistAppt = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.appointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Contact_clientId",
                        column: x => x.clientId,
                        principalTable: "Contact",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "serviceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_clientId",
                table: "Appointments",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_serviceId",
                table: "Appointments",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_productID",
                table: "Inventory",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_productID1",
                table: "Product",
                column: "productID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
