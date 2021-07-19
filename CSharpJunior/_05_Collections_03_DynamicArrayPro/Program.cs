using System;
using System.Collections.Generic;

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
                switch (userInput)
                {
                    case sumCommand:
                        int totalSum = CalculateSum(numbers);
                        Console.WriteLine($"Итоговая сумма равна {totalSum}");
                        break;
                    case exitCommand:
                        canExit = true;
                        break;
                    default:
                        if (int.TryParse(userInput, out int newNumber))
                        {
                            AddNumber(numbers, newNumber);
                        }
                        else
                        {
                            Console.WriteLine($"Вы не ввели ни целое число ни команды '{sumCommand}', " +
                                              $"'{exitCommand}', попробуйте ещё раз");
                        }
                        break;
                }

                Console.ReadKey();
            }
        }

        static void AddNumber(List<int> numbers, int newNumber)
        {
            numbers.Add(newNumber);
            Console.WriteLine($"В список было добавлено число {newNumber}.");
        }

        static int CalculateSum(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}