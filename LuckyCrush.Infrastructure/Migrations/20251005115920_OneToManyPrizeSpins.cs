using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyCrush.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyPrizeSpins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrizeId",
                table: "Spins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Spins_PrizeId",
                table: "Spins",
                column: "PrizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spins_Prizes_PrizeId",
                table: "Spins",
                column: "PrizeId",
                principalTable: "Prizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spins_Prizes_PrizeId",
                table: "Spins");

            migrationBuilder.DropIndex(
                name: "IX_Spins_PrizeId",
                table: "Spins");

            migrationBuilder.DropColumn(
                name: "PrizeId",
                table: "Spins");
        }
    }
}
