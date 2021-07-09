using System;

namespace _03_Arrays_04_DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            const string sumCommand = "sum";
            const string exitCommand = "exit";
            const int arrayDownPosition = 5;
            int[] numbers = new int[0];
            bool canExit = false;
            string message = null;
            
            while (!canExit)
            {
                Console.Clear();
                Console.WriteLine("Работа с консолью:" +
                                  "\n  - Вы можете ввести целое число, чтобы добавить его в массив" +
                                  $"\n  - Вы можете ввести команду {sumCommand}, что позволит сложить все числа массива" +
                                  $"\n  - Вы можете ввести команду {exitCommand}, для выхода из программы");
                
                Console.Write("\nВведите команду: ");
                (int cursorPositionLeft, int cursorPositionTop) = Console.GetCursorPosition();
                if (message != null && message.Length > 0)
                {
                    Console.WriteLine($"\n\nИнформация:\n  {message}");
                    message = null;
                }
                Console.SetCursorPosition(0, cursorPositionTop + arrayDownPosition);
                
                Console.Write("Числа в массиве:");
                foreach (int number in numbers)
                {
                    Console.Write($" {number}");
                }
                Console.SetCursorPosition(cursorPositionLeft, cursorPositionTop);

                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int newNumber))
                {
                    int[] tempNumbers = new int[numbers.Length + 1];
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    tempNumbers[tempNumbers.Length - 1] = newNumber;
                    numbers = tempNumbers;
                    message = $"В конец массива было добавлено число {newNumber}";
                    continue;
                }
                switch (userInput)
                {
                    case sumCommand:
                        int sum = 0;
                        foreach (int number in numbers)
                        {
                            sum += number;
                        }

                        message = $"Сумма всех чисел в массиве равняется {sum}";
                        break;
                    case exitCommand:
                        canExit = true;
                        break;
                    default:
                        message = $"Вы можете вводить только целые числа, либо команды {sumCommand}, {exitCommand}";
                        break;
                }
            }
        }
    }
}