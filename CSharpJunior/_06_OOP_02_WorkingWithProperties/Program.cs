using System;

namespace _06_OOP_02_WorkingWithProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player('@', 5, 4);
            Renderer renderer = new Renderer();
            
            renderer.DrawPlayer(player);
        }
    }

    class Player
    {
        public char Symbol { get; }
        public int X { get; }
        public int Y { get; }

        public Player(char symbol, int x, int y)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }
    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(player.Symbol);
        }
    }
}