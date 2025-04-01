namespace APIProject;

class Program
{
    static void Main(string[] args)
    {
        API api = new API();
        Console.WriteLine("Podaj nazwe pokemona:");
        string pokemonName = Console.ReadLine()!;
        api.GetData(pokemonName).Wait();
    }
}