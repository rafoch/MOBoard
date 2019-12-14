using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Board.Write.Migrations
{
    public partial class UpdateBoardSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Board");

            migrationBuilder.RenameTable(
                name: "Columns",
                newName: "Columns",
                newSchema: "Board");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "Boards",
                newSchema: "Board");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Columns",
                schema: "Board",
                newName: "Columns");

            migrationBuilder.RenameTable(
                name: "Boards",
                schema: "Board",
                newName: "Boards");
        }
    }
}
