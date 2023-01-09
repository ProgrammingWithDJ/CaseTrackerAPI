using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseTracker.Migrations
{
    public partial class AddBlogCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "engineerId",
                table: "Cases",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Engineer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    userID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_engineerId",
                table: "Cases",
                column: "engineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Engineer_engineerId",
                table: "Cases",
                column: "engineerId",
                principalTable: "Engineer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Engineer_engineerId",
                table: "Cases");

            migrationBuilder.DropTable(
                name: "Engineer");

            migrationBuilder.DropIndex(
                name: "IX_Cases_engineerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "engineerId",
                table: "Cases");
        }
    }
}
