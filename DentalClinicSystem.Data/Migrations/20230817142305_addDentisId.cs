using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class addDentisId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DentistId",
                table: "OnlineAppointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OnlineAppointments_DentistId",
                table: "OnlineAppointments",
                column: "DentistId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineAppointments_Dentists_DentistId",
                table: "OnlineAppointments",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineAppointments_Dentists_DentistId",
                table: "OnlineAppointments");

            migrationBuilder.DropIndex(
                name: "IX_OnlineAppointments_DentistId",
                table: "OnlineAppointments");

            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "OnlineAppointments");
        }
    }
}
