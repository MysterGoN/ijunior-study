using System;

namespace _01_BasicsOfProgramming_05_Queue
{
    class Program
    {
        /// <summary>
        /// В рамках данного кода все переменные завязанные на время хранят значение в Минутах:
        ///     - timeOfReceipt
        ///     - waitingTime
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const uint minutestInHour = 60;
            uint timeOfReceipt = 10;

            Console.Write("Введите количество людей в очереди, которое вы видите перед собой: ");
            uint peopleInQueue = Convert.ToUInt32(Console.ReadLine());

            uint waitingTime = peopleInQueue * timeOfReceipt;

            uint hours = waitingTime / minutestInHour;
            uint minutes = waitingTime % minutestInHour;

            Console.WriteLine($"Время вашего ожидание в очереди составляет {hours} часов {minutes} минут.");
        }
    }
}