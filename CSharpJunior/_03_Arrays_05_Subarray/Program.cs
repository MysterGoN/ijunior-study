using System;

namespace _03_Arrays_05_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            const int randomNumberMin = 1;
            const int randomNumberMax = 9;
            Random random = new Random();
            int[] randomNumbers = new int[30];

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(randomNumberMin, randomNumberMax + 1);
            }

            Console.WriteLine("Последовательность чисел:");
            Console.Write("  ");
            foreach (int randomNumber in randomNumbers)
            {
                Console.Write(randomNumber + " ");
            }

            Console.WriteLine();

            int repetitionCount = 1;
            int maxRepetitionCount = repetitionCount;
            int mostFrequentlyRepeatedNumber = randomNumbers[0];
            for (int i = 1; i < randomNumbers.Length; i++)
            {
                if (randomNumbers[i] == randomNumbers[i - 1])
                {
                    repetitionCount++;
                }
                else
                {
                    if (maxRepetitionCount < repetitionCount)
                    {
                        maxRepetitionCount = repetitionCount;
                        mostFrequentlyRepeatedNumber = randomNumbers[i - 1];
                    }

                    repetitionCount = 1;
                }
            }

            if (maxRepetitionCount < repetitionCount)
            {
                maxRepetitionCount = repetitionCount;
                mostFrequentlyRepeatedNumber = randomNumbers[^1];
            }

            Console.WriteLine($"Чаще всего повторяющееся число: {mostFrequentlyRepeatedNumber}\n" +
                              $"Число повторений: {maxRepetitionCount}");
        }
    }
}