﻿// <auto-generated />
using APIProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIProject.Migrations
{
    [DbContext(typeof(PokemonDatabase))]
    [Migration("20250401121755_PokemonDB")]
    partial class PokemonDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("APIProject.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PokemonName = "Pikachu"
                        },
                        new
                        {
                            Id = 2,
                            PokemonName = "Bulbasaur"
                        },
                        new
                        {
                            Id = 3,
                            PokemonName = "Charmander"
                        });
                });

            modelBuilder.Entity("APIProject.PokemonAbility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Abilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbilityName = "Thunderbolt",
                            PokemonId = 1
                        },
                        new
                        {
                            Id = 2,
                            AbilityName = "Quick Attack",
                            PokemonId = 1
                        },
                        new
                        {
                            Id = 3,
                            AbilityName = "Vine Whip",
                            PokemonId = 2
                        },
                        new
                        {
                            Id = 4,
                            AbilityName = "Razor Leaf",
                            PokemonId = 2
                        },
                        new
                        {
                            Id = 5,
                            AbilityName = "Ember",
                            PokemonId = 3
                        },
                        new
                        {
                            Id = 6,
                            AbilityName = "Scratch",
                            PokemonId = 3
                        });
                });

            modelBuilder.Entity("APIProject.PokemonStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Stats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PokemonId = 1,
                            Value = 35
                        },
                        new
                        {
                            Id = 2,
                            PokemonId = 1,
                            Value = 55
                        },
                        new
                        {
                            Id = 3,
                            PokemonId = 2,
                            Value = 45
                        },
                        new
                        {
                            Id = 4,
                            PokemonId = 2,
                            Value = 49
                        },
                        new
                        {
                            Id = 5,
                            PokemonId = 3,
                            Value = 39
                        },
                        new
                        {
                            Id = 6,
                            PokemonId = 3,
                            Value = 52
                        });
                });

            modelBuilder.Entity("APIProject.PokemonAbility", b =>
                {
                    b.HasOne("APIProject.Pokemon", "Pokemon")
                        .WithMany("Abilities")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("APIProject.PokemonStat", b =>
                {
                    b.HasOne("APIProject.Pokemon", "Pokemon")
                        .WithMany("Stats")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("APIProject.Pokemon", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
