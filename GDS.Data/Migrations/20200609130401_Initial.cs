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
                    Description = table.Column<string>(nullable: true),
                    Copyright = table.Column<string>(nullable: true),
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
                    Title = table.Column<string>(nullable: true),
                    ShortTitle = table.Column<string>(nullable: true),
                    Section = table.Column<int>(nullable: false),
                    NTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Headings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    Chapter = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BibleBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    BibleId = table.Column<Guid>(nullable: false),
                    BookCode = table.Column<int>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BibleBooks_Bibles_BibleId",
                        column: x => x.BibleId,
                        principalTable: "Bibles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    HeadingId = table.Column<Guid>(nullable: true),
                    BibleBookId = table.Column<Guid>(nullable: false),
                    ChapterNum = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verses_BibleBooks_BibleBookId",
                        column: x => x.BibleBookId,
                        principalTable: "BibleBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verses_Headings_HeadingId",
                        column: x => x.HeadingId,
                        principalTable: "Headings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BibleBooks_BibleId",
                table: "BibleBooks",
                column: "BibleId");

            migrationBuilder.CreateIndex(
                name: "IX_BibleBooks_BookCode",
                table: "BibleBooks",
                column: "BookCode");

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
                name: "IX_BibleBooks_Version",
                table: "BibleBooks",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_Bibles_Code",
                table: "Bibles",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Code",
                table: "Books",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShortTitle",
                table: "Books",
                column: "ShortTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Headings_Chapter",
                table: "Headings",
                column: "Chapter");

            migrationBuilder.CreateIndex(
                name: "IX_Headings_Position",
                table: "Headings",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Verses_BibleBookId",
                table: "Verses",
                column: "BibleBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Verses_ChapterNum",
                table: "Verses",
                column: "ChapterNum");

            migrationBuilder.CreateIndex(
                name: "IX_Verses_HeadingId",
                table: "Verses",
                column: "HeadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Verses_LocalId",
                table: "Verses",
                column: "LocalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verses_Position",
                table: "Verses",
                column: "Position");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verses");

            migrationBuilder.DropTable(
                name: "BibleBooks");

            migrationBuilder.DropTable(
                name: "Headings");

            migrationBuilder.DropTable(
                name: "Bibles");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
