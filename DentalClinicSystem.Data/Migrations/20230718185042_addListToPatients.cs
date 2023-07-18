using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class addListToPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Dentists_DentistId",
                table: "Patients");

            migrationBuilder.AlterColumn<Guid>(
                name: "DentistId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "96f67b93-e4eb-46aa-92fb-92f451cd905d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d91a6fb4-2bfd-430c-8dcd-591d05e4bfdf", "AQAAAAEAACcQAAAAEAUKwIvTFRsu03wcMmiAypQHc960d5bPDqCbPPKUf3OYYCEJ3MvoUQceZQ2V0YjYSw==", "e02cfb90-9acd-4499-aeb8-2efc69125df5" });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Dentists_DentistId",
                table: "Patients",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Dentists_DentistId",
                table: "Patients");

            migrationBuilder.AlterColumn<Guid>(
                name: "DentistId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Dentists_DentistId",
                table: "Patients",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
