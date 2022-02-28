using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmly.Data.Migrations
{
    public partial class fixedTitlesActorsConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Actors_Actors_TitleId",
                table: "Titles_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Actors_Titles_ActorId",
                table: "Titles_Actors");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Actors_Actors_ActorId",
                table: "Titles_Actors",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Actors_Titles_TitleId",
                table: "Titles_Actors",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Actors_Actors_ActorId",
                table: "Titles_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Actors_Titles_TitleId",
                table: "Titles_Actors");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Actors_Actors_TitleId",
                table: "Titles_Actors",
                column: "TitleId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Actors_Titles_ActorId",
                table: "Titles_Actors",
                column: "ActorId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
