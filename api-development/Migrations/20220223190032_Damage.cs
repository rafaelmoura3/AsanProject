using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class Damage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "SpaceShipProblems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Damage",
                table: "SpaceShipProblems");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Problems");
        }
    }
}
