using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_MahdiTaremi.Migrations
{
    /// <inheritdoc />
    public partial class User3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Pic_1",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Pic_1",
                table: "User");
        }
    }
}
