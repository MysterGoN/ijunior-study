using System;

namespace _04_Functions_01_PersonnelAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            const char addDossierCode = '1';
            const char showAllDossiersCode = '2';
            const char deleteDossierCode = '3';
            const char searchByNameCode = '4';
            const char generateDossiersCode = '5';
            const char exitMenuCode = '0';

            string[] fullNames = new string[0];
            string[] positions = new string[0];
            bool canExit = false;
            int dossiersPositionLeft = 40, dossiersPositionTop = 0;

            while (!canExit)
            {
                Console.Clear();
                Console.WriteLine("Работа с консолью:" +
                                  $"\n  {addDossierCode} - добавить досье" +
                                  $"\n  {showAllDossiersCode} - вывести все досье" +
                                  $"\n  {deleteDossierCode} - удалить досье" +
                                  $"\n  {searchByNameCode} - поиск по ФИО" +
                                  $"\n  {generateDossiersCode} - заполнить массивы данными" +
                                  $"\n  {exitMenuCode} - выход");

                Console.Write("\nВведите команду: ");

                char userInputCode = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                string userInput;
                switch (userInputCode)
                {
                    case addDossierCode:
                        Console.Write("Введите ФИО: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Введите должность: ");
                        string position = Console.ReadLine();
                        AddDossier(ref fullNames, ref positions, fullName, position);
                        Console.WriteLine($"Досье {fullName} - {position} было добавлено успешно");
                        break;
                    case showAllDossiersCode:
                        ShowDossiers(fullNames, positions, dossiersPositionLeft, dossiersPositionTop);
                        break;
                    case deleteDossierCode:
                        ShowDossiers(fullNames, positions, dossiersPositionLeft, dossiersPositionTop);
                        Console.Write("Введите номер досье для удаления: ");
                        userInput = Console.ReadLine();
                        if (IsDossierExists(userInput, out int dossierPosition, fullNames))
                        {
                            DeleteDossier(ref fullNames, ref positions, dossierPosition);
                            Console.WriteLine($"Досье под номером {dossierPosition} удалено успешно");
                        }
                        else
                        {
                            Console.WriteLine($"Нет досье под номером: {userInput}");
                        }
                        break;
                    case searchByNameCode:
                        Console.Write("Введите ФИО: ");
                        userInput = Console.ReadLine();
                        SearchDossiersByFullName(ref fullNames, ref positions, userInput);
                        break;
                    case generateDossiersCode:
                        GenerateDossiersData(ref fullNames, ref positions);
                        Console.WriteLine("Заготовленные данные были успешно добавлены");
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

        static bool IsDossierExists(string userInput, out int dossierNumber, string[] dossierArray)
        {
            dossierNumber = Int32.MinValue;
            return int.TryParse(userInput, out dossierNumber) && 
                   dossierNumber >= 1 && 
                   dossierNumber <= dossierArray.Length;
        }

        static void AddElementToArray(ref string[] array, string newElement)
        {
            string[] tempArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[^1] = newElement;
            array = tempArray;
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

        static void AddDossier(ref string[] fullNames, ref string[] positions,
            string fullName, string position)
        {
            AddElementToArray(ref fullNames, fullName);
            AddElementToArray(ref positions, position);
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] positions, int dossierPosition)
        {
            DeleteElementFromArray(ref fullNames, dossierPosition - 1);
            DeleteElementFromArray(ref positions, dossierPosition - 1);
        }

        static void ShowDossiers(string[] fullNames, string[] positions,
            int consolePositionLeft, int consolePositionTop)
        {
            (int cursorPositionLeft, int cursorPositionTop) = Console.GetCursorPosition();
            Console.SetCursorPosition(consolePositionLeft, consolePositionTop);
            
            Console.WriteLine("Досье: ");
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.SetCursorPosition(consolePositionLeft, consolePositionTop + i + 1);
                Console.Write($"  {i + 1}) {fullNames[i]} - {positions[i]}");
            }
            
            Console.SetCursorPosition(cursorPositionLeft, cursorPositionTop);
        }

        static void SearchDossiersByFullName(ref string[] fullNames, ref string[] positions, string userInput)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                if (fullNames[i].Contains(userInput))
                {
                    Console.WriteLine($"  {fullNames[i]} - {positions[i]}");
                }
            }
        }

        static void GenerateDossiersData(ref string[] fullNames, ref string[] positions)
        {
            AddDossier(ref fullNames, ref positions, "Иванов Иван Иванович", "Директор");
            AddDossier(ref fullNames, ref positions, "Иванов Сергей Иванович", "Заместитель директора");
            AddDossier(ref fullNames, ref positions, "Иванов Иван Сергеевич", "Заведующий складом");
            AddDossier(ref fullNames, ref positions, "Иванов Сергей Сергеевич", "Охранник");
        }
    }
}