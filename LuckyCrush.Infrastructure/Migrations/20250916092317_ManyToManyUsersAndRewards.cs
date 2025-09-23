using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyCrush.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyUsersAndRewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Wheels_WheelId",
                table: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Prizes_WheelId",
                table: "Prizes");

            migrationBuilder.RenameColumn(
                name: "WheelId",
                table: "Prizes",
                newName: "Weight");

            migrationBuilder.CreateTable(
                name: "PrizeWheel",
                columns: table => new
                {
                    PrizesId = table.Column<int>(type: "int", nullable: false),
                    WheelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrizeWheel", x => new { x.PrizesId, x.WheelsId });
                    table.ForeignKey(
                        name: "FK_PrizeWheel_Prizes_PrizesId",
                        column: x => x.PrizesId,
                        principalTable: "Prizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrizeWheel_Wheels_WheelsId",
                        column: x => x.WheelsId,
                        principalTable: "Wheels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RewardUser",
                columns: table => new
                {
                    RewardsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardUser", x => new { x.RewardsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RewardUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RewardUser_Rewards_RewardsId",
                        column: x => x.RewardsId,
                        principalTable: "Rewards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PrizeWheel_WheelsId",
                table: "PrizeWheel",
                column: "WheelsId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardUser_UsersId",
                table: "RewardUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrizeWheel");

            migrationBuilder.DropTable(
                name: "RewardUser");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Prizes",
                newName: "WheelId");

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_WheelId",
                table: "Prizes",
                column: "WheelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Wheels_WheelId",
                table: "Prizes",
                column: "WheelId",
                principalTable: "Wheels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
