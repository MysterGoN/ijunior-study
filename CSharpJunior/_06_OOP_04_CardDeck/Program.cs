using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_OOP_04_CardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random random = new Random();
            List<Player> players = new List<Player>()
            {
                new Player("Николай"),
                new Player("Василий"),
                new Player("Герман"),
                new Player("Инокентий")
            };
            Deck deck = new Deck();

            Console.WriteLine("Вы сидите за столом, с вами еще 3 игрока, в центре стола крупье, " +
                              "он достаёт соврешенно новую колоду, показывает вам и начинает тасовать.");

            deck.Shuffle(random);

            Console.WriteLine("После чего крупье начинает раздавать карты:");
            int numberOfCardsToDeal = Player.HandSize;

            while (numberOfCardsToDeal > 0)
            {
                numberOfCardsToDeal--;

                foreach (Player player in players)
                {
                    player.TakeCard(deck);
                }
            }

            Console.WriteLine("Все карты были разданы. Вы решаетесь посмотреть какие у вас карты.");
            players[0].ShowHand();
        }
    }

    enum CardSuit
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades
    }

    enum CardValue
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Quin,
        King,
    }

    class Card
    {
        public CardValue Value { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        private char SuitSymbol
        {
            get
            {
                char suitSymbol;

                switch (Suit)
                {
                    case CardSuit.Diamonds:
                        suitSymbol = '♦';
                        break;

                    case CardSuit.Clubs:
                        suitSymbol = '♣';
                        break;

                    case CardSuit.Hearts:
                        suitSymbol = '♥';
                        break;

                    case CardSuit.Spades:
                        suitSymbol = '♠';
                        break;

                    default:
                        throw new InvalidOperationException();
                }

                return suitSymbol;
            }
        }

        private string ValueSymbol
        {
            get
            {
                string valueSymbol;

                switch (Value)
                {
                    case CardValue.Ace:
                    case CardValue.Jack:
                    case CardValue.Quin:
                    case CardValue.King:
                        valueSymbol = $"{Value.ToString()[0]}";
                        break;

                    default:
                        valueSymbol = $"{(int) Value}";
                        break;
                }

                return valueSymbol;
            }
        }

        public string Info
        {
            get { return $"{ValueSymbol}{SuitSymbol}"; }
        }
    }

    class Deck
    {
        private const int DeckSize = 52;
        private Stack<Card> _cards = new Stack<Card>(DeckSize);

        public Deck()
        {
            foreach (CardSuit suit in (CardSuit[]) Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in (CardValue[]) Enum.GetValues(typeof(CardValue)))
                {
                    _cards.Push(new Card(suit, value));
                }
            }
        }

        public void Shuffle(Random random)
        {
            List<Card> cards = _cards.ToList();
            _cards.Clear();
            int cardNumber = cards.Count;

            while (cardNumber > 1)
            {
                cardNumber--;
                int cardNumberToSwitch = random.Next(cardNumber + 1);
                (cards[cardNumberToSwitch], cards[cardNumber]) = (cards[cardNumber], cards[cardNumberToSwitch]);
            }

            foreach (Card card in cards)
            {
                _cards.Push(card);
            }
        }

        public Card Pop()
        {
            return _cards.Pop();
        }
    }

    class Player
    {
        public const int HandSize = 7;

        private List<Card> _hand = new List<Card>(HandSize);
        private string _name;

        public Player(string name)
        {
            _name = name;
        }

        public void TakeCard(Deck deck)
        {
            _hand.Add(deck.Pop());
            Console.WriteLine($"{_name} - взял карту, теперь у него в руке {_hand.Count}");
        }

        public void ShowHand()
        {
            Console.WriteLine($"[{String.Join(", ", _hand.Select(card => card.Info).ToArray())}]");
        }
    }
}