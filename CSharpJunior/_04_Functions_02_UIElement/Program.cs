using System;

namespace _04_Functions_02_UIElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            DrawColoredBar(0, 0, 15, 69, "HP");
            DrawColoredBar(0, 1, 10, 10, "MP", ConsoleColor.Blue);
            DrawColoredBar(0, 2, 5, 70, "SP", ConsoleColor.Green);
        }

        static void DrawColoredBar(int positionLeft, int positionTop, int length, int percent, string prefix,
            ConsoleColor fillColor = ConsoleColor.Red, ConsoleColor emptyColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(positionLeft, positionTop);
            ConsoleColor backgroundColor = Console.BackgroundColor;
            
            Console.Write($"{prefix}: [");
            int fillLength = Convert.ToInt32(length * (percent / 100.0));
            Console.BackgroundColor = fillColor;
            for (int i = 0; i < fillLength; i++)
            {
                Console.Write(" ");
            }

            Console.BackgroundColor = emptyColor;
            for (int i = fillLength; i < length; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = backgroundColor;
            Console.Write("]");
        }
    }
}