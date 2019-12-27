using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class AddIssueVersionMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AffectedVersion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    VersionId = table.Column<Guid>(nullable: false),
                    IssueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffectedVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AffectedVersion_Issues_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "Issue",
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedVersion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    VersionId = table.Column<Guid>(nullable: false),
                    IssueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedVersion_Issues_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "Issue",
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffectedVersion_IssueId",
                table: "AffectedVersion",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedVersion_IssueId",
                table: "FixedVersion",
                column: "IssueId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffectedVersion");

            migrationBuilder.DropTable(
                name: "FixedVersion");
        }
    }
}
