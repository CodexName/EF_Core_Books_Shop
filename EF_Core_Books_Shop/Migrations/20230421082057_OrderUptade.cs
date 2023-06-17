using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Books_Shop.Migrations
{
    /// <inheritdoc />
    public partial class OrderUptade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Data",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Orders");
        }
    }
}
