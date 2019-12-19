using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Auth.Users.Write.Migrations
{
    public partial class AddRemovedAddColumnForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Auth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                schema: "Auth",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Auth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                schema: "Auth",
                table: "AspNetUsers");
        }
    }
}
