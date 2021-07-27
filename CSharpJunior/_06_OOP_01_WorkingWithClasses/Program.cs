using System;

namespace _06_OOP_01_WorkingWithClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Bob", 100, 10);
            player.ShowInfo();
        }
    }

    class Player
    {
        private int _health;
        public string Name { get; private set; }
        public int Money { get; private set; }

        public Player(string name, int health, int money)
        {
            Name = name;
            _health = health;
            Money = money;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Параметры игрока:" +
                              $"\n  Имя: {Name}" +
                              $"\n  Здоровье: {_health}" +
                              $"\n  Деньги: {Money}");
        }
    }
}