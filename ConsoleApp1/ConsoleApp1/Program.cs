namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        int n;
        int seed;
        string userInput = "";
        Random random1 = new Random();
        Console.WriteLine("Enter the number of items: ");
        userInput = Console.ReadLine()!;
        n = int.Parse(userInput);
        Console.WriteLine("Enter the seed: ");
        userInput = Console.ReadLine()!;
        seed = userInput.Length == 0 ? random1.Next(0, Int32.MaxValue) : int.Parse(userInput);
        Random random = new Random(seed);

        Problem problem = new Problem(n, seed);

        Console.WriteLine(problem.ToString());
        Console.WriteLine("Enter total capacity");
        int capacity = int.Parse(Console.ReadLine()!);
        Result result = problem.Solve(capacity);
        Console.WriteLine(result.ToString());
    }
}