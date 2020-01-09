using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class AddReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueWorklog_Issues_IssueId",
                schema: "Issue",
                table: "IssueWorklog");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                schema: "Issue",
                table: "IssueWorklog",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueWorklog_Issues_IssueId",
                schema: "Issue",
                table: "IssueWorklog",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueWorklog_Issues_IssueId",
                schema: "Issue",
                table: "IssueWorklog");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                schema: "Issue",
                table: "IssueWorklog",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_IssueWorklog_Issues_IssueId",
                schema: "Issue",
                table: "IssueWorklog",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
