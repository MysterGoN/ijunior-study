using System;

namespace _02_ConditionalsAndLoops_04_SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int minNumber = 0;
            int maxNumber = 100;
            int multipleOfThree = 3;
            int multipleOfFive = 5;

            Random random = new Random();
            Console.WriteLine("Вы гуляете по заброшенному замку и заходите в одну из комнат. " +
                              "Комната с виду пустая, но в центре неё имеется постамент, " +
                              "в центре которого лежит шар, а перед ним табличка с надписью \"Потряси меня!\".");

            int randomNumber = random.Next(minNumber, maxNumber + 1);

            Console.WriteLine($"Вы взяли шар и потрясли его, и внутри него появилось число: {randomNumber}.");

            if (randomNumber < multipleOfThree)
            {
                Console.WriteLine("Шар еще какое-то время показывал число и потух, больше ничего не происходило. " +
                                  "И вы без какого либо интереса положили шар на место и пошли дальше.");
                return;
            }

            Console.WriteLine("Неожиданно шар начал светиться всеми цветами радуги " +
                              "и внутри него что-то начало меняться, стали сменять друг дурга числа, " +
                              "появляться странные символы... Что бы все это могло значить?");

            int totalSum = 0;
            for (int i = multipleOfThree; i <= randomNumber; i++)
            {
                if (i % multipleOfThree == 0 || i % multipleOfFive == 0)
                {
                    totalSum += i;
                }
            }

            Console.WriteLine("В какой-то момент свечение прекратилось " +
                              $"и внутри шара сформировалось число: {totalSum}. " +
                              "Вы совершенно не поняли что это число значит, вы положили шар на место, " +
                              "вышли из замка и решили больше никогда не ходить по столь странным местам.");
        }
    }
}