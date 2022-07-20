using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_OOP_09_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket(isOpen: true);

            supermarket.Work();
        }
    }

    class Product
    {
        private const int MinProductPrice = 10;
        private const int MaxProductPrice = 100;

        private string _name;

        public Product(Random random, string name)
        {
            _name = name;
            Price = random.Next(MinProductPrice, MaxProductPrice + 1);
        }

        public int Price { get; private set; }

        public string Info => $"{_name} ({Price} руб.)";
    }

    class Customer
    {
        private const int MinStartingMoney = 100;
        private const int MaxStartingMoney = 500;
        private const int MinStartingProducts = 3;
        private const int MaxStartingProducts = 6;

        private List<Product> _cart;
        private List<Product> _purchasedProducts;

        public Customer(Random random, List<string> productNames)
        {
            productNames = productNames.ToList();
            int startingProductsCount = random.Next(MinStartingProducts, MaxStartingProducts + 1);

            Money = random.Next(MinStartingMoney, MaxStartingMoney + 1);
            _cart = new List<Product>();
            _purchasedProducts = new List<Product>();

            for (int i = 0; i < startingProductsCount; i++)
            {
                int randomProductNumber = random.Next(productNames.Count);
                _cart.Add(new Product(random, productNames[randomProductNumber]));
            }
        }

        public int Money { get; private set; }

        public bool HaveEnoughMoneyToPay()
        {
            return CalculateCartProductsCost() <= Money;
        }

        public int BuyProductsInCart()
        {
            int cartProductsCost = CalculateCartProductsCost();
            Money -= cartProductsCost;

            _purchasedProducts = _cart.ToList();
            _cart = new List<Product>();

            return cartProductsCost;
        }

        public void ShowCartProducts()
        {
            Console.WriteLine("\nКорзина покупателя:");

            foreach (Product product in _cart)
            {
                Console.WriteLine($" - {product.Info}");
            }
        }

        public void DropRandomProduct(Random random)
        {
            int randomProductNumber = random.Next(_cart.Count);

            Console.WriteLine($"Покупателю пришлось расстаться с {_cart[randomProductNumber].Info}.");
            _cart.RemoveAt(randomProductNumber);
        }

        private int CalculateCartProductsCost()
        {
            return _cart.Sum(product => product.Price);
        }
    }

    class Supermarket
    {
        private const int StartingCustomersCount = 10;

        private readonly List<string> _productNames = new List<string>()
            {"Картоха", "Капуста", "Баклажан", "Йогурт", "Яйца", "Сосиски", "Ветчина"};
        
        private Random _random;
        
        private bool _isOpen;
        private int _money;
        private Queue<Customer> _customers;

        public Supermarket(bool isOpen)
        {
            _random = new Random();
            _isOpen = isOpen;
            _money = 0;
            _customers = new Queue<Customer>();

            for (int i = 0; i < StartingCustomersCount; i++)
            {
                _customers.Enqueue(new Customer(_random, _productNames));
            }
        }

        public void Work()
        {
            if (_isOpen == false)
            {
                Console.WriteLine("Супермаркет закрыт!");
                return;
            }

            Console.WriteLine("Супермаркет открыт и будет работать до последнего посетителя!");

            while (_isOpen)
            {
                Console.Write($"\nУ вас {_customers.Count} посетителей." +
                              $"\nНажмите любую клавишу, чтобы прегласить к кассе следующего посетителя...");
                Console.ReadKey();
                Console.Clear();

                Customer customer = _customers.Dequeue();
                WorkAtTheCheckout(customer);

                if (_customers.Count == 0)
                {
                    _isOpen = false;
                }
            }

            Console.WriteLine($"Ну вот, рабочий день подошел к концу, вам удалось заработать {_money} деревянных.");
        }

        private void WorkAtTheCheckout(Customer customer)
        {
            Console.WriteLine("К кассе подходит покупатель с корзиной наполненной продуктами." +
                              $"\nИ в кошельке у него позвякивает {customer.Money} деревянных, но только тс...");
            customer.ShowCartProducts();

            bool isPurchasingEnd = false;

            while (isPurchasingEnd == false)
            {
                if (customer.HaveEnoughMoneyToPay())
                {
                    int productsCost = customer.BuyProductsInCart();
                    _money += productsCost;
                    isPurchasingEnd = true;

                    Console.WriteLine("\nСчастливый посетитель ушел из вашего магазина с продуктами, " +
                                      $"заплатив за них {productsCost} руб.");
                }
                else
                {
                    Console.WriteLine("\nК сожалению у покупателя не хватило денег, " +
                                      "ему придется расстаться с одним случайным продуктом.");
                    customer.DropRandomProduct(_random);
                    customer.ShowCartProducts();
                }
            }
        }
    }
}