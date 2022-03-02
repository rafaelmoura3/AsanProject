using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class UpdateMaintenanceRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpaceShipProblemId",
                table: "Maintenances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToolPerPartId",
                table: "Maintenances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_SpaceShipProblemId",
                table: "Maintenances",
                column: "SpaceShipProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_ToolPerPartId",
                table: "Maintenances",
                column: "ToolPerPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_SpaceShipProblems_SpaceShipProblemId",
                table: "Maintenances",
                column: "SpaceShipProblemId",
                principalTable: "SpaceShipProblems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_ToolPerParts_ToolPerPartId",
                table: "Maintenances",
                column: "ToolPerPartId",
                principalTable: "ToolPerParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_SpaceShipProblems_SpaceShipProblemId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_ToolPerParts_ToolPerPartId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_SpaceShipProblemId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_ToolPerPartId",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "SpaceShipProblemId",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "ToolPerPartId",
                table: "Maintenances");
        }
    }
}
