using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    public partial class addresult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_card_Card_Id",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_game_Game_Id",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_transaction_Card_Id",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_transaction_Game_Id",
                table: "transaction");

            migrationBuilder.AlterColumn<int>(
                name: "Game_Id",
                table: "transaction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Card_Id",
                table: "transaction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "transaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "transaction");

            migrationBuilder.AlterColumn<int>(
                name: "Game_Id",
                table: "transaction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Card_Id",
                table: "transaction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_transaction_Card_Id",
                table: "transaction",
                column: "Card_Id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_Game_Id",
                table: "transaction",
                column: "Game_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_card_Card_Id",
                table: "transaction",
                column: "Card_Id",
                principalTable: "card",
                principalColumn: "Card_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_game_Game_Id",
                table: "transaction",
                column: "Game_Id",
                principalTable: "game",
                principalColumn: "Game_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
