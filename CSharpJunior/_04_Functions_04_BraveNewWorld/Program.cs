using System;

namespace _04_Functions_04_BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            const int leftDirection = 0;
            const int rightDirection = 0;
            
            char[,] map = 
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                {'#', '@', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ', '#', ' ', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', ' ', '#' },
                {'#', ' ', '#', ' ', '#', '#', '#', '#', '#', '!', '#', ' ', ' ', ' ', '#' },
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', '#', '#', '#' },
                {'#', ' ', '#', '#', '#', '#', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#' },
                {'#', ' ', '#', ' ', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', ' ', '#' },
                {'#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                {'#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', '#' },
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                DrawMap(map);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                }
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}