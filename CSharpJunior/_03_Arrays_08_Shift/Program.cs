using System;

namespace _03_Arrays_08_Shift
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] randomNumbers = new int[9] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            Console.WriteLine("Исходный массив:");
            Console.Write("  ");
            foreach (int randomNumber in randomNumbers)
            {
                Console.Write(randomNumber + " ");
            }

            Console.Write("\n\nВведите положительное число для сдвига влево: ");
            uint numberToShift = Convert.ToUInt32(Console.ReadLine()) % (uint) randomNumbers.Length;


            for (int i = 0; i < numberToShift; i++)
            {
                for (int j = 0; j < randomNumbers.Length - 1; j++)
                {
                    (randomNumbers[j], randomNumbers[j + 1]) = (randomNumbers[j + 1], randomNumbers[j]);
                }
            }

            Console.WriteLine("\nМассив со сдвигом:");
            Console.Write("  ");
            foreach (int randomNumber in randomNumbers)
            {
                Console.Write(randomNumber + " ");
            }
        }
    }
}