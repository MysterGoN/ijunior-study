using System;

namespace _03_Arrays_07_Split
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string inputPhrase = Console.ReadLine();

            Console.WriteLine("Результирующее предложение:");
            foreach (string word in inputPhrase.Split(' '))
            {
                Console.WriteLine(" " + word);
            }
        }
    }
}