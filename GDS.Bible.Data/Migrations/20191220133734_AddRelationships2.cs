using Microsoft.EntityFrameworkCore.Migrations;

namespace GDS.Bible.Data.Migrations
{
    public partial class AddRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verse_Book_BookId",
                table: "Verse");

            migrationBuilder.DropForeignKey(
                name: "FK_Verse_Translation_TranslationId",
                table: "Verse");

            migrationBuilder.DropIndex(
                name: "IX_Verse_BookId",
                table: "Verse");

            migrationBuilder.DropIndex(
                name: "IX_Verse_TranslationId",
                table: "Verse");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Verse");

            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "Verse");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "Verse");

            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "Verse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Verse_ChapterId",
                table: "Verse",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Verse_Chapter_ChapterId",
                table: "Verse",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verse_Chapter_ChapterId",
                table: "Verse");

            migrationBuilder.DropIndex(
                name: "IX_Verse_ChapterId",
                table: "Verse");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "Verse");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Verse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Chapter",
                table: "Verse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "Verse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Verse_BookId",
                table: "Verse",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Verse_TranslationId",
                table: "Verse",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Verse_Book_BookId",
                table: "Verse",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verse_Translation_TranslationId",
                table: "Verse",
                column: "TranslationId",
                principalTable: "Translation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
