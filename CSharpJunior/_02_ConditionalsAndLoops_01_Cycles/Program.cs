using System;

namespace _02_ConditionalsAndLoops_01_Cycles
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            uint numberOfIterations;
            
            Console.WriteLine("Вы подошли к колодцу и смотрите вниз, воды не видно, но вас не покидает чувство, " +
                              "что кто-то смотрит на вас!" +
                              "\nНе выдержав такого давления вы решаетесь заговорить.");
            Console.Write("Введите фразу, которую хотите сказать: ");
            message = Console.ReadLine();
            Console.Write($"Ведите насколько громко вы произнесли эту фразу (целое число от 1 до {UInt32.MaxValue}): ");
            numberOfIterations = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("А в ответ вы услышали только:");
            for (int i = 0; i < numberOfIterations; i++)
            {
                Console.WriteLine($"\t{message}");
            }
        }
    }
}