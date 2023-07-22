using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinicSystem.Data.Migrations
{
    public partial class addSomeTreatments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Cosmetic teeth whitening uses hydrogen peroxide to gently bleach out stains from the enamel. This is a highly concentrated form that is much stronger than what you can get at the drugstore. This solution is applied as a gel or paste to the teeth.");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Tooth extraction refers to the complete removal of one or more teeth from the mouth. This is a procedure that is usually performed by a dental surgeon. Milk teeth may be removed from a child's mouth without intervention from the dentist as they loosen as a matter of course to give way to permanent teeth.");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Root canal treatment is a dental procedure that relieves pain caused by an infected or abscessed tooth. During the root canal process, the inflamed pulp is removed. The surfaces inside the tooth are then cleaned and disinfected, and a filling is placed to seal the space.");

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "Description", "InvoiceId", "Name", "Price", "SpecializationId" },
                values: new object[,]
                {
                    { 4, "The most common and simplest treatment to combat caries is dental filling, which consists of cleaning the affected area until a cavity is formed, in order to eliminate the tissues that have been damaged by bacterial acidity. Once this process has been carried out, the cavity must be filled to return the tooth to its original shape.", null, "Caries treatment", 149.99m, 1 },
                    { 5, "Teeth cleaning (also known as prophylaxis, literally a preventive treatment of a disease) is a procedure for the removal of tartar (mineralized plaque) that may develop even with careful brushing and flossing, especially in areas that are difficult to reach in routine toothbrushing.", null, "Teeth cleaning", 149.99m, 1 },
                    { 6, "Prosthodontic treatments include veneers, crowns, bridges, dental implants and dentures. Treatment can be for a single tooth at a time but it can also be on a more comprehensive scale where it involves several and sometimes all teeth.", null, "Prosthodontic treatment", 149.99m, 1 },
                    { 7, "Orthodontics is a dental specialty focused on aligning your bite and straightening your teeth. You might need to see an orthodontist if you have crooked, overlapped, twisted or gapped teeth. Common orthodontic treatments include traditional braces, clear aligners and removable retainers.", null, "Orthodontics", 149.99m, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Super white teeth");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Painless extraction");

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Dental procedure used to treat infection at the centre of a tooth");
        }
    }
}
