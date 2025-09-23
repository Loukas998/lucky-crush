using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyCrush.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovedCompletedFromGoalToProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Goals");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Progresses",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Progresses");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Goals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
