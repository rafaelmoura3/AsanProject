using Microsoft.EntityFrameworkCore.Migrations;

namespace AsanAPI.Migrations
{
    public partial class SpaceShipProblemEntidadeRelacionalOK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShipProblem_Parts_PartId",
                table: "SpaceShipProblem");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShipProblem_Problems_ProblemId",
                table: "SpaceShipProblem");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShipProblem_SpaceShips_SpaceShipId",
                table: "SpaceShipProblem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceShipProblem",
                table: "SpaceShipProblem");

            migrationBuilder.RenameTable(
                name: "SpaceShipProblem",
                newName: "SpaceShipProblems");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShipProblem_SpaceShipId",
                table: "SpaceShipProblems",
                newName: "IX_SpaceShipProblems_SpaceShipId");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShipProblem_ProblemId",
                table: "SpaceShipProblems",
                newName: "IX_SpaceShipProblems_ProblemId");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShipProblem_PartId",
                table: "SpaceShipProblems",
                newName: "IX_SpaceShipProblems_PartId");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "SpaceShipProblems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceShipProblems",
                table: "SpaceShipProblems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShipProblems_Parts_PartId",
                table: "SpaceShipProblems",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShipProblems_Problems_ProblemId",
                table: "SpaceShipProblems",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShipProblems_SpaceShips_SpaceShipId",
                table: "SpaceShipProblems",
                column: "SpaceShipId",
                principalTable: "SpaceShips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShipProblems_Parts_PartId",
                table: "SpaceShipProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShipProblems_Problems_ProblemId",
                table: "SpaceShipProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShipProblems_SpaceShips_SpaceShipId",
                table: "SpaceShipProblems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceShipProblems",
                table: "SpaceShipProblems");

            migrationBuilder.RenameTable(
                name: "SpaceShipProblems",
                newName: "SpaceShipProblem");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShipProblems_SpaceShipId",
                table: "SpaceShipProblem",
                newName: "IX_SpaceShipProblem_SpaceShipId");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShipProblems_ProblemId",
                table: "SpaceShipProblem",
                newName: "IX_SpaceShipProblem_ProblemId");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceShipProblems_PartId",
                table: "SpaceShipProblem",
                newName: "IX_SpaceShipProblem_PartId");

            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "SpaceShipProblem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceShipProblem",
                table: "SpaceShipProblem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShipProblem_Parts_PartId",
                table: "SpaceShipProblem",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShipProblem_Problems_ProblemId",
                table: "SpaceShipProblem",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShipProblem_SpaceShips_SpaceShipId",
                table: "SpaceShipProblem",
                column: "SpaceShipId",
                principalTable: "SpaceShips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
