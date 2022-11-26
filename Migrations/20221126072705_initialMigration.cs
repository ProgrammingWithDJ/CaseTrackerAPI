using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseTracker.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<int>(nullable: false),
                    Workload = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true),
                    DateOfArrival = table.Column<DateTime>(type: "Date", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
