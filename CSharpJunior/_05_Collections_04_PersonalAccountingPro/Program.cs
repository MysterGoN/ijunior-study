using System;
using System.Collections.Generic;

namespace _05_Collections_04_PersonalAccountingPro
{
    class Program
    {
        static void Main(string[] args)
        {
            const char addDossierCode = '1';
            const char showAllDossiersCode = '2';
            const char deleteDossierCode = '3';
            const char generateDossiersCode = '4';
            const char exitMenuCode = '0';
            const int dossiersPositionLeft = 40, dossiersPositionTop = 0;

            Dictionary<string, string> dossiers = new Dictionary<string, string>();
            bool canExit = false;
            
            while (!canExit)
            {
                Console.Clear();
                Console.WriteLine("Работа с консолью:" +
                                  $"\n  {addDossierCode} - добавить досье" +
                                  $"\n  {showAllDossiersCode} - вывести все досье" +
                                  $"\n  {deleteDossierCode} - удалить досье" +
                                  $"\n  {generateDossiersCode} - заполнить массивы данными" +
                                  $"\n  {exitMenuCode} - выход");

                Console.Write("\nВведите команду: ");

                char userInputCode = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (userInputCode)
                {
                    case addDossierCode:
                        AddDossier(ref dossiers);
                        break;
                    case showAllDossiersCode:
                        ShowDossiers(dossiers, dossiersPositionLeft, dossiersPositionTop);
                        break;
                    case deleteDossierCode:
                        ShowDossiers(dossiers, dossiersPositionLeft, dossiersPositionTop);
                        DeleteDossier(dossiers);
                        break;
                    case generateDossiersCode:
                        GenerateDossiersData(ref dossiers);
                        break;
                    case exitMenuCode:
                        canExit = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }
                Console.Write("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }
        
        static void AddDossier(ref Dictionary<string, string> dossiers)
        {
            Console.Write("Введите ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();
            if (fullName == null || position == null)
            {
                Console.WriteLine("Не удалось добавить досье. Значения не должны быть пустыми.");
                return;
            }
            
            dossiers.Add(fullName, position);
            Console.WriteLine($"Досье {fullName} - {position} было добавлено успешно");
        }
        
        static void ShowDossiers(Dictionary<string, string> dossiers, int consolePositionLeft, int consolePositionTop)
        {
            (int cursorPositionLeft, int cursorPositionTop) = Console.GetCursorPosition();
            Console.SetCursorPosition(consolePositionLeft, consolePositionTop);
            
            Console.WriteLine("Досье: ");
            int positionTop = 1;
            foreach (var dossier in dossiers)
            {
                Console.SetCursorPosition(consolePositionLeft, consolePositionTop + positionTop);
                Console.Write($"  {dossier.Key} - {dossier.Value}");
                positionTop++;
            }

            Console.SetCursorPosition(cursorPositionLeft, cursorPositionTop);
        }
        
        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            Console.Write("Введите ФИО досье для удаления: ");
            string fullName = Console.ReadLine();
            if (fullName != null && dossiers.Remove(fullName, out string position))
            {
                Console.WriteLine($"Досье на {fullName} и должность {position} удалено успешно.");
            }
            else
            {
                Console.WriteLine($"Нет досье на: {fullName}.");
            }
        }
        
        static void GenerateDossiersData(ref Dictionary<string, string> dossiers)
        {
            dossiers.Add("Иванов Иван Иванович", "Директор");
            dossiers.Add("Иванов Сергей Иванович", "Заместитель директора");
            dossiers.Add("Иванов Иван Сергеевич", "Заведующий складом");
            dossiers.Add("Иванов Сергей Сергеевич", "Охранник");
            Console.WriteLine("Заготовленные данные были успешно добавлены");
        }
    }
}