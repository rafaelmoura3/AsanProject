using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class PartsPerSipType_Health_Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Health",
                table: "PartsPerShipTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Health",
                table: "PartsPerShipTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
