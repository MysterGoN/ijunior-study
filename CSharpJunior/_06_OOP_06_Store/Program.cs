using System;
using System.Collections.Generic;

namespace _06_OOP_06_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            const char showSellerItemsCode = '1';
            const char buyItemCode = '2';
            const char showYourItemsCode = '3';
            const char exitMenuCode = '0';

            Seller seller = new Seller(200);
            Player player = new Player("Nick", 100);

            bool canExit = false;

            while (!canExit)
            {
                Console.Clear();
                Console.WriteLine("Работа с консолью:" +
                                  $"\n  {showSellerItemsCode} - показать товары продавца" +
                                  $"\n  {buyItemCode} - купить товар" +
                                  $"\n  {showYourItemsCode} - посмотреть купленные товары" +
                                  $"\n  {exitMenuCode} - выход");

                Console.Write("\nВведите команду: ");

                char userInputCode = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                switch (userInputCode)
                {
                    case showSellerItemsCode:
                        seller.ShowItems();
                        break;

                    case buyItemCode:
                        seller.ShowItems();
                        Console.Write("\nВведите номер товара для покупки: ");

                        if (Int32.TryParse(Console.ReadLine(), out int itemId))
                        {
                            seller.SellItem(itemId, player);
                        }
                        else
                        {
                            Console.WriteLine("Необходимо ввести число!");
                        }

                        break;

                    case showYourItemsCode:
                        player.ShowItems();
                        break;

                    case exitMenuCode:
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
        private int _price;

        public Item(string name, int price)
        {
            Name = name;
            _price = price;
        }

        public string Name { get; private set; }

        public int Cost
        {
            get { return _price; }
        }

        public string Info
        {
            get { return $"{Name} ({Cost})"; }
        }
    }

    class Seller
    {
        private int _money;
        private List<Item> _items;

        public Seller(int money)
        {
            _money = money;
            _items = new List<Item>()
            {
                new Item("Картоха", 10),
                new Item("Золотой слиток", 1000),
                new Item("Веревка", 50),
                new Item("Кубик", 5),
                new Item("Ложка", 3),
            };
        }

        public void ShowItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i} - {_items[i].Info}");
            }
        }

        public void SellItem(int itemId, Player player)
        {
            if (itemId < 0 || itemId > _items.Count - 1)
            {
                Console.WriteLine($"Товара под номером {itemId} нет.");
                return;
            }

            Item itemForSale = _items[itemId];

            if (player.CheckSolvency(itemForSale))
            {
                _money += player.PayForItem(itemForSale);
                _items.RemoveAt(itemId);
            }
            else
            {
                Console.WriteLine($"Игроку {player.Name} не хватает денег чтобы заплатить.");
            }
        }
    }

    class Player
    {
        private int _money;
        private List<Item> _items = new List<Item>();

        public Player(string name, int money)
        {
            Name = name;
            _money = money;
        }

        public string Name { get; private set; }

        public bool CheckSolvency(Item item)
        {
            return _money >= item.Cost;
        }

        public int PayForItem(Item item)
        {
            _money -= item.Cost;
            _items.Add(item);

            Console.WriteLine($"Игрок {Name} купил \"{item.Name}\" за {item.Cost} и осталось {_money}.");

            return item.Cost;
        }

        public void ShowItems()
        {
            foreach (Item item in _items)
            {
                Console.WriteLine(item.Info);
            }
        }
    }
}