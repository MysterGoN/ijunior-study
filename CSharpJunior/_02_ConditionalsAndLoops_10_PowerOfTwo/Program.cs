using System;

namespace _02_ConditionalsAndLoops_10_PowerOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            int minRandomNumber = 0;
            int maxRandomNumber = 10000;
            
            Console.WriteLine("- Коллега, а давайте с вами поиграем в игру, я назову вам число, " +
                              "а вам нужно бдует найти ближайшее большее число, которое при этом еще " +
                              "и будет степенью двойки! Как вам такая идея?");
            
            Console.WriteLine("- Ну задавай коль не шутишь. - c усмешкой я ему ответил.");

            int randomNumber = random.Next(minRandomNumber, maxRandomNumber + 1);
            
            Console.WriteLine($"- Хм... дай как подумать, как на счет - {randomNumber}?");

            int power = 1;
            int powerOfTwo = 2;
            bool canExit = false;
            while (!canExit)
            {
                if (powerOfTwo > randomNumber)
                {
                    canExit = true;
                }
                else
                {
                    powerOfTwo *= 2;
                    power++;
                }
            }
            
            Console.WriteLine($"- Cтепень равна: {power}, а число {powerOfTwo}. " +
                              "- Недолго думая ответил я.");
            
        }
    }
}