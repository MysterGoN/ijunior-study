using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            float health;
            int armor;
            int damage;
            
            Console.Write("Введите кол-во жизней: ");
            health = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во брони: ");
            armor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во урона: ");
            damage = Convert.ToInt32(Console.ReadLine());

            health -= Convert.ToSingle(damage) / 100 * armor;

            Console.WriteLine($"После атаки в {damage} урона, у вас осталось {health} жизней.");
            
        }
    }
}