using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class PartsPerShipNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Health",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PartsPerShips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartsPerShipTypeId = table.Column<int>(type: "int", nullable: false),
                    SpaceShipId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsPerShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsPerShips_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartsPerShips_PartsPerShipTypes_PartsPerShipTypeId",
                        column: x => x.PartsPerShipTypeId,
                        principalTable: "PartsPerShipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartsPerShips_SpaceShips_SpaceShipId",
                        column: x => x.SpaceShipId,
                        principalTable: "SpaceShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartsPerShips_PartId",
                table: "PartsPerShips",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsPerShips_PartsPerShipTypeId",
                table: "PartsPerShips",
                column: "PartsPerShipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsPerShips_SpaceShipId",
                table: "PartsPerShips",
                column: "SpaceShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartsPerShips");

            migrationBuilder.DropColumn(
                name: "Health",
                table: "Parts");
        }
    }
}
