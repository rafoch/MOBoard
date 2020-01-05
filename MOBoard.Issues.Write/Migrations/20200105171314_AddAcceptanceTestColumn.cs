using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Issues.Write.Migrations
{
    public partial class AddAcceptanceTestColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcceptanceTests",
                schema: "Issue",
                table: "Issues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptanceTests",
                schema: "Issue",
                table: "Issues");
        }
    }
}
