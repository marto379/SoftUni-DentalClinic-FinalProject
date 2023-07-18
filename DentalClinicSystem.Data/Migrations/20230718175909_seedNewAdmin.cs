using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class seedNewAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "14d04cb9-5e7e-4faf-8cf3-38d27c50ad68", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEHkQEU/FXC8AaVajnKaz4UaAul0AO2r170CvBEB/NntuTSkEk+zBlptfsac98h9AqA==", "d5fe2e4d-58cf-42a9-a573-8c06c3a41ef2", "admin@abv.bg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "001d06e9-05fd-482c-bd75-15a8b1235412");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ccd79c10-538a-4dfd-8103-286ee08f5947", "ADMIN", "AQAAAAEAACcQAAAAECKkEynBLu4lACWPqDoI+2q1iOKOXCoQDgo3EE0Mss6moo8G+0FRYBFVi6ZqugDKgQ==", "a7763fd4-c89a-4377-bf22-cb416fe76251", "admin" });
        }
    }
}
