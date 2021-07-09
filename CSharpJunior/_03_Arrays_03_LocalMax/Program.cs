using System;

namespace _03_Arrays_03_LocalMax
{
    class Program
    {
        static void Main(string[] args)
        {
            const int randNumberMin = 10;
            const int randNumberMax = 99;
            Random rand = new Random();
            int[] numbers = new int[30];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(randNumberMin, randNumberMax + 1);
            }

            Console.WriteLine("Последовательность чисел:");
            Console.Write("  ");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            
            Console.WriteLine("Локальные максимумы:");
            Console.Write("  ");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    if (numbers[i] >= numbers[i + 1])
                    {
                        Console.Write($" {numbers[i]}");
                    }
                } else if (i == numbers.Length - 1)
                {
                    if (numbers[i] >= numbers[i - 1])
                    {
                        Console.Write($" {numbers[i]}");
                    }
                }
                else if (numbers[i] >= numbers[i - 1] && numbers[i] >= numbers[i + 1])
                {
                    Console.Write($" {numbers[i]}");
                }
            }
        }
    }
}