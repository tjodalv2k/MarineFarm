using Microsoft.EntityFrameworkCore.Migrations;

namespace MarineFarm.Migrations
{
    public partial class AddedForeignKeyToFish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fish_Tank_TankId",
                table: "Fish");

            migrationBuilder.DropIndex(
                name: "IX_Fish_TankId",
                table: "Fish");

            migrationBuilder.AlterColumn<int>(
                name: "TankId",
                table: "Fish",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TankId",
                table: "Fish",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Fish_TankId",
                table: "Fish",
                column: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fish_Tank_TankId",
                table: "Fish",
                column: "TankId",
                principalTable: "Tank",
                principalColumn: "TankId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
