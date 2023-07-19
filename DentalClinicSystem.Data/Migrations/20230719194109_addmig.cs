using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class addmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Dentists_DentistId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "TreatmentAppointments");

            migrationBuilder.DropTable(
                name: "UsersAppointments");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DentistId",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DentistId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "UsersAppointments",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAppointments", x => new { x.PatientId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_UsersAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersAppointments_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "96f67b93-e4eb-46aa-92fb-92f451cd905d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "d91a6fb4-2bfd-430c-8dcd-591d05e4bfdf", null, false, false, null, null, "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEAUKwIvTFRsu03wcMmiAypQHc960d5bPDqCbPPKUf3OYYCEJ3MvoUQceZQ2V0YjYSw==", null, false, "e02cfb90-9acd-4499-aeb8-2efc69125df5", false, "admin@abv.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DentistId",
                table: "Patients",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentAppointments_AppointmentId",
                table: "TreatmentAppointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAppointments_AppointmentId",
                table: "UsersAppointments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Dentists_DentistId",
                table: "Patients",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id");
        }
    }
}
