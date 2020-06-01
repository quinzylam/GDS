using Microsoft.EntityFrameworkCore.Migrations;

namespace GDS.Data.Migrations
{
    public partial class SimplifyChapters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "BookCode",
               table: "Chapters");

            migrationBuilder.AddColumn<int>(
                name: "BookCode",
                table: "Chapters",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortTitle",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verses_ChapterNum",
                table: "Verses",
                column: "ChapterNum");

            migrationBuilder.CreateIndex(
                name: "IX_Verses_Position",
                table: "Verses",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BookCode",
                table: "Chapters",
                column: "BookCode");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_Version",
                table: "Chapters",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Code",
                table: "Books",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShortTitle",
                table: "Books",
                column: "ShortTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Bibles_Code",
                table: "Bibles",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Verses_ChapterNum",
                table: "Verses");

            migrationBuilder.DropIndex(
                name: "IX_Verses_Position",
                table: "Verses");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_BookCode",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_Version",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Books_Code",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ShortTitle",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Bibles_Code",
                table: "Bibles");

            migrationBuilder.DropColumn(
                name: "BookCode",
                table: "Chapters");

            migrationBuilder.AddColumn<string>(
                name: "BookCode",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: true
                );

            migrationBuilder.AlterColumn<string>(
                name: "ShortTitle",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}