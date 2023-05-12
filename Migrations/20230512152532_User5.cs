using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_MahdiTaremi.Migrations
{
    /// <inheritdoc />
    public partial class User5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pic_1",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "User",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "User",
                newName: "DateCreate");

            migrationBuilder.AddColumn<string>(
                name: "Pic_1",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
