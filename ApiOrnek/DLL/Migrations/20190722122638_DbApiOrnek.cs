using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DbApiOrnek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Age = table.Column<short>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IdentityNo = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Age", "Email", "IdentityNo", "LastName", "Name", "Password", "Role", "Sex", "Token" },
                values: new object[,]
                {
                    { 1, (short)29, "edizilkcakin@gmail.com", "12345678941", "Ilkcakin", "Ediz", "123456", "Admin", "m", null },
                    { 2, (short)33, "onuruygur@gmail.com", "12345678942", "Uygur", "Onur", "1234567", "User", "m", null },
                    { 3, (short)30, "ahmetasd@gmail.com", "12345678943", "Asd", "Ahmet", "12345678", "User", "m", null },
                    { 4, (short)27, "mehmetdsa@gmail.com", "12345678944", "Dsa", "Mehmet", "123456789", "User", "m", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
