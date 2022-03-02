using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class UpdateMaintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Maintenances",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Efficiency",
                table: "Maintenances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "Maintenances");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Maintenances",
                newName: "Amount");
        }
    }
}
