using System;
using System.Collections.Generic;

namespace _06_OOP_03_GamersDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            const char addPlayerCode = '1';
            const char banPlayerCode = '2';
            const char unbanPlayerCode = '3';
            const char deletePlayerCode = '4';
            const char showAllPlayersCode = '5';
            const char generatePlayersCode = '6';
            const char exitMenuCode = '0';

            var database = new Database();

            var canExit = false;
            while (!canExit)
            {
                int playerId;
                Console.Clear();
                Console.WriteLine("Работа с консолью:" +
                                  $"\n  {addPlayerCode} - добавить пользователя" +
                                  $"\n  {banPlayerCode} - забанить пользователя" +
                                  $"\n  {unbanPlayerCode} - разбанить пользователя" +
                                  $"\n  {deletePlayerCode} - удалить пользователя по id" +
                                  $"\n  {showAllPlayersCode} - показать всех пользователей" +
                                  $"\n  {generatePlayersCode} - сгенерировать пользователей" +
                                  $"\n  {exitMenuCode} - выход");

                Console.Write("\nВведите команду: ");
                var userInputCode = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (userInputCode)
                {
                    case addPlayerCode:
                        Console.WriteLine("Добавление пользователя:");
                        Console.Write("  Введите имя пользователя: ");
                        var nickName = Console.ReadLine();
                        Console.Write("  Введите уровень: ");
                        if (TryParseNumber(out var level, "уровень"))
                        {
                            database.AddPlayer(new Player(nickName, level));
                        }
                        break;
                    case banPlayerCode:
                        Console.Write("Для бана пользователя введите его ID: ");
                        if (TryParseNumber(out playerId, "ID"))
                        {
                            database.BanPlayer(playerId);
                        }
                        break;
                    case unbanPlayerCode:
                        Console.Write("Для разбана пользователя введите его ID: ");
                        if (TryParseNumber(out playerId, "ID"))
                        {
                            database.UnbanPlayer(playerId);
                        }
                        break;
                    case deletePlayerCode:
                        Console.Write("Для удаления пользователя введите его ID: ");
                        if (TryParseNumber(out playerId, "ID"))
                        {
                            database.DeletePlayer(playerId);
                        }
                        break;
                    case showAllPlayersCode:
                        database.ShowAllPlayers();
                        break;
                    case generatePlayersCode:
                        database.GeneratePlayers();
                        break;
                    case exitMenuCode:
                        canExit = true;
                        break;
                }

                Console.Write("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        private static bool TryParseNumber(out int number, string name)
        {
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return true;
            }

            Console.WriteLine($"Вы ввели некорректное значение параметра {name}");
            return false;
        }
    }

    class Player
    {
        private static int _ids;
        public int Id { get; }
        public string NickName { get; }
        public int Level { get; }
        public bool IsBan { get; set; }

        public Player(string nickName, int level)
        {
            Id = _ids++;
            NickName = nickName;
            Level = level;
            IsBan = false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Информация об игроке {NickName}:" +
                              $"\n  Id: {Id}" +
                              $"\n  Уровень: {Level}" +
                              $"\n  Статус: {(IsBan ? "Забанен" : "Не забанен")}");
        }
    }

    class Database
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();
        
        public void AddPlayer(Player player)
        {
            _players.Add(player.Id, player);
            Console.WriteLine($"Игрок {player.NickName} успешно добавлен.");
        }

        public void DeletePlayer(int playerId)
        {
            if (_players.Remove(playerId, out var player))
            {
                Console.WriteLine($"Игрок {player.NickName} успешно удалён.");
            }
            else
            {
                Console.WriteLine($"Не удалось удалить игрока с Id={playerId}.");
            }
        }

        public void BanPlayer(int playerId)
        {
            if (_players.TryGetValue(playerId, out var player))
            {
                player.IsBan = true;
                Console.WriteLine($"Игрок {player.NickName} отправлен в бан.");
            }
            else
            {
                Console.WriteLine($"Не удалось забанить игрока с Id={playerId}.");
            }
        }

        public void UnbanPlayer(int playerId)
        {
            if (_players.TryGetValue(playerId, out var player))
            {
                player.IsBan = false;
                Console.WriteLine($"Игрок {player.NickName} восстановлен из бана.");
            }
            else
            {
                Console.WriteLine($"Не удалось разбанить игрока с Id={playerId}.");
            }
        }

        public void ShowAllPlayers()
        {
            foreach (var player in _players.Values)
            {
                player.ShowInfo();
            }
        }

        public void GeneratePlayers()
        {
            AddPlayer(new Player("Alex", 0));
            AddPlayer(new Player("Nick", 4));
            AddPlayer(new Player("Leo", 6));
            AddPlayer(new Player("Arnold", 3));
            AddPlayer(new Player("Duran", 10));
        }
    }
}