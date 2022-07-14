using System;

namespace _01_BasicsOfProgramming_03_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствую солдат! Как твоё имя?");
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("Хм. Ну допустим. В каком полку служил?");
            Console.Write("Введите название вашего полка: ");
            string regiment = Console.ReadLine();
            
            Console.WriteLine("*Выражает удивление*. И ты до сих пор жив? Сколько лет там прослужил?");
            Console.Write("Введите количество лет прошедших с начала службы: ");
            uint yearsOfService = Convert.ToUInt32(Console.ReadLine());
            
            Console.WriteLine("Срок немаленький. И до какого звания успел дослужиться?");
            Console.Write("Введите ваше текущее звание: ");
            string rank = Console.ReadLine();
            
            Console.WriteLine("И какую роль выполнял?");
            Console.Write("Введите выполняемую вами роль в полку: ");
            string role = Console.ReadLine();
            
            Console.WriteLine("Ладно, с формальностями закончили, перепроверь данные и распишись!");
            Console.WriteLine("Краткая сводка:" +
                              $"\n\t- Имя: {name}" +
                              $"\n\t- Полк: {regiment}" +
                              $"\n\t- Срок службы: {yearsOfService} лет" +
                              $"\n\t- Звание: {rank}" +
                              $"\n\t- Роль: {role}");
            
            Console.Write("Нажмите любую кнопку для подтверждения...");
            Console.ReadKey();
            Console.WriteLine();
            
            Console.WriteLine("Добро пожаловать на фронт солдат!");
        }
    }
}