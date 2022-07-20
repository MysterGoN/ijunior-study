using System;
using System.Collections.Generic;

namespace _06_OOP_08_GladiatorFights
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();

            Console.Clear();

            Console.WriteLine("\nНеобходимо выбрать 2х бойцов для проведения битвы: ");
            arena.ChooseFighters();

            Console.WriteLine("\nПриготовтесь битва начинается!");
            arena.DoFight();

            Console.WriteLine("\nЭто было невероятно! Давайте же узнаем с каким результатом все закончилось!");
            arena.ShowWinner();
        }
    }

    abstract class Fighter
    {
        protected const int MinHealth = 0;

        protected Random Randomizer;
        protected int MaxHealth;
        protected int Damage;

        protected Fighter(string name, int health, int damage)
        {
            Randomizer = new Random();

            Name = name;
            Health = health;
            MaxHealth = health;
            Damage = damage;
        }

        public int Health { get; protected set; }

        public string Name { get; protected set; }

        public bool IsAlive => Health > MinHealth;

        public string Info => $"{Name} (ХП: {Health}/{MaxHealth}) - {(IsAlive ? "Живой" : "Мертвый")}";

        public abstract int Attack();

        public virtual void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                Console.WriteLine($"{Name} не получает урона.");
                return;
            }

            Health -= damage;

            Console.WriteLine($"{Name} получает {damage}. Остается {Health} ХП.");
        }
    }

    class Knight : Fighter
    {
        private int _armor;

        public Knight(string name, int health, int damage, int armor) : base(name, health, damage)
        {
            _armor = armor;
        }

        public override int Attack()
        {
            Console.WriteLine($"{Name} атакует свои мечом и пытается нанести {Damage} урона.");

            return Damage;
        }

        public override void TakeDamage(int damage)
        {
            if (_armor > damage || damage <= 0)
            {
                Console.WriteLine($"{Name} не получает урона.");
                return;
            }

            int takeDamage = damage - _armor;
            Health -= takeDamage;

            Console.WriteLine($"{Name} поглощает {_armor} урона и получает {takeDamage}. " +
                              $"Остается {Health} ХП");
        }
    }

    class Barbarian : Fighter
    {
        private const int MinRage = 1;
        private const int MaxRage = 100;
        private const int RageIncreaseValue = 20;
        private const int RageDecreaseValue = 5;
        private const float NormalHitRatio = 1f;
        private const float CriticalHitRatio = 2f;

        private int _rage;

        public Barbarian(string name, int health, int damage) : base(name, health, damage)
        {
            _rage = 0;
        }

        public override int Attack()
        {
            bool isCriticalHit = Randomizer.Next(MaxRage + 1) >= MaxRage - _rage;
            int damage = (int) (Damage * (isCriticalHit ? CriticalHitRatio : NormalHitRatio));

            string attackMessage = isCriticalHit
                ? "впадает в ярость, со всей силы рубит противника"
                : "замахивается топором";

            Console.WriteLine($"{Name} {attackMessage} и пытается нанести {damage} урона.");

            IncreaseRage();

            return damage;
        }

        public override void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                Console.WriteLine($"{Name} не получает урона.");
                return;
            }

            Health -= damage;
            DecreaseRage();

            Console.WriteLine($"{Name} получает {damage}. Остается {Health} ХП.");
        }

        private void IncreaseRage()
        {
            if (_rage + RageIncreaseValue <= MaxRage)
            {
                _rage += RageIncreaseValue;
            }
            else
            {
                _rage = MaxRage;
            }
        }

        private void DecreaseRage()
        {
            if (_rage - RageDecreaseValue >= MinRage)
            {
                _rage -= RageDecreaseValue;
            }
            else
            {
                _rage = MinRage;
            }
        }
    }

    class Mage : Fighter
    {
        private const int FireBallDamage = 50;
        private const int FireBallManaCost = 20;
        private const int ManaRestorationRounds = 2;

        private int _maxMana;
        private int _mana;

        private int _manaRestorationRoundsLeft;

        public Mage(string name, int health, int damage, int mana) : base(name, health, damage)
        {
            _mana = mana;
            _maxMana = mana;
        }

        public override int Attack()
        {
            int damage;

            if (HaveEnoughManaToCast(FireBallManaCost))
            {
                damage = CastFireBall();
            }
            else
            {
                CastManaRestoration();
                damage = 0;
            }

            return damage;
        }

        private bool HaveEnoughManaToCast(int manaCost)
        {
            return _mana >= manaCost;
        }

        private int CastFireBall()
        {
            Console.WriteLine($"{Name} кастует фаебол и пытается нанести {FireBallDamage}");
            _mana -= FireBallManaCost;

            return FireBallDamage;
        }

        private void CastManaRestoration()
        {
            if (_manaRestorationRoundsLeft <= 0)
            {
                _manaRestorationRoundsLeft = ManaRestorationRounds;
            }

            _manaRestorationRoundsLeft--;

            if (_manaRestorationRoundsLeft == 0)
            {
                _mana = _maxMana;
                Console.WriteLine($"{Name} восстановил всю свою ману!");
            }
            else
            {
                Console.WriteLine($"{Name} пытается воостановить ману, " +
                                  $"осталось {_manaRestorationRoundsLeft} ходов.");
            }
        }
    }

    class Rogue : Fighter
    {
        private const int MaxStamina = 100;
        private const float DodgeChance = 0.3f;
        private const int DodgeStaminaCost = 50;

        private int _stamina;

        public Rogue(string name, int health, int damage) : base(name, health, damage)
        {
            _stamina = MaxStamina;
        }

        public override int Attack()
        {
            Console.WriteLine($"{Name} быстро атакует своим кинжалом и пытается нанести {Damage} урона.");

            return Damage;
        }

        public override void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                Console.WriteLine($"{Name} не получает урона.");
                return;
            }

            if (TryDodge()) return;

            Health -= damage;
            Console.WriteLine($"{Name} получает {damage}. Остается {Health} ХП.");
        }

        private bool TryDodge()
        {
            if (Randomizer.NextDouble() <= DodgeChance)
            {
                if (_stamina >= DodgeStaminaCost)
                {
                    Console.WriteLine($"{Name} успешно уклонился от удара и не получил урона.");
                    _stamina -= DodgeStaminaCost;
                    return true;
                }

                Console.WriteLine($"{Name} не хватило сил чтобы уклониться");
                return false;
            }

            Console.WriteLine($"{Name} не удалось уклониться.");
            return false;
        }
    }

    class Monk : Fighter
    {
        private const float DamageAbsorptionPercentage = 0.2f;
        private const int RegenerationPower = 10;

        public Monk(string name, int health, int damage) : base(name, health, damage)
        {
        }

        public override int Attack()
        {
            Console.WriteLine($"{Name} ударяет своего противника с ноги и пытается нанести {Damage} урона.");

            return Damage;
        }

        public override void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }

            int absorbedDamage = (int) (damage * DamageAbsorptionPercentage);
            int tookDamage = damage - absorbedDamage;
            Health -= tookDamage;

            Console.WriteLine($"{Name} поглощает {absorbedDamage} урона и получает {tookDamage}. " +
                              $"Остается {Health} ХП.");
            Regenerate();
        }

        private void Regenerate()
        {
            if (Health + RegenerationPower > MaxHealth)
            {
                Health = MaxHealth;
            }
            else
            {
                Health += RegenerationPower;
            }

            Console.WriteLine($"{Name} восстановил ХП. Теперь {Health} ХП.");
        }
    }

    class Arena
    {
        private List<Fighter> _fighters;
        private Fighter _leftFighter;
        private Fighter _rightFighter;

        public Arena()
        {
            _fighters = new List<Fighter>()
            {
                new Knight("Рыцарь", 150, 20, 10),
                new Barbarian("Варвар", 100, 30),
                new Mage("Маг", 50, 5, 60),
                new Rogue("Разбойник", 75, 40),
                new Monk("Монах", 100, 20)
            };
        }

        public void ShowFighters()
        {
            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.WriteLine($"{i}. {_fighters[i].Info}");
            }
        }

        private void ChooseFighter(string message, ref Fighter fighter)
        {
            Console.Write(message);

            bool isFighterChoose = false;
            while (!isFighterChoose)
            {
                if (int.TryParse(Console.ReadLine(), out int fighterNumber))
                {
                    if (fighterNumber >= 0 & fighterNumber < _fighters.Count)
                    {
                        fighter = _fighters[fighterNumber];
                        _fighters.RemoveAt(fighterNumber);

                        isFighterChoose = true;
                    }
                    else
                    {
                        Console.WriteLine("Такого бойца не существует, попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректное значение, попробуйте снова");
                }
            }
        }

        public void ChooseFighters()
        {
            ShowFighters();
            ChooseFighter("Выберите левого бойца: ", ref _leftFighter);
            ShowFighters();
            ChooseFighter("Выберите правого бойца: ", ref _rightFighter);
        }

        public void DoFight()
        {
            if (_leftFighter == null || _rightFighter == null)
            {
                Console.WriteLine("Вы не выбрали бойцов");
                return;
            }

            Console.WriteLine($"Начинается бой между {_leftFighter.Name} и {_rightFighter.Name}:");

            while (_leftFighter.IsAlive & _rightFighter.IsAlive)
            {
                int leftFighterDamage = _leftFighter.Attack();
                _rightFighter.TakeDamage(leftFighterDamage);

                int rightFighterDamage = _rightFighter.Attack();
                _leftFighter.TakeDamage(rightFighterDamage);
            }

            Console.WriteLine("Бой завершился!");
        }

        public void ShowWinner()
        {
            if (_leftFighter == null || _rightFighter == null || _leftFighter.IsAlive & _rightFighter.IsAlive)
            {
                Console.WriteLine("Боя среди бойцов не было.");
            }
            else if (_leftFighter.IsAlive)
            {
                Console.WriteLine($"В тяжелейшей борьбе победил {_leftFighter.Name}!");
            }
            else if (_rightFighter.IsAlive)
            {
                Console.WriteLine($"Используя невероятные умения победил {_rightFighter.Name}!");
            }
            else
            {
                Console.WriteLine("Оба бойца убили друг друга!");
            }
        }
    }
}