using System;

namespace _03_Arrays_02_MaxElement
{
    class Program
    {
        static void Main(string[] args)
        {
            const int randNumberMin = 10;
            const int randNumberMax = 99;
            int maxNumber = int.MinValue;
            int maxNumberPosX = 0;
            int maxNumberPosY = 0;
            Random rand = new Random();
            int[,] matrix = new int[10, 10];
            int newMatrixPositionX = matrix.GetLength(1) * 3 + 5;
            int newMatrixPositionY = 0;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(randNumberMin, randNumberMax + 1);
                }
            }

            Console.Clear();
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("  ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (maxNumber < matrix[i, j])
                    {
                        maxNumber = matrix[i, j];
                        maxNumberPosX = j;
                        maxNumberPosY = i;
                    }
                }
            }

            matrix[maxNumberPosY, maxNumberPosX] = 0;
            Console.WriteLine($"\nМаксимальное значение: {maxNumber} " +
                              $"располагается по координатам x={maxNumberPosX}, y={maxNumberPosY}");
            
            Console.SetCursorPosition(newMatrixPositionX, newMatrixPositionY);
            Console.WriteLine("Итоговая матрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.SetCursorPosition(newMatrixPositionX, newMatrixPositionY + i + 1);
                Console.Write("  ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}