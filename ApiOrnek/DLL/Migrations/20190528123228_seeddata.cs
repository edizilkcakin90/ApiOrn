using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Age", "Email", "IdentityNo", "LastName", "Name", "Password", "Sex" },
                values: new object[,]
                {
                    { 1, (short)29, "edizilkcakin@gmail.com", "12345678941", "Ilkcakin", "Ediz", "123456", "m" },
                    { 2, (short)33, "onuruygur@gmail.com", "12345678942", "Uygur", "Onur", "1234567", "m" },
                    { 3, (short)30, "ahmetasd@gmail.com", "12345678943", "Asd", "Ahmet", "12345678", "m" },
                    { 4, (short)27, "mehmetdsa@gmail.com", "12345678944", "Dsa", "Mehmet", "123456789", "m" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
