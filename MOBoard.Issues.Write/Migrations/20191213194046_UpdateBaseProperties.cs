using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class UpdateBaseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Issue",
                table: "Issues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Issue",
                table: "Issues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                schema: "Issue",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "IssueHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "IssueHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                table: "IssueHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Issue",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "Issue",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                schema: "Issue",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "IssueHistory");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "IssueHistory");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                table: "IssueHistory");
        }
    }
}
