using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    public partial class Game : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_game_player_Player_Id",
                table: "game");

            migrationBuilder.AlterColumn<int>(
                name: "Player_Id",
                table: "game",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_game_player_Player_Id",
                table: "game",
                column: "Player_Id",
                principalTable: "player",
                principalColumn: "Player_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_game_player_Player_Id",
                table: "game");

            migrationBuilder.AlterColumn<int>(
                name: "Player_Id",
                table: "game",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_game_player_Player_Id",
                table: "game",
                column: "Player_Id",
                principalTable: "player",
                principalColumn: "Player_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
