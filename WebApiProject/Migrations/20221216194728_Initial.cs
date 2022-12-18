using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectsApp",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    startdate = table.Column<DateTime>(nullable: false),
                    completiondate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsApp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TasksApp",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    priority = table.Column<int>(nullable: false),
                    ProjectAppStoredID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksApp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TasksApp_ProjectsApp_ProjectAppStoredID",
                        column: x => x.ProjectAppStoredID,
                        principalTable: "ProjectsApp",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsApp_ID",
                table: "ProjectsApp",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TasksApp_ProjectAppStoredID",
                table: "TasksApp",
                column: "ProjectAppStoredID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasksApp");

            migrationBuilder.DropTable(
                name: "ProjectsApp");
        }
    }
}
