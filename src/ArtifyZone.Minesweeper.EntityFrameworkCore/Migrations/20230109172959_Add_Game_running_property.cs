using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtifyZone.Minesweeper.Migrations
{
    /// <inheritdoc />
    public partial class AddGamerunningproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Running",
                table: "AppGames",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Running",
                table: "AppGames");
        }
    }
}
