using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIProject.Migrations
{
    /// <inheritdoc />
    public partial class PokemonDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AbilityName = table.Column<string>(type: "TEXT", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "PokemonName" },
                values: new object[,]
                {
                    { 1, "Pikachu" },
                    { 2, "Bulbasaur" },
                    { 3, "Charmander" }
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "AbilityName", "PokemonId" },
                values: new object[,]
                {
                    { 1, "Thunderbolt", 1 },
                    { 2, "Quick Attack", 1 },
                    { 3, "Vine Whip", 2 },
                    { 4, "Razor Leaf", 2 },
                    { 5, "Ember", 3 },
                    { 6, "Scratch", 3 }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "PokemonId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 35 },
                    { 2, 1, 55 },
                    { 3, 2, 45 },
                    { 4, 2, 49 },
                    { 5, 3, 39 },
                    { 6, 3, 52 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_PokemonId",
                table: "Abilities",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PokemonId",
                table: "Stats",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
