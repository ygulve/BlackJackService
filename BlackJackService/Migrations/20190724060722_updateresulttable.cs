using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    public partial class updateresulttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Session_Id",
                table: "result");

            migrationBuilder.AddColumn<int>(
                name: "Game_Id",
                table: "result",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Game_Id",
                table: "result");

            migrationBuilder.AddColumn<string>(
                name: "Session_Id",
                table: "result",
                nullable: true);
        }
    }
}
