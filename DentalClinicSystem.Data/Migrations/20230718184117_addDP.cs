using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class addDP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Treatments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Dentists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DentistPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DentistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentistPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DentistPatients_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DentistPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "410e4bf4-f82b-4170-83b1-b598be837058");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9998001-9755-4468-80e2-2d81cfcf05f6", "AQAAAAEAACcQAAAAEJ2jeE5xA/a9W6QzM5LDe4u21FmIggdDIrovAS7se/1btMXItA3wMANEDLMkVPdKyw==", "cd0067be-5463-4725-ad3e-99f5ecddfd5b" });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "prosthetic" },
                    { 2, "surgeon" }
                });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecializationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecializationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecializationId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_SpecializationId",
                table: "Treatments",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dentists_SpecializationId",
                table: "Dentists",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_DentistPatients_DentistId",
                table: "DentistPatients",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_DentistPatients_PatientId",
                table: "DentistPatients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dentists_Specialization_SpecializationId",
                table: "Dentists",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Specialization_SpecializationId",
                table: "Treatments",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentists_Specialization_SpecializationId",
                table: "Dentists");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Specialization_SpecializationId",
                table: "Treatments");

            migrationBuilder.DropTable(
                name: "DentistPatients");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_SpecializationId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Dentists_SpecializationId",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Dentists");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3d41637a-ed54-41eb-8636-03d35bc3943e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14d04cb9-5e7e-4faf-8cf3-38d27c50ad68", "AQAAAAEAACcQAAAAEHkQEU/FXC8AaVajnKaz4UaAul0AO2r170CvBEB/NntuTSkEk+zBlptfsac98h9AqA==", "d5fe2e4d-58cf-42a9-a573-8c06c3a41ef2" });
        }
    }
}
