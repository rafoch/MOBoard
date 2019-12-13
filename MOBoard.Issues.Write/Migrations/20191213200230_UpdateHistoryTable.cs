using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class UpdateHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueHistory_Issues_IssueId",
                table: "IssueHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueHistory",
                table: "IssueHistory");

            migrationBuilder.RenameTable(
                name: "IssueHistory",
                newName: "IssueHistories");

            migrationBuilder.RenameIndex(
                name: "IX_IssueHistory_IssueId",
                table: "IssueHistories",
                newName: "IX_IssueHistories_IssueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueHistories",
                table: "IssueHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueHistories_Issues_IssueId",
                table: "IssueHistories",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueHistories_Issues_IssueId",
                table: "IssueHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueHistories",
                table: "IssueHistories");

            migrationBuilder.RenameTable(
                name: "IssueHistories",
                newName: "IssueHistory");

            migrationBuilder.RenameIndex(
                name: "IX_IssueHistories_IssueId",
                table: "IssueHistory",
                newName: "IX_IssueHistory_IssueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueHistory",
                table: "IssueHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueHistory_Issues_IssueId",
                table: "IssueHistory",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
