using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmly.Data.Migrations
{
    public partial class AddedArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_CreatorId1",
                table: "Discussion");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComment_AspNetUsers_CreatorId1",
                table: "DiscussionComment");

            migrationBuilder.DropIndex(
                name: "IX_DiscussionComment_CreatorId1",
                table: "DiscussionComment");

            migrationBuilder.DropIndex(
                name: "IX_Discussion_CreatorId1",
                table: "Discussion");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "DiscussionComment");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Discussion");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Discussion",
                newName: "ThumbnailUrl");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "DiscussionComment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Discussion",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WriterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionComment_CreatorId",
                table: "DiscussionComment",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_CreatorId",
                table: "Discussion",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_WriterId",
                table: "Article",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussion_AspNetUsers_CreatorId",
                table: "Discussion",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionComment_AspNetUsers_CreatorId",
                table: "DiscussionComment",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_CreatorId",
                table: "Discussion");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComment_AspNetUsers_CreatorId",
                table: "DiscussionComment");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropIndex(
                name: "IX_DiscussionComment_CreatorId",
                table: "DiscussionComment");

            migrationBuilder.DropIndex(
                name: "IX_Discussion_CreatorId",
                table: "Discussion");

            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "Discussion",
                newName: "Thumbnail");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "DiscussionComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "DiscussionComment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Discussion",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Discussion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionComment_CreatorId1",
                table: "DiscussionComment",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_CreatorId1",
                table: "Discussion",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussion_AspNetUsers_CreatorId1",
                table: "Discussion",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionComment_AspNetUsers_CreatorId1",
                table: "DiscussionComment",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
