using System;

namespace _03_Arrays_01_TargetElement
{
    class Program
    {
        static void Main(string[] args)
        {
            const int sumRow = 2;
            const int multCol = 1;
            const int randNumberMin = 1;
            const int randNumberMax = 9;
            Random rand = new Random();
            int[,] matrix = new int[5, 7];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(randNumberMin, randNumberMax + 1);
                }
            }
            
            Console.WriteLine("Матрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("  ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            int sum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[sumRow - 1, j];
            }
            Console.Write($"\nСумма {sumRow} строки: {sum}");

            int mult = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                mult *= matrix[i, multCol - 1];
            }
            Console.Write($"\nПроизведение {multCol} колонки: {mult}");
        }
    }
}