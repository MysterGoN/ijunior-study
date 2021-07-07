using System;

namespace _02_ConditionalsAndLoops_07_PasswordProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxTries = 3;
            int currentTry;
            string secretMessage = "Это супер пупер секретное сообщение. Ты никогда не должен был увидеть его. " +
                                   "Как ты вообще смог его увидеть? Ты как-то узнал пароль? Не уж то подобрал? " +
                                   "В общем молодец. Тортик ложь! Все дела.";
            string secretPassword = "qwerty12345678";
            string password;

            Console.WriteLine("Вы проникли на суперсекретную базу, откуда вам необходимо выведать информацию " +
                              "об объекте под секретным названием \"ТОРТИК\"");
            for (currentTry = maxTries; currentTry > 0; currentTry--)
            {
                Console.WriteLine($"У вас осталось {currentTry} попыток, чтобы отгадать пароль!");
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if (password == secretPassword)
                {
                    Console.WriteLine(secretMessage);
                    break;
                }
                Console.WriteLine("Пароль неверный!");
            }

            if (currentTry == 0)
            {
                Console.WriteLine("Ты никогда не узнаешь моих тайн!");
            }
        }
    }
}