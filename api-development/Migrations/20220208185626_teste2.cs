using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShip_SpaceShipType_SpaceShipTypeId",
                table: "SpaceShip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceShipType",
                table: "SpaceShipType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceShip",
                table: "SpaceShip");

            migrationBuilder.RenameTable(
                name: "SpaceShipType",
                newName: "SpaceShipTypes");

            migrationBuilder.RenameTable(
                name: "SpaceShip",
                newName: "SpaceShips");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShip_SpaceShipTypeId",
                table: "SpaceShips",
                newName: "IX_SpaceShips_SpaceShipTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "SpaceShips",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceShipTypes",
                table: "SpaceShipTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceShips",
                table: "SpaceShips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShips_SpaceShipTypes_SpaceShipTypeId",
                table: "SpaceShips",
                column: "SpaceShipTypeId",
                principalTable: "SpaceShipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShips_SpaceShipTypes_SpaceShipTypeId",
                table: "SpaceShips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceShipTypes",
                table: "SpaceShipTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceShips",
                table: "SpaceShips");

            migrationBuilder.RenameTable(
                name: "SpaceShipTypes",
                newName: "SpaceShipType");

            migrationBuilder.RenameTable(
                name: "SpaceShips",
                newName: "SpaceShip");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShips_SpaceShipTypeId",
                table: "SpaceShip",
                newName: "IX_SpaceShip_SpaceShipTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "SpaceShip",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceShipType",
                table: "SpaceShipType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceShip",
                table: "SpaceShip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShip_SpaceShipType_SpaceShipTypeId",
                table: "SpaceShip",
                column: "SpaceShipTypeId",
                principalTable: "SpaceShipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
