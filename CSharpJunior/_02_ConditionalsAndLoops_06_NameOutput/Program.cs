using System;

namespace _02_ConditionalsAndLoops_06_NameOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            char ornament;
            
            Console.WriteLine("Вы захотели заказать табличку с вашим именем на дверь. " +
                              "Для этого вы пришли в мастерскую.");
            
            Console.WriteLine("Какое имя вы попросите выбить на табличке.");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            
            Console.WriteLine("Какой орнамент вы выберете?");
            Console.Write("Введите символ: ");
            ornament = Convert.ToChar(Console.ReadKey());
            
            Console.WriteLine("Любуйтесь!");
            
        }
    }
}