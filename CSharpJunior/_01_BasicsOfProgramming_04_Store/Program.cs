using System;

namespace _01_BasicsOfProgramming_04_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            uint crystalPrice = 12;
            uint gold;
            uint crystals;
            
            Console.Write("Введите сколько у вас золота: ");
            gold = Convert.ToUInt32(Console.ReadLine());
            
            Console.WriteLine($"Сегодня кристаллы стоят {crystalPrice} золотых за штуку.");
            Console.Write("Введите сколько кристаллов вы хотите приобрести: ");
            crystals = Convert.ToUInt32(Console.ReadLine());
            gold -= crystals * crystalPrice;
            
            Console.WriteLine($"Вы приобрели {crystals} кристаллов. У вас осталось {gold} золота.");
        }
    }
}