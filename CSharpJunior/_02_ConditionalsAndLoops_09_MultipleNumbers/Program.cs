using System;

namespace _02_ConditionalsAndLoops_09_MultipleNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int minThreeDigitsNumber = 100;
            int maxThreeDigitsNumber = 999;
            int minRandomNumber = 1;
            int maxRandomNumber = 27;

            Console.WriteLine("Как такое могло со мной приключиться? Жизнь меня к такому не готовила. " +
                              "Меня готовили ко всему, к пыткам, к преодолеванию боли, попыткам утопить, " +
                              "голоду, холоду... Но только не к этому! Кто же знал, что мне придется " +
                              "искать кратные трехзначные числа, тому числу, которые нам назовут???" +
                              "Я скоро сойду с ума, ну вот они еще одно собираются назвать.");

            int randomNumber = random.Next(minRandomNumber, maxRandomNumber + 1);

            Console.WriteLine($"{randomNumber} - сказал кто-то из темноты.\n" +
                              "Ну началось, подумал я и начал считать.");

            int threeDigitsNumbersCount = 0;
            for (int i = 0; i <= maxThreeDigitsNumber; i += randomNumber)
            {
                if (i >= minThreeDigitsNumber)
                {
                    threeDigitsNumbersCount++;
                }
            }

            Console.WriteLine($"{threeDigitsNumbersCount} - с трудом выдавил я. " +
                              "И из темноты послышалось \"Правльно!\". Я с облегчением выдохнул " +
                              "и стал ждать продолжения пытки.");
        }
    }
}