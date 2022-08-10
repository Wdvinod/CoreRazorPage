using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreRazorPage.Migrations
{
    public partial class publisheraddedtobook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Books",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "948c7105-ec45-42ea-923b-055acf193a3e", "671ddda3-1873-43e9-8db2-1ee874c2a513", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "948c7105-ec45-42ea-923b-055acf193a3e");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Books");
        }
    }
}
