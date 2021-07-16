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
            bool canShowDossiers = false;
            int messagePositionLeft = 0, messagePositionTop = 10;
            int dossiersPositionLeft = 40, dossiersPositionTop = 0;
            string message = null;
            string userInput;

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
                if (IsMessageExists(message))
                {
                    DrawMessage(message, messagePositionLeft, messagePositionTop);
                    message = null;
                }

                if (canShowDossiers)
                {
                    ShowDossiers(fullNames, positions, dossiersPositionLeft, dossiersPositionTop);
                    canShowDossiers = false;
                }

                char userInputCode = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (userInputCode)
                {
                    case addDossierCode:
                        Console.Write("Введите ФИО: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Введите должность: ");
                        string position = Console.ReadLine();
                        AddDossier(ref fullNames, ref positions, fullName, position);
                        message = $"Было добавлено досье {fullName} - {position}";
                        break;
                    case showAllDossiersCode:
                        canShowDossiers = true;
                        break;
                    case deleteDossierCode:
                        ShowDossiers(fullNames, positions, dossiersPositionLeft, dossiersPositionTop);
                        Console.Write("Введите номер досье для удаления: ");
                        userInput = Console.ReadLine();
                        if (!IsDossierExists(userInput, out int dossierPosition, fullNames))
                        {
                            message = $"Нет досье под номером: {userInput}";
                            continue;
                        }
                        DeleteDossier(ref fullNames, ref positions, dossierPosition);
                        break;
                    case searchByNameCode:
                        Console.Write("Введите ФИО: ");
                        userInput = Console.ReadLine();
                        int[] dossierPositions = SearchDossiersByFullName(ref fullNames, userInput);
                        message = GenerateFoundDossiersMessage(ref fullNames, ref positions, dossierPositions);
                        break;
                    case generateDossiersCode:
                        GenerateDossiersData(ref fullNames, ref positions);
                        message = "В массивы были добавлены заготовленные данные";
                        break;
                    case exitMenuCode:
                        canExit = true;
                        break;
                    default:
                        message = $"Нет такого пункта меню!";
                        break;
                }
            }
        }

        static bool IsMessageExists(string message)
        {
            return message != null && message.Length > 0;
        }

        static bool IsDossierExists(string userInput, out int dossierNumber, string[] dossierArray)
        {
            dossierNumber = Int32.MinValue;
            return int.TryParse(userInput, out dossierNumber) && 
                   dossierNumber >= 1 && 
                   dossierNumber <= dossierArray.Length;
        }

        static void DrawMessage(string message, int positionLeft, int positionTop)
        {
            (int cursorPositionLeft, int cursorPositionTop) = Console.GetCursorPosition();
            Console.SetCursorPosition(positionLeft, positionTop);

            Console.WriteLine($"\n\nИнформация:\n  {message}");

            Console.SetCursorPosition(cursorPositionLeft, cursorPositionTop);
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
        
        static void AddElementToArray(ref int[] array, int newElement)
        {
            int[] tempArray = new int[array.Length + 1];
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

        static int[] SearchDossiersByFullName(ref string[] fullNames, string userInput)
        {
            int[] dossierPositions = new int[0];
            for (int i = 0; i < fullNames.Length; i++)
            {
                if (fullNames[i].Contains(userInput))
                {
                    AddElementToArray(ref dossierPositions, i);
                }
            }

            return dossierPositions;
        }

        static string GenerateFoundDossiersMessage(ref string[] fullNames, ref string[] positions, 
            int[] dossierPositions)
        {
            string message = "Найденные досье: ";
            foreach (int dossierPosition in dossierPositions)
            {
                message += $"\n    {fullNames[dossierPosition]} - {positions[dossierPosition]}";
            }

            return message;
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