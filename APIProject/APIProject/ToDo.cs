using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace APIProject
{
    public class Pokemons
    {
        [JsonPropertyName("species")]
        public PokemonName id {get; set;}
        
        [JsonPropertyName("moves")]
        public List<PokemonMove> movesList { get; set; }
        
        [JsonPropertyName("stats")]
        public List<PokemonStats> statsList { get; set; }
        public override string ToString()
        {
            string result = "";
            result += $"Pokemon name: {id.name}\n";
            
            result += "Pokemon basic stats:\n";
            foreach (var data in statsList)
            {
                if (data?.baseStat != null)
                {
                    result += $"{data.baseStat}, ";
                }
            }
            result += "\n";            
            result += "Pokemon Moves:\n";
            foreach (var data in movesList)
            {
                if (data?.Move?.moveName != null)
                {
                    result += $"- {data.Move.moveName}\n";
                }
            }
            return result;
        }
    }
    public class PokemonMove
    {
        [JsonPropertyName("move")]
        public MoveDetail Move { get; set; }
    }
    public class MoveDetail
    {
        [JsonPropertyName("name")]
        public string moveName { get; set; }
    }

    public class PokemonStats
    {
        [JsonPropertyName("base_stat")]
        public int baseStat { get; set; }
    }

    public class PokemonName
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
    }
    
}

