using Microsoft.EntityFrameworkCore.Migrations;

namespace GDS.Data.Migrations
{
    public partial class FixChapters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookCode",
                table: "Chapters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCode",
                table: "Chapters");
        }
    }
}
