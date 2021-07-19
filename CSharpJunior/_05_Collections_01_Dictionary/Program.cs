using System;
using System.Collections.Generic;

namespace _05_Collections_01_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            const string exitWord = "exit";
            Dictionary<string, string> englishRussianDictionary = new Dictionary<string, string>
            {
                {"gold", "золото"},
                {"experience", "опыт"},
                {"human", "человек"},
                {"target", "цель"},
                {"book", "книга"}
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Перед вами Англо-русский словарь. Введите слово на английском, " +
                                  $"чтобы получить перевод. Чтобы выйти напишите слово '{exitWord}', " +
                                  "а также оно переводится как 'выход' поэтому вам не нужно искать его в словаре.");
                Console.Write($"Введите слово для перевода или '{exitWord}': ");
                string word = Console.ReadLine();

                if (exitWord.Equals(word))
                {
                    break;
                }

                if (word != null && englishRussianDictionary.TryGetValue(word, out string translation))
                {
                    Console.WriteLine($"Перевод слова {word} - {translation}");
                }
                else
                {
                    Console.WriteLine("Такого слова нет в словаре! Попробуйте ввести другое слово.");
                }

                Console.Write("Для продолжения нажмите любую кнопку...");
                Console.ReadKey();
            }
        }
    }
}