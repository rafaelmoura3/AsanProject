using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class PartsPerShipsTry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartsPerShips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    SpaceShipTypeId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_PartsPerShips_SpaceShipTypes_SpaceShipTypeId",
                        column: x => x.SpaceShipTypeId,
                        principalTable: "SpaceShipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartsPerShips_PartId",
                table: "PartsPerShips",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsPerShips_SpaceShipTypeId",
                table: "PartsPerShips",
                column: "SpaceShipTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartsPerShips");
        }
    }
}
