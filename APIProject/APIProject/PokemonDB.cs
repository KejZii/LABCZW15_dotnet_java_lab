using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIProject
{
    public class Pokemon
    {
        public int Id { get; set; }
        public required string PokemonName { get; set; }
        public List<PokemonAbility> Abilities { get; set; } = new List<PokemonAbility>();
        public List<PokemonStat> Stats { get; set; } = new List<PokemonStat>();
    }

    public class PokemonAbility
    {
        public int Id { get; set; }
        public string AbilityName { get; set; }
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }

    public class PokemonStat
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }

    public class PokemonDatabase : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonAbility> Abilities { get; set; }
        public DbSet<PokemonStat> Stats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Pokemons.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasMany(c => c.Abilities)
                .WithOne(a => a.Pokemon)
                .HasForeignKey(a => a.PokemonId);

            modelBuilder.Entity<Pokemon>()
                .HasMany(c => c.Stats)
                .WithOne(a => a.Pokemon)
                .HasForeignKey(a => a.PokemonId);

            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon { Id = 1, PokemonName = "Pikachu" },
                new Pokemon { Id = 2, PokemonName = "Bulbasaur" },
                new Pokemon { Id = 3, PokemonName = "Charmander" }
            );

            modelBuilder.Entity<PokemonAbility>().HasData(
                new PokemonAbility { Id = 1, AbilityName = "Thunderbolt", PokemonId = 1 },
                new PokemonAbility { Id = 2, AbilityName = "Quick Attack", PokemonId = 1 },
                new PokemonAbility { Id = 3, AbilityName = "Vine Whip", PokemonId = 2 },
                new PokemonAbility { Id = 4, AbilityName = "Razor Leaf", PokemonId = 2 },
                new PokemonAbility { Id = 5, AbilityName = "Ember", PokemonId = 3 },
                new PokemonAbility { Id = 6, AbilityName = "Scratch", PokemonId = 3 }
            );

            modelBuilder.Entity<PokemonStat>().HasData(
                new PokemonStat { Id = 1, Value = 35, PokemonId = 1 },
                new PokemonStat { Id = 2, Value = 55, PokemonId = 1 },
                new PokemonStat { Id = 3, Value = 45, PokemonId = 2 },
                new PokemonStat { Id = 4, Value = 49, PokemonId = 2 },
                new PokemonStat { Id = 5, Value = 39, PokemonId = 3 },
                new PokemonStat { Id = 6, Value = 52, PokemonId = 3 }
            );
        }

        public void DeletePokemon()
        {
            
            using (var db = new PokemonDatabase())
            {
                db.Abilities.RemoveRange(db.Abilities);
                db.Stats.RemoveRange(db.Stats);
                db.Pokemons.RemoveRange(db.Pokemons);
                db.SaveChanges();
                Console.WriteLine("Usunięto wszystkie rekordy z bazy danych.");
            }
        }
    }
}
