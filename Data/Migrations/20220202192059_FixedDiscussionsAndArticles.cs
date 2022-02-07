using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmly.Data.Migrations
{
    public partial class FixedDiscussionsAndArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_AspNetUsers_WriterId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_CreatorId",
                table: "Discussion");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComment_AspNetUsers_CreatorId",
                table: "DiscussionComment");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComment_Discussion_DiscussionId",
                table: "DiscussionComment");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComment_DiscussionComment_ParentCommentId",
                table: "DiscussionComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscussionComment",
                table: "DiscussionComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discussion",
                table: "Discussion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "DiscussionComment",
                newName: "DiscussionComments");

            migrationBuilder.RenameTable(
                name: "Discussion",
                newName: "Discussions");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_DiscussionComment_ParentCommentId",
                table: "DiscussionComments",
                newName: "IX_DiscussionComments_ParentCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscussionComment_DiscussionId",
                table: "DiscussionComments",
                newName: "IX_DiscussionComments_DiscussionId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscussionComment_CreatorId",
                table: "DiscussionComments",
                newName: "IX_DiscussionComments_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Discussion_CreatorId",
                table: "Discussions",
                newName: "IX_Discussions_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_WriterId",
                table: "Articles",
                newName: "IX_Articles_WriterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscussionComments",
                table: "DiscussionComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discussions",
                table: "Discussions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_WriterId",
                table: "Articles",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionComments_AspNetUsers_CreatorId",
                table: "DiscussionComments",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionComments_DiscussionComments_ParentCommentId",
                table: "DiscussionComments",
                column: "ParentCommentId",
                principalTable: "DiscussionComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionComments_Discussions_DiscussionId",
                table: "DiscussionComments",
                column: "DiscussionId",
                principalTable: "Discussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_AspNetUsers_CreatorId",
                table: "Discussions",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_WriterId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComments_AspNetUsers_CreatorId",
                table: "DiscussionComments");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComments_DiscussionComments_ParentCommentId",
                table: "DiscussionComments");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscussionComments_Discussions_DiscussionId",
                table: "DiscussionComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_AspNetUsers_CreatorId",
                table: "Discussions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discussions",
                table: "Discussions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscussionComments",
                table: "DiscussionComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Discussions",
                newName: "Discussion");

            migrationBuilder.RenameTable(
                name: "DiscussionComments",
                newName: "DiscussionComment");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_Discussions_CreatorId",
                table: "Discussion",
                newName: "IX_Discussion_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscussionComments_ParentCommentId",
                table: "DiscussionComment",
                newName: "IX_DiscussionComment_ParentCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscussionComments_DiscussionId",
                table: "DiscussionComment",
                newName: "IX_DiscussionComment_DiscussionId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscussionComments_CreatorId",
                table: "DiscussionComment",
                newName: "IX_DiscussionComment_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_WriterId",
                table: "Article",
                newName: "IX_Article_WriterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discussion",
                table: "Discussion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscussionComment",
                table: "DiscussionComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_AspNetUsers_WriterId",
                table: "Article",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionComment_Discussion_DiscussionId",
                table: "DiscussionComment",
                column: "DiscussionId",
                principalTable: "Discussion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscussionComment_DiscussionComment_ParentCommentId",
                table: "DiscussionComment",
                column: "ParentCommentId",
                principalTable: "DiscussionComment",
                principalColumn: "Id");
        }
    }
}
