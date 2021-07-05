using System;

namespace _03_Pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            uint pictures = 52;
            uint columns = 3;

            uint rows = pictures / columns;
            uint remainder = pictures % columns;
            
            
            Console.WriteLine($"У вас имеется {pictures} картинки.");
            Console.WriteLine($"Их необходимо разложить по {columns} колонкам.");
            Console.WriteLine($"В итоге будет полностью заполнено {rows} рядов. В остатке будет {remainder} картинка.");
        }
    }
}