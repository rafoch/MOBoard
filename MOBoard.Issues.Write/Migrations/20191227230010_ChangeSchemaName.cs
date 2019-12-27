using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class ChangeSchemaName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "IssueHistories",
                newName: "IssueHistories",
                newSchema: "Issue");

            migrationBuilder.RenameTable(
                name: "IssueComments",
                newName: "IssueComments",
                newSchema: "Issue");

            migrationBuilder.RenameTable(
                name: "FixedVersion",
                newName: "FixedVersion",
                newSchema: "Issue");

            migrationBuilder.RenameTable(
                name: "AffectedVersion",
                newName: "AffectedVersion",
                newSchema: "Issue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "IssueHistories",
                schema: "Issue",
                newName: "IssueHistories");

            migrationBuilder.RenameTable(
                name: "IssueComments",
                schema: "Issue",
                newName: "IssueComments");

            migrationBuilder.RenameTable(
                name: "FixedVersion",
                schema: "Issue",
                newName: "FixedVersion");

            migrationBuilder.RenameTable(
                name: "AffectedVersion",
                schema: "Issue",
                newName: "AffectedVersion");
        }
    }
}
