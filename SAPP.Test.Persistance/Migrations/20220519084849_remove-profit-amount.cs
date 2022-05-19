using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karizma.Sample.Persistance.Migrations
{
    public partial class removeprofitamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitAmount",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfitAmount",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
