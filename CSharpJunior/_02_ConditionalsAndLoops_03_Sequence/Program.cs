using System;

namespace _02_ConditionalsAndLoops_05_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxValue = 100;
            const int step = 7;
            
            for (int i = step; i < maxValue; i += step)
            {
                Console.Write($"{i} ");
            }
        }
    }
}