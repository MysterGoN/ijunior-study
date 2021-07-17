using System;

namespace _04_Functions_05_KansasCityShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = {"Первый", "Второй", "Третий", "Четвертый", "Пятый", "Шестой"};
            Console.WriteLine("До перемешивания: " + string.Join(", ", elements));
            Shuffle(ref elements);
            Console.WriteLine("После перемешивания: " + string.Join(", ", elements));
        }

        static void Shuffle(ref string[] elements)
        {
            string[] tempElements = new string[elements.Length];
            
            for (int i = 0; i < elements.Length; i++)
            {
                while (true)
                {
                    
                }
            }
        }
    }
}