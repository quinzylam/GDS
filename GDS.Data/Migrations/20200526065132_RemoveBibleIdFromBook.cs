using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GDS.Data.Migrations
{
    public partial class RemoveBibleIdFromBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Bibles_BibleId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BibleId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BibleId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BibleId",
                table: "Chapters",
                column: "BibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Bibles_BibleId",
                table: "Chapters",
                column: "BibleId",
                principalTable: "Bibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Bibles_BibleId",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_BibleId",
                table: "Chapters");

            migrationBuilder.AddColumn<Guid>(
                name: "BibleId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BibleId",
                table: "Books",
                column: "BibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Bibles_BibleId",
                table: "Books",
                column: "BibleId",
                principalTable: "Bibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
