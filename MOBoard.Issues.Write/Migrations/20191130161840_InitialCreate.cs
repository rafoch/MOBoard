using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Issue");

            migrationBuilder.CreateTable(
                name: "Issues",
                schema: "Issue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues",
                schema: "Issue");
        }
    }
}
