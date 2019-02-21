using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZadatakNeki.Migrations
{
    public partial class ponovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "KrajKoriscenja",
                table: "OsobaUredjaj",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "KrajKoriscenja",
                table: "OsobaUredjaj",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
