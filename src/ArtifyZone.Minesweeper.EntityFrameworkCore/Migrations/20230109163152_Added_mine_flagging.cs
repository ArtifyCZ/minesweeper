using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtifyZone.Minesweeper.Migrations
{
    /// <inheritdoc />
    public partial class Addedmineflagging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameId1",
                table: "AppMinePositions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailableFlags",
                table: "AppGames",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppMinePositions_GameId1",
                table: "AppMinePositions",
                column: "GameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMinePositions_AppGames_GameId1",
                table: "AppMinePositions",
                column: "GameId1",
                principalTable: "AppGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMinePositions_AppGames_GameId1",
                table: "AppMinePositions");

            migrationBuilder.DropIndex(
                name: "IX_AppMinePositions_GameId1",
                table: "AppMinePositions");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "AppMinePositions");

            migrationBuilder.DropColumn(
                name: "AvailableFlags",
                table: "AppGames");
        }
    }
}
