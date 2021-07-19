using System;
using System.Collections.Generic;

namespace _05_Collections_02_StoreQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            const int clientsCount = 5;
            const int totalPriceMin = 1;
            const int totalPriceMax = 99;
            Random random = new Random();
            Queue<int> clients = new Queue<int>();
            int cash = 0;

            for (int i = 0; i < clientsCount; i++)
            {
                clients.Enqueue(random.Next(totalPriceMin, totalPriceMax + 1));
            }

            string clientsPrices = String.Join(", ", clients);
            Console.WriteLine($"Вы только что открыли магазин в вашей кассе {cash} рублей. И уже выстроилась очередь " +
                              $"покупателей c корзинами [{clientsPrices}], будьте готовы их всех обслужить.");
            while (clients.Count > 0)
            {
                int totalPrice = clients.Dequeue();
                Console.WriteLine($"К вам подошел покупатель с товарами на сумму {totalPrice}.");
                cash += totalPrice;
                Console.WriteLine($"После оплаты у вас в кассе стало {cash} рублей.");
                Console.Write("Покупатель упаковал все продукты, будьте готовы обслужить следующего...");
                Console.ReadKey();
                Console.Clear();
            }
            
            Console.WriteLine($"Рабочий день закончился. На конец дня у вас в кассе {cash} рублей.");
        }
    }
}