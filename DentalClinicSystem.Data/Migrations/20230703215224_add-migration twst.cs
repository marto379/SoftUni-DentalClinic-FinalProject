using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class addmigrationtwst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Appointments_AppointmentId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_AppointmentId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Treatments");

            migrationBuilder.CreateTable(
                name: "TreatmentsAppoinments",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentsAppoinments", x => new { x.TreatmentId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_TreatmentsAppoinments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentsAppoinments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentsAppoinments_AppointmentId",
                table: "TreatmentsAppoinments",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentsAppoinments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Treatments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AppointmentId",
                table: "Treatments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Appointments_AppointmentId",
                table: "Treatments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }
    }
}
