using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe21ShopMalter.Data.Migrations
{
    public partial class Mileage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Cars",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Cars");
        }
    }
}
