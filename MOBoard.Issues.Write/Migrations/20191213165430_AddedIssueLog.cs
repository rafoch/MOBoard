using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class AddedIssueLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "Issue",
                table: "Issues",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Issue",
                table: "Issues",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IssueHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ActionType = table.Column<int>(nullable: false),
                    IssueId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueHistory_Issues_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "Issue",
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueHistory_IssueId",
                table: "IssueHistory",
                column: "IssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueHistory");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "Issue",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Issue",
                table: "Issues");
        }
    }
}
