using System;

namespace _02_ConditionalsAndLoops_04_ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            const string availableColorsCommand = "AvailableColors";
            const string setConsoleColorCommand = "SetConsoleColor";
            const string setFontColorCommand = "SetFontColor";
            const string resetConsoleColorsCommand = "ResetConsoleColors";
            const string exitCommand = "Exit";
            const string noSuchColorMessage = "Цвета {0} не существует";
            ConsoleColor consoleColor;
            string availableConsoleColors = string.Join(", ", Enum.GetNames(typeof(ConsoleColor)));
            bool isJobDone = false;
            string message = null;
            string command;
            string color;

            while (!isJobDone)
            {
                Console.Clear();
                if (message != null && message.Length > 0)
                {
                    Console.WriteLine($"Сообщение: {message}\n");
                    message = null;
                }

                Console.WriteLine("Доступные команды:" +
                                  $"\n\t{availableColorsCommand} - показать все доступные цвета консоли" +
                                  $"\n\t{setConsoleColorCommand} - задать цвет фона консоли" +
                                  $"\n\t{setFontColorCommand} - задать цвет шрифта консоли" +
                                  $"\n\t{resetConsoleColorsCommand} - сброс цветов консоли к значениям по умолчанию" +
                                  $"\n\t{exitCommand} - выйти\n");
                Console.Write("Введите команду: ");
                command = Console.ReadLine();
                switch (command)
                {
                    case availableColorsCommand:
                        message = "Доступны следующие цвета:" +
                                  $"\n\t{availableConsoleColors}";
                        break;
                    case setConsoleColorCommand:
                        Console.Write("Введите цвет фона: ");
                        color = Console.ReadLine();
                        if (Enum.TryParse(color, out consoleColor))
                        {
                            Console.BackgroundColor = consoleColor;
                        }
                        else
                        {
                            message = string.Format(noSuchColorMessage, color);
                        }
                        break;
                    case setFontColorCommand:
                        Console.Write("Введите цвет шрифта: ");
                        color = Console.ReadLine();
                        if (Enum.TryParse(color, out consoleColor))
                        {
                            Console.ForegroundColor = consoleColor;
                        }
                        else
                        {
                            message = string.Format(noSuchColorMessage, color);
                        }
                        break;
                    case resetConsoleColorsCommand:
                        Console.ResetColor();
                        break;
                    case exitCommand:
                        isJobDone = true;
                        break;
                    default:
                        message = "Такой команды не существует!";
                        break;
                }
            }
            Console.WriteLine("Возвращайтесь ещё!");
        }
    }
}