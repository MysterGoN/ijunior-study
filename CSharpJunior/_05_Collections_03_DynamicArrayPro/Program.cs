using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Collections_03_DynamicArrayPro
{
    class Program
    {
        static void Main(string[] args)
        {
            const string sumCommand = "sum";
            const string exitCommand = "exit";
            List<int> numbers = new List<int>();
            bool canExit = false;

            while (!canExit)
            {
                Console.Clear();
                Console.Write($"Введите целое число или команды '{sumCommand}', '{exitCommand}': ");
                string userInput = Console.ReadLine();

                if (exitCommand.Equals(userInput))
                {
                    canExit = true;
                    continue;
                }

                if (sumCommand.Equals(userInput))
                {
                    int totalSum = numbers.Sum();
                    Console.WriteLine($"Итоговая сумма равна {totalSum}");
                } else if (userInput != null && int.TryParse(userInput, out int newNumber))
                {
                    numbers.Add(newNumber);
                    Console.WriteLine($"В список было добавлено число {newNumber}.");
                }
                else
                {
                    Console.WriteLine($"Вы не ввели ни целое число ни команды '{sumCommand}', '{exitCommand}', " +
                                      $"попробуйте ещё раз");
                }

                Console.ReadKey();
            }
        }
    }
}