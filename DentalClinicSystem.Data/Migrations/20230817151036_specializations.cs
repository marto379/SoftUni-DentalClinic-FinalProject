using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class specializations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentists_Specialization_SpecializationId",
                table: "Dentists");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Specialization_SpecializationId",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization");

            migrationBuilder.RenameTable(
                name: "Specialization",
                newName: "Specializations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dentists_Specializations_SpecializationId",
                table: "Dentists",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Specializations_SpecializationId",
                table: "Treatments",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentists_Specializations_SpecializationId",
                table: "Dentists");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Specializations_SpecializationId",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specializations",
                table: "Specializations");

            migrationBuilder.RenameTable(
                name: "Specializations",
                newName: "Specialization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialization",
                table: "Specialization",
                column: "Id");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
