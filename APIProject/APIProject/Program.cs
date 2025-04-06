
using Microsoft.EntityFrameworkCore;

namespace APIProject;


class Program
{
    static void Main(string[] args)
    {
        API api = new API();
        PokemonDatabase db = new PokemonDatabase();
        while (true)
        {
            Console.WriteLine("\nPokemon Database System");
            Console.WriteLine("1. Search Pokemon");
            Console.WriteLine("2. List All Pokemons");
            Console.WriteLine("3. Add New Pokemon");
            Console.WriteLine("4. Filter Pokemons by Stat");
            Console.WriteLine("5. Sort Pokemons by Name");
            Console.WriteLine("6. Delete Pokemon by ID");
            Console.WriteLine("7. Exit");
            Console.Write("Select option: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Pokemon name: ");
                    string pokemonName = Console.ReadLine()!;
                    SearchPokemon(api, db, pokemonName);
                    break;
                case "2":
                    ListAllPokemons(db);
                    break;
                case "3":
                    AddCustomPokemon(db);
                    break;
                case "4":
                    FilterByStat(db);
                    break;
                case "5":
                    SortPokemonsByName(db);
                    break;
                case "6":
                    Console.WriteLine("Write id of a pokemon that you want to erase:");
                    int pokemonId = Int32.Parse(Console.ReadLine()!);
                    db.DeletePokemonById(pokemonId);
                    Console.WriteLine("Database cleared.");
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void SearchPokemon(API api, PokemonDatabase db, string name)
    {
        var existingPokemon = db.Pokemons
            .Include(p => p.Abilities)
            .Include(p => p.Stats)
            .FirstOrDefault(p => p.PokemonName.ToLower() == name.ToLower());

        if (existingPokemon != null)
        {
            Console.WriteLine("\nPokemon found in database:");
            DisplayPokemon(db, existingPokemon.Id);
        }
        else
        {
            Console.WriteLine("\nPokemon not in database. Fetching from API...");
            try
            {
                api.GetData(name).Wait();
                
                var newPokemon = db.Pokemons
                    .Include(p => p.Abilities)
                    .Include(p => p.Stats)
                    .FirstOrDefault(p => p.PokemonName.ToLower() == name.ToLower());
                
                if (newPokemon != null)
                {
                    Console.WriteLine("\nPokemon added to database:");
                    DisplayPokemon(db, newPokemon.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void ListAllPokemons(PokemonDatabase db)
    {
        var pokemons = db.Pokemons
            .Include(p => p.Abilities)
            .Include(p => p.Stats)
            .ToList();

        Console.WriteLine("\nAll Pokemons in Database:");
        foreach (var pokemon in pokemons)
        {
            DisplayPokemon(db, pokemon.Id);
            Console.WriteLine();
        }
    }

    static void AddCustomPokemon(PokemonDatabase db)
    {
        Console.Write("Enter Pokemon ID: ");
        int id = int.Parse(Console.ReadLine()!);
        
        Console.Write("Enter Pokemon name: ");
        string name = Console.ReadLine()!;
        
        Console.WriteLine("Enter abilities (comma separated): ");
        var abilities = Console.ReadLine()!.Split(',').Select(a => a.Trim()).ToList();
        
        Console.WriteLine("Enter stats (comma separated integers): ");
        var stats = Console.ReadLine()!.Split(',').Select(int.Parse).ToList();
        
        db.AddNewPokemon(name, abilities, stats);
        Console.WriteLine("Pokemon added successfully!");
    }

    static void FilterByStat(PokemonDatabase db)
    {
        Console.Write("Enter minimum stat value to filter: ");
        int minStat = int.Parse(Console.ReadLine()!);
        
        var filtered = db.Pokemons
            .Include(p => p.Stats)
            .Where(p => p.Stats.Any(s => s.Value >= minStat))
            .ToList();

        Console.WriteLine($"\nPokemons with at least one stat >= {minStat}:");
        foreach (var pokemon in filtered)
        {
            Console.WriteLine($"{pokemon.PokemonName}");
        }
    }

    static void SortPokemonsByName(PokemonDatabase db)
    {
        var sorted = db.Pokemons
            .OrderBy(p => p.PokemonName)
            .ToList();

        Console.WriteLine("\nPokemons sorted by name:");
        foreach (var pokemon in sorted)
        {
            Console.WriteLine(pokemon.PokemonName);
        }
    }

    static void DisplayPokemon(PokemonDatabase db, int pokemonId)
    {
        var pokemon = db.Pokemons
            .Include(p => p.Abilities)
            .Include(p => p.Stats)
            .FirstOrDefault(p => p.Id == pokemonId);

        if (pokemon != null)
        {
            Console.WriteLine($"\nID: {pokemon.Id}");
            Console.WriteLine($"Name: {pokemon.PokemonName}");
        
            Console.WriteLine("Abilities:");
            foreach (var ability in pokemon.Abilities)
            {
                Console.WriteLine($"- {ability.AbilityName} (ID: {ability.Id})");
            }
        
            Console.WriteLine("Stats:");
            foreach (var stat in pokemon.Stats)
            {
                Console.WriteLine($"- {stat.Value} (ID: {stat.Id})");
            }
        }
        else
        {
            Console.WriteLine($"Pokemon o ID {pokemonId} nie został znaleziony w bazie danych.");
        }
    }
}
