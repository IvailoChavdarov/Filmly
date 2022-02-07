using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmly.Data.Migrations
{
    public partial class fixedNamingsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Similars_Titles_SimilarId",
                table: "Similars");

            migrationBuilder.RenameColumn(
                name: "writers",
                table: "Titles",
                newName: "Writers");

            migrationBuilder.RenameColumn(
                name: "tagline",
                table: "Titles",
                newName: "Tagline");

            migrationBuilder.RenameColumn(
                name: "stars",
                table: "Titles",
                newName: "Stars");

            migrationBuilder.RenameColumn(
                name: "languages",
                table: "Titles",
                newName: "Languages");

            migrationBuilder.RenameColumn(
                name: "keywords",
                table: "Titles",
                newName: "Keywords");

            migrationBuilder.RenameColumn(
                name: "imDbRatingVotes",
                table: "Titles",
                newName: "IMDbRatingVotes");

            migrationBuilder.RenameColumn(
                name: "imDbRating",
                table: "Titles",
                newName: "IMDbRating");

            migrationBuilder.RenameColumn(
                name: "genres",
                table: "Titles",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "directors",
                table: "Titles",
                newName: "Directors");

            migrationBuilder.RenameColumn(
                name: "countries",
                table: "Titles",
                newName: "Countries");

            migrationBuilder.RenameColumn(
                name: "contentRating",
                table: "Titles",
                newName: "ContentRating");

            migrationBuilder.RenameColumn(
                name: "companies",
                table: "Titles",
                newName: "Companies");

            migrationBuilder.CreateTable(
                name: "TitlesSimplified",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInApi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDbRating = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlesSimplified", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Similars_TitlesSimplified_SimilarId",
                table: "Similars",
                column: "SimilarId",
                principalTable: "TitlesSimplified",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Similars_TitlesSimplified_SimilarId",
                table: "Similars");

            migrationBuilder.DropTable(
                name: "TitlesSimplified");

            migrationBuilder.RenameColumn(
                name: "Writers",
                table: "Titles",
                newName: "writers");

            migrationBuilder.RenameColumn(
                name: "Tagline",
                table: "Titles",
                newName: "tagline");

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "Titles",
                newName: "stars");

            migrationBuilder.RenameColumn(
                name: "Languages",
                table: "Titles",
                newName: "languages");

            migrationBuilder.RenameColumn(
                name: "Keywords",
                table: "Titles",
                newName: "keywords");

            migrationBuilder.RenameColumn(
                name: "IMDbRatingVotes",
                table: "Titles",
                newName: "imDbRatingVotes");

            migrationBuilder.RenameColumn(
                name: "IMDbRating",
                table: "Titles",
                newName: "imDbRating");

            migrationBuilder.RenameColumn(
                name: "Genres",
                table: "Titles",
                newName: "genres");

            migrationBuilder.RenameColumn(
                name: "Directors",
                table: "Titles",
                newName: "directors");

            migrationBuilder.RenameColumn(
                name: "Countries",
                table: "Titles",
                newName: "countries");

            migrationBuilder.RenameColumn(
                name: "ContentRating",
                table: "Titles",
                newName: "contentRating");

            migrationBuilder.RenameColumn(
                name: "Companies",
                table: "Titles",
                newName: "companies");

            migrationBuilder.AddForeignKey(
                name: "FK_Similars_Titles_SimilarId",
                table: "Similars",
                column: "SimilarId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
