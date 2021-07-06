using System;

namespace _02_ConditionalsAndLoops_02_ExitControl
{
    class Program
    {
        /// <summary>
        /// Задачу можно решить также использую условия выхода внутри цикла и оператор break.
        /// </summary>
        /// <example>
        /// while (true)
        /// {
        ///     if (action == exitPhrase)
        ///     {
        ///         break;
        ///     }
        ///     ...
        /// }
        /// </example>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            const string exitPhrase = "Выпусти меня!";
            uint daysOfImprisonment = 1;
            string action = "";
            
            Console.WriteLine("Смертный! Ты оказался заточен в моём пространстве!" +
                              "\nОтсюда нет выхода, иди куда хочешь, делай что хочешь!" +
                              "\nНо вдруг, если тебе надоест, ты можешь встать на колени и слёзно умолять меня " +
                              $"выпустить тебя словами \"{exitPhrase}\"." +
                              "\nИ может быть я смилостивлюсь и выпущу тебя отсюда!");

            while (action != exitPhrase)
            {
                Console.WriteLine($"Вы в заточении уже {daysOfImprisonment++} дней." +
                                  "\nЧем хотите заняться?" +
                                  $"\nИли может быть хотите закончить? Вам всего лишь надо сказать \"{exitPhrase}\".");
                Console.Write($"Введите любое действие или фразу \"{exitPhrase}\": ");
                action = Console.ReadLine();
            }
        }
    }
}