using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmly.Data.Migrations
{
    public partial class FixedTrailerLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrailerLinkEmbed",
                table: "Titles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailerLinkEmbed",
                table: "Titles");
        }
    }
}
