using System.Diagnostics;

namespace PrzetwarzanieObrazow3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj liczbę wierszy pierwszej macierzy:");
        int rows1 = Int32.Parse(Console.ReadLine()!);
        Console.WriteLine("Podaj liczbę kolumn pierwszej macierzy:");
        int cols1 = Int32.Parse(Console.ReadLine()!);

        Console.WriteLine("Podaj liczbę wierszy drugiej macierzy:");
        int rows2 = Int32.Parse(Console.ReadLine()!);
        Console.WriteLine("Podaj liczbę kolumn drugiej macierzy:");
        int cols2 = Int32.Parse(Console.ReadLine()!);
        Console.WriteLine("Podaj liczbę wątków do obliczeń:");
        int threadsInput = Int32.Parse(Console.ReadLine()!);
        
        if (cols1 != rows2)
        {
            Console.WriteLine(
                "Mnożenie macierzy niemożliwe! Liczba kolumn pierwszej macierzy musi być równa liczbie wierszy drugiej macierzy.");
            return;
        }
        
        Matrix matrix1 = new Matrix(rows1, cols1);
        //Console.WriteLine(matrix1.ToString());
        Matrix matrix2 = new Matrix(rows2, cols2);
        //Console.WriteLine(matrix2.ToString());
        var stopwatch = Stopwatch.StartNew();
        stopwatch.Restart();
        int[,] resultMatrixSeq = Matrix.MultiplyMatrixParallel(matrix1.GetData(), matrix2.GetData(), 1);
        stopwatch.Stop();
        Console.WriteLine($"\nCzas mnożenia wysokopoziomowego ({threadsInput} watkow: {stopwatch.ElapsedMilliseconds} ms");
        
        stopwatch.Restart();
        int[,] resultMatrixLow = Matrix.MultiplyMatrixLowLevel(matrix1.GetData(), matrix2.GetData(), threadsInput); 
        //Matrix.PrintMatrix(resultMatrixLow);
        stopwatch.Stop(); 
        Console.WriteLine($"Czas mnożenia niskopoziomowego ({threadsInput} wątków): {stopwatch.ElapsedMilliseconds} ms");
        
        // int[] threadCounts = { 1, 2, 4, 8};
        // foreach (int threads in threadCounts)
        // {
        //     stopwatch.Restart();
        //     int[,] resultMatrix = Matrix.MultiplyMatrixParallel(matrix1.GetData(), matrix2.GetData(), threads);
        //     stopwatch.Stop();
        //     Console.WriteLine($"Czas mnożenia wysokopoziomowego ({threads} wątków): {stopwatch.ElapsedMilliseconds} ms");
        // }
    }
}