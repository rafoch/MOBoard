using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class AddedProjectNumberForIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssueFullNumber",
                schema: "Issue",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssueNumber",
                schema: "Issue",
                table: "Issues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                schema: "Issue",
                table: "Issues",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueFullNumber",
                schema: "Issue",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssueNumber",
                schema: "Issue",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Issue",
                table: "Issues");
        }
    }
}
