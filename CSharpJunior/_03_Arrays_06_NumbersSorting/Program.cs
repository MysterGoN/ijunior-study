using System;

namespace _03_Arrays_06_NumbersSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            const int randomNumberMin = 10;
            const int randomNumberMax = 99;
            Random random = new Random();
            int[] randomNumbers = new int[15];

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(randomNumberMin, randomNumberMax + 1);
            }

            Console.WriteLine("Исходный массив:");
            Console.Write("  ");
            foreach (int randomNumber in randomNumbers)
            {
                Console.Write(randomNumber + " ");
            }

            for (int i = 0; i < randomNumbers.Length - 1; i++)
            {
                for (int j = 0; j < randomNumbers.Length - i - 1; j++)
                {
                    if (randomNumbers[j] > randomNumbers[j + 1])
                    {
                        (randomNumbers[j], randomNumbers[j + 1]) = (randomNumbers[j + 1], randomNumbers[j]);
                    }
                }
            }

            Console.WriteLine("\nОтсортированный массив:");
            Console.Write("  ");
            foreach (int randomNumber in randomNumbers)
            {
                Console.Write(randomNumber + " ");
            }
        }
    }
}