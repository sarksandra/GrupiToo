using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace DarknessKingdom
{
    class Program
    {
        // Mängu oleku muutujad
        static bool gameOver = false;
        static int health = 100;
        static int gold = 0;
        static List<string> inventory = new List<string>();
        static string playerName = "";
        static int daysSurvived = 0;
        static bool hasTorch = false;
        static bool hasSword = false;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== PIMEDUSE KUNINGRIIK ===");
            Console.ResetColor();
            Console.WriteLine("\nTervitus, võõras! Sa oled jõudnud needuse alla võetud maale.");

            GetPlayerName();
            Introduction();

            while (!gameOver)
            {
                DayCycle();
                if (!gameOver) CheckRandomEvent();
                if (!gameOver) Explore();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMÄNG LÄBI");
            Console.ResetColor();
            Console.WriteLine($"\nSa elasid {daysSurvived} päeva Pimeduse Kuningriigis.");
            Console.WriteLine("Vajuta suvalist klahvi, et väljuda...");
            Console.ReadKey();
        }

        static void GetPlayerName()
        {
            Console.Write("\nKuidas sa ennast kutsud? kas: rüütel, metsaingel, nooleprintsess, goblin, veejumal, metsahaldjas, külaelanik ");
            playerName = Console.ReadLine();
            Console.WriteLine($"\nTere tulemast, {playerName}! Hoia oma mõistust terve ja relvad teravad.");
        }

        static void Introduction()
        {
            TypeText("\nPäevad on muutunud lühikeseks. Ööd kestavad nüüd 20 tundi ja vaid 4 tundi on päikesevalgust.");
            TypeText("Kuningas Lorian, kes valitses seda maad targalt, on kadunud. Temast pole kuulda 100 päeva.");
            TypeText("Kuningriik on langemas korruptsiooni ja pimeduse kätte. Kummitused ja koletised roomavad öösiti tänavatel.");
            TypeText("Sinu eesmärk on ellu jääda, koguda varusid ja avastada, mis juhtus kuningas Lorianiga.\n");
        }

        static void TypeText(string text, int speed = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        static void DayCycle()
        {
            daysSurvived++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n=== PÄEV {daysSurvived} ===");
            Console.ResetColor();

            // Öö efekt
            if (daysSurvived % 3 == 0)
            {
                TypeText("\nÖö on eriti pime ja külm...", 50);
                health -= 10;
                Console.WriteLine("Kaotad 10 elupunkti külma tõttu.");
                CheckHealth();
            }
        }

        static void CheckRandomEvent()
        {
            Random rand = new Random();
            int eventChance = rand.Next(1, 101);

            if (eventChance > 70) // 30% võimalus
            {
                int eventType = rand.Next(1, 4);

                switch (eventType)
                {
                    case 1:
                        TypeText("\nLeiad vana, hüljatud maja. Kas sa tahad seda uurida? (jah/ei)");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "jah")
                        {
                            if (rand.Next(1, 101) > 50)
                            {
                                int foundGold = rand.Next(5, 26);
                                gold += foundGold;
                                Console.WriteLine($"Leidsid {foundGold} kuldmünti!");
                            }
                            else
                            {
                                Console.WriteLine("Kummitus ründab sind!");
                                health -= 20;
                                CheckHealth();
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nKohtad kaupmeest tee peal!");
                        TradeWithMerchant();
                        break;
                    case 3:
                        Console.WriteLine("\nLeiad haavatud reisija. Ta palub abi.");
                        HelpTraveler();
                        break;
                }
            }
        }

        static void TradeWithMerchant()
        {
            Console.WriteLine("Kaupmees pakub:");
            Console.WriteLine("1. Mõõk (20 kulda) - suurendab võitluse võimet");
            Console.WriteLine("2. Tõrvik (10 kulda) - kaitseb öösel");
            Console.WriteLine("3. Ravim (15 kulda) - taastab 30 elupunkti");
            Console.WriteLine("4. Lahku (ei osta midagi)");

            Console.Write("\nSinu valik (1-4): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (gold >= 20)
                    {
                        gold -= 20;
                        hasSword = true;
                        Console.WriteLine("Ostsid mõõga! Saad nüüd paremini vaenlasi tappa.");
                    }
                    else
                    {
                        Console.WriteLine("Sul pole piisavalt kulda!");
                    }
                    break;
                case "2":
                    if (gold >= 10)
                    {
                        gold -= 10;
                        hasTorch = true;
                        Console.WriteLine("Ostsid tõrviku! Öösel on nüüd turvalisem.");
                    }
                    else
                    {
                        Console.WriteLine("Sul pole piisavalt kulda!");
                    }
                    break;
                case "3":
                    if (gold >= 15)
                    {
                        gold -= 15;
                        health = Math.Min(100, health + 30);
                        Console.WriteLine("Jõid ravimit! Elud taastusid 30 võrra.");
                    }
                    else
                    {
                        Console.WriteLine("Sul pole piisavalt kulda!");
                    }
                    break;
                case "4":
                    Console.WriteLine("Lahkud kaupmehest ilma ostmata.");
                    break;
                default:
                    Console.WriteLine("Kehtetu valik!");
                    break;
            }
        }

        static void HelpTraveler()
        {
            Console.WriteLine("1. Aita teda (kulutab 1 tund)");
            Console.WriteLine("2. Jäta ta oma saatusele");
            Console.Write("\nValik: ");
            string input = Console.ReadLine();

            Random rand = new Random();
            if (input == "1")
            {
                if (rand.Next(1, 101) > 30) // 70% võimalus head tulemust
                {
                    int reward = rand.Next(5, 16);
                    gold += reward;
                    Console.WriteLine($"Reisija tänab sind ja annab sulle {reward} kulda!");
                }
                else
                {
                    Console.WriteLine("Reisija oli petis! Ta rööbib su ja jookseb minema.");
                    gold = Math.Max(0, gold - 10);
                }
            }
            else
            {
                Console.WriteLine("Jätad reisija oma saatusele. Ta vaatab sulle järel nukralt.");
            }
        }

        static void Explore()
        {
            Console.WriteLine("\nKuhu soovid minna?");
            Console.WriteLine("1. Külla (ohutum, vähem võimalusi varanduste leidmiseks)");
            Console.WriteLine("2. Metsa (ohtlikum, kuid rohkem võimalusi leida varandusi)");
            Console.WriteLine("3. Kuningalossi varemete (väga ohtlik, kuid võib-olla väärt)");
            Console.WriteLine("4. Puhata (taastab 20 elupunkti, kuid kulutab aega)");

            Console.Write("\nValik: ");
            string input = Console.ReadLine();

            Random rand = new Random();
            switch (input)
            {
                case "1":
                    Console.WriteLine("\nLähed külla.");
                    if (rand.Next(1, 101) > 80) // 20% võimalus
                    {
                        Console.WriteLine("Küla on rüüstatud! Leiad vaid hüljatud hooneid.");
                    }
                    else
                    {
                        Console.WriteLine("Külas on rahulik. Saad puhata ja osta varusid.");
                        health = Math.Min(100, health + 10);
                    }
                    break;
                case "2":
                    Console.WriteLine("\nLähed metsa.");
                    ForestAdventure();
                    break;
                case "3":
                    Console.WriteLine("\nLähed kuningalossi varemetesse.");
                    PalaceAdventure();
                    break;
                case "4":
                    Console.WriteLine("\nPuhkad hetke.");
                    health = Math.Min(100, health + 20);
                    Console.WriteLine("Elud taastusid 20 võrra.");
                    break;
                default:
                    Console.WriteLine("Kehtetu valik! Kaotad aega.");
                    break;
            }
        }

        static void ForestAdventure()
        {
            Random rand = new Random();
            int outcome = rand.Next(1, 101);

            if (outcome < 40) // 40% võimalus
            {
                int foundGold = rand.Next(1, 11);
                gold += foundGold;
                Console.WriteLine($"Leidsid {foundGold} kuldmünti metsast!");
            }
            else if (outcome < 70) // 30% võimalus
            {
                Console.WriteLine("Ei leia midagi huvitavat.");
            }
            else if (outcome < 90) // 20% võimalus
            {
                Console.WriteLine("Rünnatakse metsalise poolt!");
                Combat("metsaline");
            }
            else // 10% võimalus
            {
                Console.WriteLine("Leiad vana müüdileti!");
                inventory.Add("müstiline amulett");
                Console.WriteLine("Leidsid müstilise amuleti!");
            }
        }

        static void PalaceAdventure()
        {
            Random rand = new Random();
            int outcome = rand.Next(1, 101);

            if (outcome < 30) // 30% võimalus
            {
                Console.WriteLine("Leiad kuningalossi varakambri!");
                gold += 50;
                Console.WriteLine("Leidsid 50 kuldmünti!");
            }
            else if (outcome < 60) // 30% võimalus
            {
                Console.WriteLine("Kohad varemeid kummitust!");
                Combat("kummitus");
            }
            else if (outcome < 80) // 20% võimalus
            {
                Console.WriteLine("Leiad kuningas Loriani päeviku fragmendi!");
                if (!inventory.Contains("päevik"))
                {
                    inventory.Add("päevik");
                    Console.WriteLine("See võib aidata avastada, mis temaga juhtus!");
                }
                else
                {
                    Console.WriteLine("Sul on juba see fragment.");
                }
            }
            else // 20% võimalus
            {
                Console.WriteLine("Lähed läbi salapärase portaali...");
                MysteriousPortal();
            }
        }

        static void MysteriousPortal()
        {
            Console.WriteLine("\nPortaal viib sind kummalisse ruumi ajas ja ruumis.");
            Console.WriteLine("Näed kolme erinevat ust:");
            Console.WriteLine("1. Punane uks");
            Console.WriteLine("2. Sinine uks");
            Console.WriteLine("3. Roheline uks");

            Console.Write("\nValik: ");
            string input = Console.ReadLine();

            Random rand = new Random();
            switch (input)
            {
                case "1":
                    if (rand.Next(1, 101) > 50)
                    {
                        Console.WriteLine("Punane uks viib sind tulemerele! Kaotad 30 elupunkti.");
                        health -= 30;
                        CheckHealth();
                    }
                    else
                    {
                        Console.WriteLine("Punane uks annab sulle tulejõu! Elud täienevad.");
                        health = 100;
                    }
                    break;
                case "2":
                    Console.WriteLine("Sinine uks õpetab sulle uusi tarkusi.");
                    hasSword = true;
                    hasTorch = true;
                    Console.WriteLine("Saad nüüd mõõga ja tõrviku!");
                    break;
                case "3":
                    int goldChange = rand.Next(-20, 51);
                    gold += goldChange;
                    if (goldChange >= 0)
                        Console.WriteLine($"Roheline uks annab sulle {goldChange} kulda!");
                    else
                        Console.WriteLine($"Roheline uks võtab sul {Math.Abs(goldChange)} kulda!");
                    break;
                default:
                    Console.WriteLine("Valimata jätmine viib sind tagasi varemetesse.");
                    break;
            }
        }

        static void Combat(string enemy)
        {
            Random rand = new Random();
            int enemyHealth = 50;
            int enemyDamage = hasSword ? 10 : 20;

            Console.WriteLine($"\nVõitlus {enemy} vastu!");

            while (enemyHealth > 0 && health > 0)
            {
                Console.WriteLine($"\nSinu elud: {health} | {enemy} elud: {enemyHealth}");
                Console.WriteLine("1. Ründa");
                Console.WriteLine("2. Kaitse (vähendab saadavat kahju)");

                Console.Write("\nValik: ");
                string input = Console.ReadLine();

                int damageDealt = hasSword ? rand.Next(15, 26) : rand.Next(5, 16);
                int damageTaken = 0;

                switch (input)
                {
                    case "1":
                        enemyHealth -= damageDealt;
                        Console.WriteLine($"Tehes {damageDealt} kahju {enemy}le!");
                        damageTaken = rand.Next(5, enemyDamage + 1);
                        break;
                    case "2":
                        damageTaken = rand.Next(0, enemyDamage / 2 + 1);
                        Console.WriteLine("Kaitse vähendas saadavat kahju!");
                        break;
                    default:
                        Console.WriteLine("Kehtetu valik! Kaotad aega.");
                        damageTaken = enemyDamage;
                        break;
                }

                health -= damageTaken;
                Console.WriteLine($"{enemy} tegi sulle {damageTaken} kahju!");

                if (health <= 0)
                {
                    Console.WriteLine("Sa kaotasid võitluse...");
                    gameOver = true;
                    return;
                }
            }

            int reward = rand.Next(5, 16);
            gold += reward;
            Console.WriteLine($"\nVõitsid võitluse! Saad {reward} kulda.");
        }

        static void CheckHealth()
        {
            if (health <= 0)
            {
                Console.WriteLine("Sinu elud on otsas...");
                gameOver = true;
            }
            else
            {
                Console.WriteLine($"Sinu elud: {health}/100");
            }
        }
    }
}

