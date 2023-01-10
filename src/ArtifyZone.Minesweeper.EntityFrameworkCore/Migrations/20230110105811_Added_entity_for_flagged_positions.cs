using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtifyZone.Minesweeper.Migrations
{
    /// <inheritdoc />
    public partial class Addedentityforflaggedpositions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AppFlaggedPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFlaggedPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFlaggedPositions_AppGames_GameId",
                        column: x => x.GameId,
                        principalTable: "AppGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFlaggedPositions_GameId",
                table: "AppFlaggedPositions",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFlaggedPositions");

            migrationBuilder.AddColumn<Guid>(
                name: "GameId1",
                table: "AppMinePositions",
                type: "uuid",
                nullable: true);

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
    }
}
