using System;
using System.Collections.Generic;

namespace _06_OOP_06_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            const char CodeShowSellerItems = '1';
            const char CodeBuyItem = '2';
            const char CodeShowYourItems = '3';
            const char CodeExitMenu = '0';

            Seller seller = new Seller(200);
            Player player = new Player("Nick", 100);

            bool canExit = false;

            while (!canExit)
            {
                Console.Clear();
                Console.WriteLine("Работа с консолью:" +
                                  $"\n  {CodeShowSellerItems} - показать товары продавца" +
                                  $"\n  {CodeBuyItem} - купить товар" +
                                  $"\n  {CodeShowYourItems} - посмотреть купленные товары" +
                                  $"\n  {CodeExitMenu} - выход");

                Console.Write("\nВведите команду: ");

                char userInputCode = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                switch (userInputCode)
                {
                    case CodeShowSellerItems:
                        seller.ShowItems();
                        break;

                    case CodeBuyItem:
                        seller.SellItem(player);
                        break;

                    case CodeShowYourItems:
                        player.ShowItems();
                        break;

                    case CodeExitMenu:
                        canExit = true;
                        break;

                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }

                Console.Write("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }
    }

    class Item
    {
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public int Price { get; private set; }

        public string Info => $"{Name} ({Price})";
    }

    abstract class Person
    {
        protected int Money;
        protected List<Item> Items;

        public void ShowItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i} - {Items[i].Info}");
            }
        }
    }

    class Seller : Person
    {
        public Seller(int money)
        {
            Money = money;
            Items = new List<Item>()
            {
                new Item("Картоха", 10),
                new Item("Золотой слиток", 1000),
                new Item("Веревка", 50),
                new Item("Кубик", 5),
                new Item("Ложка", 3),
            };
        }

        public void SellItem(Player player)
        {
            ShowItems();
            Console.Write("\nВведите номер товара для покупки: ");

            if (int.TryParse(Console.ReadLine(), out int itemId))
            {
                if (itemId < 0 || itemId > Items.Count - 1)
                {
                    Console.WriteLine($"Товара под номером {itemId} нет.");
                    return;
                }

                Item itemForSale = Items[itemId];

                if (player.CheckSolvency(itemForSale))
                {
                    Money += player.BuyItem(itemForSale);
                    Items.RemoveAt(itemId);
                }
                else
                {
                    Console.WriteLine($"Игроку {player.Name} не хватает денег чтобы заплатить.");
                }
            }
            else
            {
                Console.WriteLine("Необходимо ввести число!");
            }
        }
    }

    class Player : Person
    {
        public Player(string name, int money)
        {
            Name = name;
            Money = money;
            Items = new List<Item>();
        }

        public string Name { get; private set; }

        public bool CheckSolvency(Item item)
        {
            return Money >= item.Price;
        }

        public int BuyItem(Item item)
        {
            Money -= item.Price;
            Items.Add(item);

            Console.WriteLine($"Игрок {Name} купил \"{item.Name}\" за {item.Price} и осталось {Money}.");

            return item.Price;
        }
    }
}