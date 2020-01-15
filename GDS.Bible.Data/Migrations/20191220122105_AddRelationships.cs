using Microsoft.EntityFrameworkCore.Migrations;

namespace GDS.Bible.Data.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TranslationId",
                table: "Verse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookNo",
                table: "Book",
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

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_BookId",
                table: "Chapter",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_TranslationId",
                table: "Chapter",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Book_BookId",
                table: "Chapter",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Translation_TranslationId",
                table: "Chapter",
                column: "TranslationId",
                principalTable: "Translation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Book_BookId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Translation_TranslationId",
                table: "Chapter");

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

            migrationBuilder.DropIndex(
                name: "IX_Chapter_BookId",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_TranslationId",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "TranslationId",
                table: "Verse");

            migrationBuilder.DropColumn(
                name: "BookNo",
                table: "Book");
        }
    }
}
