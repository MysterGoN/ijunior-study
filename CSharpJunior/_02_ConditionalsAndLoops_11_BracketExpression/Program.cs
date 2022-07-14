using System;

namespace _02_ConditionalsAndLoops_11_BracketExpression
{
    class Program
    {
        /// <summary>
        /// Я очень хочу использовать стэк Т_Т
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char leftBracket = '(';
            char rightBracket = ')';

            string wrongBracketsMessage = "Ты мне что сюда подсунул? А ну иди отсюда, приноси мне " +
                                          "только круглые скобочки!";
            string incorrectBracketsExpressionMessage = "У тебя некорректный набор скобочек! " +
                                                        "Подбирай в следующий раз нормальные!";
            string correctBracketsExpressionMessage = "Ну вот! Молодец! Стараешься когда можешь! " +
                                                      "Глубина же тут - {0}.";

            Console.WriteLine("Ну что ты опять ко мне пришел? Я же уже объяснял, что нужно делать " +
                              "с этими скобками. Чего ты на меня так жалостливо смотришь этими " +
                              "щенячьими глазками? Арргх. Ладно, что с тобой поделаешь, давай их сюда.");

            Console.Write("Введите сообщение состоящее только из скобочек: ");
            string brackets = Console.ReadLine();

            int maxDepth = 0;
            int leftBracketsCount = 0;
            foreach (var bracket in brackets)
            {
                if (bracket == leftBracket)
                {
                    leftBracketsCount++;
                    if (maxDepth < leftBracketsCount)
                    {
                        maxDepth = leftBracketsCount;
                    }
                }
                else if (bracket == rightBracket)
                {
                    leftBracketsCount--;
                }
                else
                {
                    Console.WriteLine(wrongBracketsMessage);
                    return;
                }

                if (leftBracketsCount < 0)
                {
                    Console.WriteLine(incorrectBracketsExpressionMessage);
                    return;
                }
            }

            if (leftBracketsCount == 0)
            {
                Console.WriteLine(correctBracketsExpressionMessage, maxDepth);
            }
            else
            {
                Console.WriteLine(incorrectBracketsExpressionMessage);
            }
        }
    }
}