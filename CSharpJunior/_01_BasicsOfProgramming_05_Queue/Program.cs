using System;

namespace _01_BasicsOfProgramming_05_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint minutestInHour = 60;
            uint timeOfReceiptInMinutes = 10;

            Console.Write("Введите количество людей в очереди, которое вы видите перед собой: ");
            uint peopleInQueue = Convert.ToUInt32(Console.ReadLine());

            uint waitingTimeInMinutes = peopleInQueue * timeOfReceiptInMinutes;

            uint hours = waitingTimeInMinutes / minutestInHour;
            uint minutes = waitingTimeInMinutes % minutestInHour;

            Console.WriteLine($"Время вашего ожидание в очереди составляет {hours} часов {minutes} минут.");
        }
    }
}