using System.Text.Json;
using System.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace APIProject;

public class API
{
    public HttpClient client;

    public async Task GetData(string Name)
    {
        client = new HttpClient();
        string call = $"https://pokeapi.co/api/v2/pokemon/{Name}";
        string response = await client.GetStringAsync(call);
        Pokemons pokemon = JsonSerializer.Deserialize<Pokemons>(response)!;
        Console.WriteLine(pokemon.ToString());
        
    }
    
}


