using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtifyZone.Minesweeper.Migrations
{
    /// <inheritdoc />
    public partial class Addedmineflaggingcorectness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectlyFlagged",
                table: "AppGames",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectlyFlagged",
                table: "AppGames");
        }
    }
}
