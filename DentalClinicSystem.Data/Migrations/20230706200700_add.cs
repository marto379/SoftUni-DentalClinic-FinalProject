using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentsAppoinments");

            migrationBuilder.CreateTable(
                name: "TreatmentAppointments",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentAppointments", x => new { x.TreatmentId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_TreatmentAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentAppointments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TreatmentId",
                table: "Appointments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentAppointments_AppointmentId",
                table: "TreatmentAppointments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Treatments_TreatmentId",
                table: "Appointments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Treatments_TreatmentId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "TreatmentAppointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TreatmentId",
                table: "Appointments");

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentsAppoinments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentsAppoinments_AppointmentId",
                table: "TreatmentsAppoinments",
                column: "AppointmentId");
        }
    }
}
