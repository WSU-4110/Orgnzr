using Microsoft.EntityFrameworkCore.Migrations;

namespace Orgnzr.Migrations
{
    public partial class ServicesEntityCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
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
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
