using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class addClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlinePatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnlineUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlinePatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlinePatients_AspNetUsers_OnlineUserId",
                        column: x => x.OnlineUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineAppointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OnlinePatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineAppointments_OnlinePatients_OnlinePatientId",
                        column: x => x.OnlinePatientId,
                        principalTable: "OnlinePatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineAppointments_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlinePatientAppointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OnlinePatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OnlineAppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlinePatientAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlinePatientAppointments_OnlineAppointments_OnlineAppointmentId",
                        column: x => x.OnlineAppointmentId,
                        principalTable: "OnlineAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlinePatientAppointments_OnlinePatients_OnlinePatientId",
                        column: x => x.OnlinePatientId,
                        principalTable: "OnlinePatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineAppointments_OnlinePatientId",
                table: "OnlineAppointments",
                column: "OnlinePatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineAppointments_TreatmentId",
                table: "OnlineAppointments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlinePatientAppointments_OnlineAppointmentId",
                table: "OnlinePatientAppointments",
                column: "OnlineAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlinePatientAppointments_OnlinePatientId",
                table: "OnlinePatientAppointments",
                column: "OnlinePatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlinePatients_OnlineUserId",
                table: "OnlinePatients",
                column: "OnlineUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlinePatientAppointments");

            migrationBuilder.DropTable(
                name: "OnlineAppointments");

            migrationBuilder.DropTable(
                name: "OnlinePatients");
        }
    }
}
