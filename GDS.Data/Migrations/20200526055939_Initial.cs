using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GDS.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bibles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    NumOfBooks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    BookNo = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ShortTitle = table.Column<string>(nullable: true),
                    Section = table.Column<int>(nullable: false),
                    NTitle = table.Column<string>(nullable: true),
                    BibleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Bibles_BibleId",
                        column: x => x.BibleId,
                        principalTable: "Bibles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BibleBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    BibleId = table.Column<Guid>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BibleBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    ChapterId = table.Column<Guid>(nullable: false),
                    ChapterNum = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verses_BibleBooks_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "BibleBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BibleId",
                table: "Books",
                column: "BibleId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleBooks_BookId",
                table: "BibleBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleBooks_LocalId",
                table: "BibleBooks",
                column: "LocalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verses_ChapterId",
                table: "Verses",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Verses_LocalId",
                table: "Verses",
                column: "LocalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verses");

            migrationBuilder.DropTable(
                name: "BibleBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Bibles");
        }
    }
}