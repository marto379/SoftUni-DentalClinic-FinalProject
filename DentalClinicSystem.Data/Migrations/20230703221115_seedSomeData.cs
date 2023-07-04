using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class seedSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "Description", "InvoiceId", "Name", "Price" },
                values: new object[] { 1, "Super white teeth", null, "Whitening", 99.00m });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "Description", "InvoiceId", "Name", "Price" },
                values: new object[] { 2, "Painless extraction", null, "Tooth Extraction", 79.99m });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "Description", "InvoiceId", "Name", "Price" },
                values: new object[] { 3, "Dental procedure used to treat infection at the centre of a tooth", null, "Root canal treatment", 149.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
