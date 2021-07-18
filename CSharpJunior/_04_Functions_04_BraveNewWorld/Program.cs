using System;

namespace _04_Functions_04_BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int heroPositionX = 1;
            int heroPositionY = 1;
            int heroDirectionX = 0;
            int heroDirectionY = 0;
            
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
            Console.Clear();
            DrawMap(map);
            Console.WriteLine("\nТвоя главная цель выйти из лабиринта и добраться до '!'");
            Console.WriteLine("\nУправление:" +
                              $"\n  {ConsoleKey.UpArrow} - движение вверх" +
                              $"\n  {ConsoleKey.DownArrow} - движение вниз" +
                              $"\n  {ConsoleKey.RightArrow} - движение вправо" +
                              $"\n  {ConsoleKey.LeftArrow} - движение влево");
            
            while (isPlaying)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        heroDirectionX = -1;
                        heroDirectionY = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        heroDirectionX = 0;
                        heroDirectionY = 1;
                        break;
                    case ConsoleKey.DownArrow:
                        heroDirectionX = 1;
                        heroDirectionY = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        heroDirectionX = 0;
                        heroDirectionY = -1;
                        break;
                }

                switch (map[heroPositionX + heroDirectionX, heroPositionY + heroDirectionY])
                {
                    case ' ':
                        MoveHero(ref heroPositionX, ref heroPositionY, heroDirectionX, heroDirectionY);
                        break;
                    case '!':
                        MoveHero(ref heroPositionX, ref heroPositionY, heroDirectionX, heroDirectionY);
                        isPlaying = false;
                        break;
                }
            }
            
            Console.Clear();
            Console.WriteLine("Ура! Ты сумел найти выход из лабиринта!");
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

        static void MoveHero(ref int heroPositionX, ref int heroPositionY, int heroDirectionX, int heroDirectionY)
        {
            Console.SetCursorPosition(heroPositionY, heroPositionX);
            Console.Write(' ');
            heroPositionX += heroDirectionX;
            heroPositionY += heroDirectionY;
            Console.SetCursorPosition(heroPositionY, heroPositionX);
            Console.Write('@');
        }
    }
}