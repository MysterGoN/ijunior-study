using System;

namespace _02_ConditionalsAndLoops_03_ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const string usdName = "USD";
            const string yenName = "JPY";
            const string rubName = "RUB";
            
            const float usdToRub = 73.43f;
            const float rubToUsd = 0.014f;

            const float yenToRub = 0.66f;
            const float rubToYen = 1.51f;
            
            const float yenToUsd = 0.009f;
            const float usdToYen = 110.61f;

            const string exitCommand = "выйти";

            string listOfCurrencies = $"({usdName}, {yenName}, {rubName})";

            string command;
            string firstCurrency;
            string secondCurrency;

            string secondMessageTemplate = "Введите валюту, в которую хотите обменять {0}: ";
            string amountCurrencyMessage = "Введите количество валюты, которое хотите обменять: ";
            string noSuchCurrencyMessage = "У нас нет такой валюты!";
            string sameCurrenciesMessage = "Вы выбрали ту же валюту, обмен произведён не был.";

            float usd;
            float yen;
            float rub;

            float amountOfCurrency;

            
            Console.WriteLine("Вы пришли в обменник валют. У нас самые честные курсы обмена!" +
                              "\nТолько сегодня и только сейчас вы можете обменять наши валюты " +
                              $"{listOfCurrencies} по самым выгодным ценам:" +
                              $"\n\t- {usdName} в {rubName} за {usdToRub}" +
                              $"\n\t- {rubName} в {usdName} за {rubToUsd}" +
                              $"\n\t- {yenName} в {rubName} за {yenToRub}" +
                              $"\n\t- {rubName} в {yenName} за {rubToYen}" +
                              $"\n\t- {yenName} в {usdName} за {yenToUsd}" +
                              $"\n\t- {usdName} в {yenName} за {usdToYen}");

            Console.WriteLine("Сколько валют у вас с собой?");
            string availableCurrencyMessage = "Введите количество {0} взятые с собой: ";
            Console.Write(availableCurrencyMessage, usdName);
            usd = Convert.ToSingle(Console.ReadLine());
            Console.Write(availableCurrencyMessage, yenName);
            yen = Convert.ToSingle(Console.ReadLine());
            Console.Write(availableCurrencyMessage, rubName);
            rub = Convert.ToSingle(Console.ReadLine());
            
            while (true)
            {
                Console.WriteLine("Вы хотите обменять валюту или выйти?" +
                                  $"\n\t- Для выхода введите команду \"{exitCommand}\"" +
                                  "\n\t- Для обмена валют введите любую команду или оставьте поле пустым");
                Console.Write("Введите команду: ");
                command = Console.ReadLine();
                if (command == exitCommand)
                {
                    break;
                }
                
                Console.WriteLine("У вас на счету сейчас следующие валюты:" +
                                  $"\n\t - {usdName}: {usd}" +
                                  $"\n\t - {yenName}: {yen}" +
                                  $"\n\t - {rubName}: {rub}");
                
                Console.Write($"Введите валюту, которую хотите обменять {listOfCurrencies}: ");
                firstCurrency = Console.ReadLine();

                switch (firstCurrency)
                {
                    case usdName:
                        Console.Write(amountCurrencyMessage);
                        amountOfCurrency = Convert.ToSingle(Console.ReadLine());
                        
                        Console.Write(secondMessageTemplate, $"({yenName}, {rubName})");
                        secondCurrency = Console.ReadLine();

                        switch (secondCurrency)
                        {
                            case yenName:
                                usd -= amountOfCurrency;
                                yen += amountOfCurrency * usdToYen;
                                break;
                            case rubName:
                                usd -= amountOfCurrency;
                                rub += amountOfCurrency * usdToRub;
                                break;
                            case usdName:
                                Console.WriteLine(sameCurrenciesMessage);
                                break;
                            default:
                                Console.WriteLine(noSuchCurrencyMessage);
                                break;
                        }
                        
                        break;
                    case yenName:
                        Console.Write(amountCurrencyMessage);
                        amountOfCurrency = Convert.ToSingle(Console.ReadLine());
                        
                        Console.Write(secondMessageTemplate, $"({usdName}, {rubName})");
                        secondCurrency = Console.ReadLine();
                        
                        switch (secondCurrency)
                        {
                            case usdName:
                                yen -= amountOfCurrency;
                                usd += amountOfCurrency * yenToUsd;
                                break;
                            case rubName:
                                yen -= amountOfCurrency;
                                rub += amountOfCurrency * yenToRub;
                                break;
                            case yenName:
                                Console.WriteLine(sameCurrenciesMessage);
                                break;
                            default:
                                Console.WriteLine(noSuchCurrencyMessage);
                                break;
                        }
                        break;
                    case rubName:
                        Console.Write(amountCurrencyMessage);
                        amountOfCurrency = Convert.ToSingle(Console.ReadLine());
                        
                        Console.Write(secondMessageTemplate, $"({usdName}, {yenName})");
                        secondCurrency = Console.ReadLine();
                        
                        switch (secondCurrency)
                        {
                            case usdName:
                                rub -= amountOfCurrency;
                                usd += amountOfCurrency * rubToUsd;
                                break;
                            case yenName:
                                rub -= amountOfCurrency;
                                yen += amountOfCurrency * rubToYen;
                                break;
                            case rubName:
                                Console.WriteLine(sameCurrenciesMessage);
                                break;
                            default:
                                Console.WriteLine(noSuchCurrencyMessage);
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine(noSuchCurrencyMessage);
                        break;
                }
            }
            
            Console.WriteLine("Приходите ещё!");
        }
    }
}