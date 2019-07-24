using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    public partial class othertables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    Game_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Player_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.Game_Id);
                    table.ForeignKey(
                        name: "FK_game_player_Player_Id",
                        column: x => x.Player_Id,
                        principalTable: "player",
                        principalColumn: "Player_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    Transaction_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerScore = table.Column<int>(nullable: false),
                    DealerScore = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    Card_Id = table.Column<int>(nullable: true),
                    Game_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.Transaction_Id);
                    table.ForeignKey(
                        name: "FK_transaction_card_Card_Id",
                        column: x => x.Card_Id,
                        principalTable: "card",
                        principalColumn: "Card_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transaction_game_Game_Id",
                        column: x => x.Game_Id,
                        principalTable: "game",
                        principalColumn: "Game_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_game_Player_Id",
                table: "game",
                column: "Player_Id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_Card_Id",
                table: "transaction",
                column: "Card_Id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_Game_Id",
                table: "transaction",
                column: "Game_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "game");
        }
    }
}
