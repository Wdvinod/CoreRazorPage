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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Books");
        }
    }
}
