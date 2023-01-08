using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtifyZone.Minesweeper.Migrations
{
    /// <inheritdoc />
    public partial class AddGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMinePositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMinePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMinePositions_AppGames_GameId",
                        column: x => x.GameId,
                        principalTable: "AppGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppRevealedPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Mine = table.Column<bool>(type: "boolean", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    NeighborMines = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRevealedPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRevealedPositions_AppGames_GameId",
                        column: x => x.GameId,
                        principalTable: "AppGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMinePositions_GameId",
                table: "AppMinePositions",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRevealedPositions_GameId",
                table: "AppRevealedPositions",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMinePositions");

            migrationBuilder.DropTable(
                name: "AppRevealedPositions");

            migrationBuilder.DropTable(
                name: "AppGames");
        }
    }
}
