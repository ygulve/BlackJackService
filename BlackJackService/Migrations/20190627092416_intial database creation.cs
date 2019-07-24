using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    public partial class intialdatabasecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    Player_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Session_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.Player_Id);
                });

            migrationBuilder.CreateTable(
                name: "suit",
                columns: table => new
                {
                    Suit_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suit", x => x.Suit_Id);
                });

            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    Card_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Suit_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.Card_Id);
                    table.ForeignKey(
                        name: "FK_card_suit_Suit_Id",
                        column: x => x.Suit_Id,
                        principalTable: "suit",
                        principalColumn: "Suit_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_card_Suit_Id",
                table: "card",
                column: "Suit_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "suit");
        }
    }
}
