using Microsoft.EntityFrameworkCore.Migrations;

namespace Orgnzr.Migrations
{
    public partial class AppointmentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    appointmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointmentDay = table.Column<int>(nullable: false),
                    appoitnmentMonth = table.Column<int>(nullable: false),
                    appointmentYear = table.Column<int>(nullable: false),
                    appointmentStartHour = table.Column<int>(nullable: false),
                    appointmentStartMinute = table.Column<int>(nullable: false),
                    appointmentFinishHour = table.Column<int>(nullable: false),
                    appointmentFinishMinute = table.Column<int>(nullable: false),
                    appointmentDuration = table.Column<double>(nullable: false),
                    clientId = table.Column<int>(nullable: false),
                    serviceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.appointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Contact_clientId",
                        column: x => x.clientId,
                        principalTable: "Contact",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
