using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class SpaceShipProblemEntidadeRelacional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpaceShipProblem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProblemId = table.Column<int>(type: "int", nullable: false),
                    SpaceShipId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceShipProblem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaceShipProblem_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpaceShipProblem_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpaceShipProblem_SpaceShips_SpaceShipId",
                        column: x => x.SpaceShipId,
                        principalTable: "SpaceShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpaceShipProblem_PartId",
                table: "SpaceShipProblem",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceShipProblem_ProblemId",
                table: "SpaceShipProblem",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceShipProblem_SpaceShipId",
                table: "SpaceShipProblem",
                column: "SpaceShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpaceShipProblem");
        }
    }
}
