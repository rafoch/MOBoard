using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class FixIssueTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueComments_Issues_IssueId",
                schema: "Issue",
                table: "IssueComments");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueHistories_Issues_IssueId",
                schema: "Issue",
                table: "IssueHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueHistories",
                schema: "Issue",
                table: "IssueHistories");

            migrationBuilder.RenameTable(
                name: "IssueHistories",
                schema: "Issue",
                newName: "IssueHistory",
                newSchema: "Issue");

            migrationBuilder.RenameIndex(
                name: "IX_IssueHistories_IssueId",
                schema: "Issue",
                table: "IssueHistory",
                newName: "IX_IssueHistory_IssueId");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                schema: "Issue",
                table: "IssueComments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                schema: "Issue",
                table: "IssueHistory",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueHistory",
                schema: "Issue",
                table: "IssueHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueComments_Issues_IssueId",
                schema: "Issue",
                table: "IssueComments",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueHistory_Issues_IssueId",
                schema: "Issue",
                table: "IssueHistory",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueComments_Issues_IssueId",
                schema: "Issue",
                table: "IssueComments");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueHistory_Issues_IssueId",
                schema: "Issue",
                table: "IssueHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueHistory",
                schema: "Issue",
                table: "IssueHistory");

            migrationBuilder.RenameTable(
                name: "IssueHistory",
                schema: "Issue",
                newName: "IssueHistories",
                newSchema: "Issue");

            migrationBuilder.RenameIndex(
                name: "IX_IssueHistory_IssueId",
                schema: "Issue",
                table: "IssueHistories",
                newName: "IX_IssueHistories_IssueId");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                schema: "Issue",
                table: "IssueComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueId",
                schema: "Issue",
                table: "IssueHistories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueHistories",
                schema: "Issue",
                table: "IssueHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueComments_Issues_IssueId",
                schema: "Issue",
                table: "IssueComments",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueHistories_Issues_IssueId",
                schema: "Issue",
                table: "IssueHistories",
                column: "IssueId",
                principalSchema: "Issue",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
