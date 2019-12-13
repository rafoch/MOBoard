using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Auth.Users.Write.Migrations
{
    public partial class UpdateBaseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Auth",
                table: "Tokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Auth",
                table: "Tokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                schema: "Auth",
                table: "Tokens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Auth",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "Auth",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                schema: "Auth",
                table: "Tokens");
        }
    }
}
