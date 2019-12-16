using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Board.Write.Migrations
{
    public partial class AddProjectIdColumnForBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                schema: "Board",
                table: "Boards",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Board",
                table: "Boards");
        }
    }
}
