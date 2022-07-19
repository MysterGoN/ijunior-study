using System;
using System.Collections.Generic;

namespace _06_OOP_07_PassengerTrainConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainBureau trainBureau = new TrainBureau(isOpen: true);
            trainBureau.Work();
        }
    }

    class RailwayCarriage
    {
        private const int MinPassengerCapacity = 10;
        private const int MaxPassengerCapacity = 30;

        private int _passengerCapacity;
        private int _passengers;

        public RailwayCarriage(Random random)
        {
            _passengerCapacity = random.Next(MinPassengerCapacity, MaxPassengerCapacity + 1);
            _passengers = 0;
        }

        public int EmptySeats => _passengerCapacity - _passengers;

        public string Info => $"{{{_passengers}/{_passengerCapacity}}}";

        public bool TryPutPassengers(int passengers)
        {
            if (passengers > EmptySeats)
            {
                return false;
            }

            _passengers += passengers;
            return true;
        }
    }

    class Train
    {
        private List<RailwayCarriage> _railwayCarriages = new List<RailwayCarriage>();

        public void AddRailwayCarriage(RailwayCarriage railwayCarriage)
        {
            _railwayCarriages.Add(railwayCarriage);
        }

        public void Draw()
        {
            const int WheelsInnerDistance = 4;

            string railwayCarriageRoofs = "";
            string railwayCarriageBodies = "";
            string railwayCarriageWheels = "";

            foreach (RailwayCarriage railwayCarriage in _railwayCarriages)
            {
                int railwayCarriageInfoLength = railwayCarriage.Info.Length;
                int wheelsEmptySize = railwayCarriageInfoLength - WheelsInnerDistance;

                railwayCarriageRoofs += $" __{new string('_', railwayCarriageInfoLength)}__";
                railwayCarriageBodies += $"-|_{railwayCarriage.Info}_|";
                railwayCarriageWheels += $"  o o{new string(' ', wheelsEmptySize)}o o ";
            }

            Console.WriteLine(
                $"\n    ooOOOO" +
                $"\n   oo      _____" +
                $"\n  _I__n_n__||_||{railwayCarriageRoofs}" +
                $"\n>(_________|_7_|{railwayCarriageBodies}<|" +
                $"\n /o ()() ()() o {railwayCarriageWheels}"
            );
        }
    }

    class TrainRide
    {
        private string _fromDirection;
        private string _toDirection;
        private Train _train;

        public TrainRide(string fromDirection, string toDirection, Train train)
        {
            _fromDirection = fromDirection;
            _toDirection = toDirection;
            _train = train;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Поезд следует из {_fromDirection} в {_toDirection}");
            _train.Draw();
        }
    }

    class TrainBureau
    {
        private const char CodeCreateTrainRide = '1';
        private const char CodeFinishWork = '0';

        private const int MinTrainRidePassengersCount = 50;
        private const int MaxTrainRidePassengersCount = 200;

        private Random _random = new Random();
        private bool _isOpen;
        private TrainRide _trainRide;

        public TrainBureau(bool isOpen)
        {
            _isOpen = isOpen;
        }

        public void Work()
        {
            if (!_isOpen)
            {
                Console.WriteLine("Бюро сейчас не работает, зайдите позже;");
            }

            while (_isOpen)
            {
                Console.Clear();
                ShowCurrentTrainRide();

                Console.WriteLine("\nРабота с консолью:" +
                                  $"\n  {CodeCreateTrainRide} - создать новую поездку на поезде" +
                                  $"\n  {CodeFinishWork} - завершить работу бюро");

                Console.Write("\nВведите команду: ");

                char userInputCode = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                switch (userInputCode)
                {
                    case CodeCreateTrainRide:
                        CreateTrainRide();
                        break;

                    case CodeFinishWork:
                        _isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }

                Console.Write("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        private void ShowCurrentTrainRide()
        {
            Console.WriteLine("Текущий рейс:");

            if (_trainRide != null)
            {
                _trainRide.ShowInfo();
            }
            else
            {
                Console.WriteLine(" У вас пока нет запущенных рейсов.");
            }
        }

        private void CreateTrainRide()
        {
            Console.Clear();
            Console.WriteLine("Вы попали в конструктор создания поездки на поезде, " +
                              "пожалуйста следуйте предложенным шагам:");
            Console.WriteLine("\n1. Необходимо задать направление:");
            CreateTrainDirection(out string fromDirection, out string toDirection);

            Console.WriteLine("\n2. Стартует продажа билетов на поездку:");
            int passengers = SellTickets();

            Console.WriteLine("\n3. Необходимо сконфигурировать поезд:");
            Train train = BuildTrain(passengers);

            Console.WriteLine("\n4. Для отправки поезда нажмите любую клавижу.1");
            Console.ReadKey();
            _trainRide = new TrainRide(fromDirection, toDirection, train);
        }

        private void CreateTrainDirection(out string fromDirection, out string toDirection)
        {
            Console.Write("Введите откуда отправится поезд: ");
            fromDirection = Console.ReadLine();

            Console.Write("Введите куда направится поезд: ");
            toDirection = Console.ReadLine();
        }

        private int SellTickets()
        {
            int passengers = _random.Next(MinTrainRidePassengersCount, MaxTrainRidePassengersCount + 1);
            Console.WriteLine($"Было продано {passengers} билетов.");

            return passengers;
        }

        private Train BuildTrain(int passengers)
        {
            Console.WriteLine("Происходит конфигурирование поезда, подождите немного;");
            Train train = new Train();
            int railwayCarriageCount = 0;
            int startingNumberOfPassengers = passengers;

            while (passengers > 0)
            {
                RailwayCarriage railwayCarriage = new RailwayCarriage(_random);
                int emptySeats = railwayCarriage.EmptySeats;
                int boardingPassengers = passengers > emptySeats ? emptySeats : passengers;

                if (railwayCarriage.TryPutPassengers(boardingPassengers))
                {
                    passengers -= boardingPassengers;
                }
                else
                {
                    Console.WriteLine("В поезд не поместится так много пассажиров");
                }

                train.AddRailwayCarriage(railwayCarriage);
                railwayCarriageCount++;
            }

            Console.WriteLine($"Был сформирован поезд состоящий из {railwayCarriageCount} вагонов " +
                              $"для {startingNumberOfPassengers} пассажиров.");

            return train;
        }
    }
}