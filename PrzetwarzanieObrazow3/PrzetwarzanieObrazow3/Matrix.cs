namespace PrzetwarzanieObrazow3;
using System.Diagnostics;
using System.Threading.Tasks;
public class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
        InitializeMatrix();
    }

    public int[,] GetData()
    {
        return matrix;
    }

    private void InitializeMatrix()
    {
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(1, 10);
            }
        }
    }

    public static int[,] MultiplyMatrixLowLevel(int[,] matrix1, int[,] matrix2, int nThreads)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
        {
            throw new ArgumentException(
                "Liczba kolumn pierwszej macierzy musi być równa liczbie wierszy drugiej macierzy.");
        }

        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int commonDim = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];
        
        Thread[] threads = new Thread[nThreads];

        for (int t = 0; t < threads.Length; t++)
        {
            int threadID = t;
            threads[t] = new Thread(() =>
            {
                for (int i = threadID; i < rows; i += nThreads)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < commonDim; k++)
                        {
                            sum += matrix1[i, k] * matrix2[k, j];
                        }
                        result[i, j] = sum;
                    }
                }
            });

            
        }
        
        foreach (var thread in threads)
        {
            thread.Start(); 
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }

        return result;
    }
    
    public static int[,] MultiplyMatrixParallel(int[,] matrix1, int[,] matrix2, int n)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
            throw new ArgumentException("Nieprawidłowe wymiary macierzy");

        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int commonDim = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        var options = new ParallelOptions { MaxDegreeOfParallelism = n };
         Parallel.For(0, rows, options, i =>
         {
             for (int j = 0; j < cols; j++)
             {
                 int sum = 0;
                 for (int k = 0; k < commonDim; k++)
                 {
                     sum += matrix1[i, k] * matrix2[k, j];
                 }
                 result[i, j] = sum;
             }
         });
         
        return result;
    }
    
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"[{matrix[i, j]}]");
            }
            Console.WriteLine();
        }
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result += $"[{matrix[i, j]}]";
            }
            result += "\n";
        }
        return result;
    }
}