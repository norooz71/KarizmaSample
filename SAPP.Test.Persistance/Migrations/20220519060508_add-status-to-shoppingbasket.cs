using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karizma.Sample.Persistance.Migrations
{
    public partial class addstatustoshoppingbasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ShoppingBasket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShoppingBasket");
        }
    }
}
