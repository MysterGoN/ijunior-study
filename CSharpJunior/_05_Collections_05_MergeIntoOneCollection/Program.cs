using System;
using System.Collections.Generic;

namespace _05_Collections_05_MergeIntoOneCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            const int minRandomNumber = 1;
            const int maxRandomNumber = 9;
            string[] firstArray = new string[3];
            string[] secondArray = new string[5];

            WriteRandomNumbers(firstArray, random, minRandomNumber, maxRandomNumber);
            WriteRandomNumbers(secondArray, random, minRandomNumber, maxRandomNumber);

            Print("Первый массив: ", firstArray);
            Print("Второй массив: ", secondArray);

            SortedSet<string> mergedSet = Merge(firstArray, secondArray);

            Console.WriteLine($"Результат объединения массивов: {{{String.Join(", ", mergedSet)}}}");
        }

        static void WriteRandomNumbers(string[] array, Random random, int minRandomNumber, int maxRandomNumber)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToString(random.Next(minRandomNumber, maxRandomNumber + 1));
            }
        }

        static void Print(string prefix, string[] array)
        {
            Console.WriteLine($"{prefix}: [{String.Join(", ", array)}]");
        }

        static SortedSet<string> Merge(string[] firstArray, string[] secondArray)
        {
            SortedSet<string> mergedSet = new SortedSet<string>();

            AddValues(mergedSet, firstArray);
            AddValues(mergedSet, secondArray);

            return mergedSet;
        }

        static void AddValues(SortedSet<string> set, string[] array)
        {
            foreach (string value in array)
            {
                set.Add(value);
            }
        }
    }
}