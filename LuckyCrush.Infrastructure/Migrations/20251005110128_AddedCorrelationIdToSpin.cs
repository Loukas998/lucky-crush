using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyCrush.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCorrelationIdToSpin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayedAt",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "CorrelationId",
                table: "Spins",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Spins_CorrelationId",
                table: "Spins",
                column: "CorrelationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Spins_CorrelationId",
                table: "Spins");

            migrationBuilder.DropColumn(
                name: "CorrelationId",
                table: "Spins");

            migrationBuilder.AddColumn<DateTime>(
                name: "PlayedAt",
                table: "Matches",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
