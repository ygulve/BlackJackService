using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    public partial class resulttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "transaction");

            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    Result_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerScore = table.Column<int>(nullable: false),
                    DealerScore = table.Column<int>(nullable: false),
                    Session_Id = table.Column<string>(nullable: true),
                    Output = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.Result_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "result");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "transaction",
                nullable: true);
        }
    }
}
