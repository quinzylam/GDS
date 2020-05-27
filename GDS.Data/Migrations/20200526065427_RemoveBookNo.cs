using Microsoft.EntityFrameworkCore.Migrations;

namespace GDS.Data.Migrations
{
    public partial class RemoveBookNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookNo",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookNo",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
