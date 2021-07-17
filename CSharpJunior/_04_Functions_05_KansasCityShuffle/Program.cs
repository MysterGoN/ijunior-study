using System;

namespace _04_Functions_05_KansasCityShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            Console.Clear();
            string[] elements = {"Первый", "Второй", "Третий", "Четвертый", "Пятый", "Шестой"};
            Console.WriteLine("До перемешивания: " + string.Join(", ", elements));
            Shuffle(ref elements, random);
            Console.WriteLine("После перемешивания: " + string.Join(", ", elements));
        }

        static void Shuffle(ref string[] elements, Random random)
        {
            string[] tempElements = new string[elements.Length];
            
            for (int i = 0; i < tempElements.Length; i++)
            {
                int randomElement = random.Next(0, elements.Length);
                tempElements[i] = elements[randomElement];
                DeleteElementFromArray(ref elements, randomElement);
            }

            elements = tempElements;
        }
        
        static void DeleteElementFromArray(ref string[] array, int elementPosition)
        {
            string[] tempArray = new string[array.Length - 1];
            for (int i = 0, position = 0; i < array.Length; i++)
            {
                if (i == elementPosition)
                {
                    continue;
                }
                tempArray[position] = array[i];
                position++;
            }

            array = tempArray;
        }
    }
}