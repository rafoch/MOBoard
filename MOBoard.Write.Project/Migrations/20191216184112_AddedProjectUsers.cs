using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOBoard.Write.Project.Migrations
{
    public partial class AddedProjectUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectPerson",
                schema: "Board",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    RemovedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    PermissionType = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPerson_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Board",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_ProjectId",
                schema: "Board",
                table: "ProjectPerson",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPerson",
                schema: "Board");
        }
    }
}
