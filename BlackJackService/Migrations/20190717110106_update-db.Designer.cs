﻿// <auto-generated />
using System;
using BlackJackService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackService.Migrations
{
    [DbContext(typeof(BlackJackContext))]
    [Migration("20190717110106_update-db")]
    partial class updatedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackJackService.Model.Card", b =>
                {
                    b.Property<int>("Card_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Points");

                    b.Property<int?>("Suit_Id");

                    b.HasKey("Card_Id");

                    b.HasIndex("Suit_Id");

                    b.ToTable("card");
                });

            modelBuilder.Entity("BlackJackService.Model.Game", b =>
                {
                    b.Property<int>("Game_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Player_Id");

                    b.HasKey("Game_Id");

                    b.HasIndex("Player_Id");

                    b.ToTable("game");
                });

            modelBuilder.Entity("BlackJackService.Model.Player", b =>
                {
                    b.Property<int>("Player_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Player_Id");

                    b.ToTable("player");
                });

            modelBuilder.Entity("BlackJackService.Model.Suit", b =>
                {
                    b.Property<int>("Suit_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Suit_Id");

                    b.ToTable("suit");
                });

            modelBuilder.Entity("BlackJackService.Model.Transaction", b =>
                {
                    b.Property<int>("Transaction_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Card_Id");

                    b.Property<int>("DealerScore");

                    b.Property<int?>("Game_Id");

                    b.Property<int>("PlayerScore");

                    b.HasKey("Transaction_Id");

                    b.HasIndex("Card_Id");

                    b.HasIndex("Game_Id");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("BlackJackService.Model.Card", b =>
                {
                    b.HasOne("BlackJackService.Model.Suit", "suit")
                        .WithMany()
                        .HasForeignKey("Suit_Id");
                });

            modelBuilder.Entity("BlackJackService.Model.Game", b =>
                {
                    b.HasOne("BlackJackService.Model.Player", "player")
                        .WithMany()
                        .HasForeignKey("Player_Id");
                });

            modelBuilder.Entity("BlackJackService.Model.Transaction", b =>
                {
                    b.HasOne("BlackJackService.Model.Card", "card")
                        .WithMany()
                        .HasForeignKey("Card_Id");

                    b.HasOne("BlackJackService.Model.Game", "game")
                        .WithMany()
                        .HasForeignKey("Game_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
