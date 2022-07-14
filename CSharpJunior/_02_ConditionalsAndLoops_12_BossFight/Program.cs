using System;

namespace _02_ConditionalsAndLoops_08_BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            const int lightningBoltAction = 1;
            const int staticShieldAction = 2;
            const int staticShieldExplosionAction = 3;
            const int electrificationAction = 4;
            const int spellsDetailsAction = 0;
            const string lightningBoltActionName = "LightningBolt";
            const string staticShieldActionName = "StaticShield";
            const string staticShieldExplosionActionName = "StaticShieldExplosion";
            const string electrificationActionName = "Electrification";
            const string spellsDetailsActionName = "SpellDetails";
            const int bossHealthMin = 80;
            const int bossHealthMax = 100;
            const int bossDamageMin = 5;
            const int bossDamageMax = 10;
            const int playersHealsMin = 40;
            const int playersHealsMax = 50;
            const int lightningBoltDamageMin = 1;
            const int lightningBoltDamageMax = 7;
            const int staticShieldDuration = 3;
            const int staticShieldAbsorption = 15;
            const float staticShieldAbsorptionCoefficient = 2.5f;
            const int staticShieldDamage = 4;
            const int electrificationDuration = 5;
            const float electrificationCoefficientDefault = 1;
            const float electrificationCoefficientActive = 1.5f;
            const int bossDamageDelta = 3;
            const string noSuchActionMessage = "Нет такого действия";
            const string selectAction = "Выберите действие: ";
            int cursorActionPositionX = selectAction.Length;
            int cursorActionPositionY = 7;
            float bossHealth;
            int bossAttackDamage;
            float playersHealth;
            float staticShieldHealth = 0;
            float electrificationCoefficient;
            char actionKey;
            int action;
            float damage;
            float bossDamage;
            string battleInfo;
            string message = null;
            bool isStaticShieldActive = false;
            uint staticShieldActivity = 0;
            bool isElectrificationActive = false;
            uint electrificationActivity = 0;

            Random rand = new Random();
            bossHealth = rand.Next(bossHealthMin, bossHealthMax + 1);
            bossAttackDamage = rand.Next(bossDamageMin, bossDamageMax + 1);
            playersHealth = rand.Next(playersHealsMin, playersHealsMax + 1);
            electrificationCoefficient = electrificationCoefficientDefault;
            
            while (true)
            {
                if (playersHealth <= 0 || bossHealth <= 0)
                {
                    break;
                }

                battleInfo = "";
                if (isStaticShieldActive)
                {
                    staticShieldActivity--;
                    if (staticShieldActivity <= 0)
                    {
                        isStaticShieldActive = false;
                        battleInfo += $"\n\t- Закончился эффект {staticShieldActionName}";
                    }
                }

                if (isElectrificationActive)
                {
                    electrificationActivity--;
                    if (electrificationActivity <= 0)
                    {
                        isElectrificationActive = false;
                        electrificationCoefficient = electrificationCoefficientDefault;
                        battleInfo += $"\n\t- Закончился эффект {electrificationActionName}";
                    }

                }
                
                Console.Clear();
                Console.WriteLine("Доступные действия:" +
                                  $"\n\t{lightningBoltAction}) {lightningBoltActionName} " +
                                  $"- удар молнии" +
                                  $"\n\t{staticShieldAction}) {staticShieldActionName} " +
                                  $"- статический щит" +
                                  $"\n\t{staticShieldExplosionAction}) {staticShieldExplosionActionName} " +
                                  $"- взрыв статического щита" +
                                  $"\n\t{electrificationAction}) {electrificationActionName} " +
                                  $"- наэлектризовать врага" +
                                  $"\n\t{spellsDetailsAction}) {spellsDetailsActionName} " +
                                  $"- детальное описание всех способностей\n");
                Console.WriteLine($"{selectAction}\n");
                if (message != null && message.Length > 0)
                {
                    Console.WriteLine($"Информация: {message}");
                    message = null;
                }
                Console.SetCursorPosition(cursorActionPositionX, cursorActionPositionY);
                
                actionKey = Console.ReadKey().KeyChar;
                if (!int.TryParse(actionKey.ToString(), out action))
                {
                    message = noSuchActionMessage;
                    continue;
                }

                switch (action)
                {
                    case lightningBoltAction:
                        damage = rand.Next(lightningBoltDamageMin, lightningBoltDamageMax + 1);
                        bossHealth -= damage * electrificationCoefficient;
                        battleInfo += $"\n\t- Вы нанесли противнику {damage} урона. У него осталось {bossHealth} хп.";
                        break;
                    case staticShieldAction:
                        isStaticShieldActive = true;
                        staticShieldActivity = staticShieldDuration;
                        staticShieldHealth = staticShieldAbsorption;
                        battleInfo += $"\n\t- Вы наложили на себя {staticShieldActionName}. " +
                                      $"Он будет действовать в течении {staticShieldActivity} ходов.";
                        break;
                    case staticShieldExplosionAction:
                        if (!isStaticShieldActive || staticShieldHealth == 0)
                        {
                            message = $"У вас неактивен {staticShieldActionName}. Выберите другое действие!";
                            continue;
                        }

                        damage = staticShieldHealth * staticShieldAbsorptionCoefficient;
                        bossHealth -= damage * electrificationCoefficient;
                        battleInfo += $"\n\t- Вы взорвали {staticShieldActionName} благодаря чему " +
                                      $"нанесли противнику {damage} урона. У него осталось {bossHealth} хп.";

                        staticShieldActivity = 0;
                        isStaticShieldActive = false;
                        break;
                    case electrificationAction:
                        isElectrificationActive = true;
                        electrificationActivity = electrificationDuration;
                        electrificationCoefficient = electrificationCoefficientActive;
                        battleInfo += $"\n\t- Вы наложили на противника статус {electrificationActionName}. " +
                                      $"Он будет действовать в течении {electrificationActivity} ходов.";
                        break;
                    case spellsDetailsAction:
                        message = "Доступные заклинания" +
                                  $"\n\t{lightningBoltActionName} - наносит противнику урон в размере " +
                                  $"{lightningBoltDamageMin}-{lightningBoltDamageMax}. " +
                                  $"На эту способность действует {electrificationActionName}." +
                                  $"\n\t{staticShieldActionName} - накладывает на себя статический щит, " +
                                  $"действующий в течении {staticShieldDuration} ходов," +
                                  $"который поглощает {staticShieldAbsorption} урона. " +
                                  $"При нанесении урона игроку, противник получает {staticShieldDamage} урона. " +
                                  $"На эту способность действует {electrificationActionName}." +
                                  $"\n\t{staticShieldExplosionActionName} - взрыв {staticShieldActionName}. " +
                                  $"Нельзя использовать если на вас не наложен {staticShieldActionName}. " +
                                  $"Наносит урон по следующей формуле " +
                                  $"\"текущая ёмкость щита\" * \"{staticShieldAbsorptionCoefficient}\". " +
                                  $"На эту способность действует {electrificationActionName}." +
                                  $"\n\t{electrificationActionName} - накладывает дебаф на противника. " +
                                  $"Весь входящий урон увеличивается на {electrificationCoefficientActive}.";
                        continue;
                    default:
                        message = noSuchActionMessage;
                        continue;
                }

                if (bossHealth <= 0)
                {
                    break;
                }

                bossDamage = rand.Next(bossAttackDamage - bossDamageDelta, bossAttackDamage + bossDamageDelta);
                if (isStaticShieldActive)
                {
                    damage = staticShieldDamage * electrificationCoefficient;
                    bossHealth -= damage;
                    battleInfo += $"\n\t- На вас наложен {staticShieldActionName}, босс получил {damage} урона. " +
                                  $"У него осталось {bossHealth} хп.";
                    if (staticShieldHealth - bossDamage > 0)
                    {
                        staticShieldHealth -= bossDamage;
                        battleInfo += $"\n\t- Вам нанесли {bossDamage} урона но он был поглощён {staticShieldActionName} " +
                                      $"у него осталось {staticShieldHealth} хп.";
                    }
                    else
                    {
                        bossDamage -= staticShieldHealth;
                        playersHealth -= bossDamage;
                        battleInfo += $"\n\t- Ваш {staticShieldActionName} был разрушен и вы получили {bossDamage} урона. " +
                                      $"У вас осталось {playersHealth} хп.";
                    }
                }
                else
                {
                    playersHealth -= bossDamage;
                    battleInfo += $"\n\t- Вам нанесли {bossDamage} урона. У вас осталось {playersHealth} хп.";
                }

                message = battleInfo;
            }
            
            Console.Clear();
            if (playersHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Хоть вы и погибли, вы смогли достичь своей цели и Владыка тьмы был побеждён!");
            } else if (playersHealth <= 0)
            {
                Console.WriteLine("К сожаления вы не смогли выжить! Владыка тьмы захватил этот мир!");
            } else if (bossHealth <= 0)
            {
                Console.WriteLine("Вам удалось победить Владыку тьмы и при этом остаться в живых!");
            }
        }
    }
}