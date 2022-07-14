using System;

namespace _01_BasicsOfProgramming_05_SwitchValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = "Stockholm";
            string city = "Sweden";
            
            Console.WriteLine("Откуда вы прибыли в нашу прекрасную Арстоцку?\n" +
                              $"Страна: {country}, Город: {city}.");
            Console.WriteLine("Вы явно что-то напутали, проверьте пожалуйста еще раз!");

            (city, country) = (country, city);

            Console.WriteLine($"Страна: {country}, Город: {city}.");
            Console.WriteLine("Вот теперь все корректно!");
        }
    }
}