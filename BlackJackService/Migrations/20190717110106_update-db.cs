using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "Session_Id",
                table: "player");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "transaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Session_Id",
                table: "player",
                nullable: false,
                defaultValue: 0);
        }
    }
}
