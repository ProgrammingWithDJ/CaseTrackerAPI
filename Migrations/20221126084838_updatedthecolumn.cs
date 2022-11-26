using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseTracker.Migrations
{
    public partial class updatedthecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Survey",
                table: "Cases",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Survey",
                table: "Cases");
        }
    }
}
