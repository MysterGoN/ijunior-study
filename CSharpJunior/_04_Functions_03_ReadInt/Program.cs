using System;

namespace _04_Functions_03_ReadInt
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                if (TryGetNumberFromUser(out int number))
                {
                    Console.WriteLine($"Ура! Вам удалось ввести число: {number}");
                    break;
                }
                Console.WriteLine("Вы ввели неправильное число, попробуйте ещё раз!");
                Console.Write("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        static bool TryGetNumberFromUser(out int number)
        {
            Console.Write("Введите число: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out number))
            {
                return true;
            }

            return false;
        }
    }
}