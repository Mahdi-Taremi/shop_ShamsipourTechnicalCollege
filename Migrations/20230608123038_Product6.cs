using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_MahdiTaremi.Migrations
{
    /// <inheritdoc />
    public partial class Product6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pic_1",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pic_1",
                table: "Product");
        }
    }
}
