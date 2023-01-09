using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseTracker.Migrations
{
    public partial class updateUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "userID",
                table: "Engineer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "userID",
                table: "Engineer",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
