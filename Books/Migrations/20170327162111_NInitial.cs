using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Migrations
{
    public partial class NInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Book_BookID",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_BookID",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Author");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "Author",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_BookID",
                table: "Author",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Book_BookID",
                table: "Author",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
