using System;
using System.Collections.Generic;
using System.Linq;

namespace TextGame
{
    public class Story1
    {
        // Mängija atribuudid
        private static int gold = 0; // Kuld
        private static int health = 100; // Elujõud
        private static int hunger = 0; // Nälg
        private static List<string> inventory = new List<string>(); // Inventar
        private static int experience = 0; // Kogemuspunkid

        public void StartGame()
        {
            Console.WriteLine("Tere tulemast tekstipõhisesse mängu!");
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.WriteLine("Vali tegevus:");
            Console.WriteLine("1. Alusta mängu");
            Console.WriteLine("2. Välju");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartAdventure();
                    break;
                case "2":
                    ExitGame();
                    break;
                default:
                    Console.WriteLine("Vale valik. Palun proovi uuesti.");
                    ShowMenu();
                    break;
            }
        }

        private static void StartAdventure()
        {
            Console.Clear();
            Console.WriteLine("Seiklus algab nüüd! Oled üksik rändur, kes on sattunud salapärasesse metsa.");
            Console.WriteLine($"Sul on {gold} kulda, {health} elujõudu ja {hunger} nälga. Sinu inventaris on järgmised esemed: {string.Join(", ", inventory)}");
            Console.WriteLine("Mis sa tahad teha?");
            Console.WriteLine("1. Astu vasakule rajale.");
            Console.WriteLine("2. Astu paremale rajale.");
            Console.WriteLine("3. Ürita leida metsast välja.");
            Console.WriteLine("4. Külastage kauplejat.");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    LeftPath();
                    break;
                case "2":
                    RightPath();
                    break;
                case "3":
                    FindExit();
                    break;
                case "4":
                    VisitMerchant();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }

        private static void VisitMerchant()
        {
            Console.Clear();
            Console.WriteLine("Külastasid kauplejat. Tema kauplus on täis erinevaid esemeid.");
            Console.WriteLine("1. Osta tervendav potion (10 kulda)");
            Console.WriteLine("2. Osta parem relv (20 kulda)");
            Console.WriteLine("3. Osta toitu (5 kulda)");
            Console.WriteLine("4. Mine tagasi.");

            // Kui mängijal on juba mõni kaup, siis ei saa seda uuesti osta
            if (inventory.Contains("Tervendav potion"))
            {
                Console.WriteLine("Tervendavat poti sa ei saa enam osta, kuna sul on see juba.");
            }
            if (inventory.Contains("Parem relv"))
            {
                Console.WriteLine("Parem relv on sul juba olemas, seda ei saa enam osta.");
            }
            if (inventory.Contains("Toit"))
            {
                Console.WriteLine("Toit on sul juba olemas, seda ei saa enam osta.");
            }

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (gold >= 10 && !inventory.Contains("Tervendav potion"))
                    {
                        gold -= 10;
                        inventory.Add("Tervendav potion");
                        Console.WriteLine("Ostsid tervendava poti! Sa saad seda kasutada hiljem.");
                    }
                    else if (inventory.Contains("Tervendav potion"))
                    {
                        Console.WriteLine("Sul on juba tervendav potion, seda ei saa uuesti osta.");
                    }
                    else
                    {
                        Console.WriteLine("Sul ei ole piisavalt kulda!");
                    }
                    break;
                case "2":
                    if (gold >= 20 && !inventory.Contains("Parem relv"))
                    {
                        gold -= 20;
                        inventory.Add("Parem relv");
                        Console.WriteLine("Ostsid parema relva! See aitab sul võidelda tugevamate vaenlastega.");
                    }
                    else if (inventory.Contains("Parem relv"))
                    {
                        Console.WriteLine("Sul on juba parem relv, seda ei saa uuesti osta.");
                    }
                    else
                    {
                        Console.WriteLine("Sul ei ole piisavalt kulda!");
                    }
                    break;
                case "3":
                    if (gold >= 5 && !inventory.Contains("Toit"))
                    {
                        gold -= 5;
                        hunger = Math.Max(0, hunger - 10); // Toit vähendab nälga
                        inventory.Add("Toit");
                        Console.WriteLine("Ostsid toidu, mis leevendas su nälga.");
                    }
                    else if (inventory.Contains("Toit"))
                    {
                        Console.WriteLine("Sul on juba toit, seda ei saa uuesti osta.");
                    }
                    else
                    {
                        Console.WriteLine("Sul ei ole piisavalt kulda!");
                    }
                    break;
                case "4":
                    Console.WriteLine("Lahkusid kauplusest.");
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    break;
            }

            StartAdventure();
        }

        private static void LeftPath()
        {
            Console.Clear();
            Console.WriteLine("Valisid vasaku raja. Rajal on tihedamad puud ja vaikne atmosfäär.");
            Console.WriteLine("Peagi leiad vanast puust rajamaja. Kas tahad astuda sisse?");
            Console.WriteLine("1. Astu sisse.");
            Console.WriteLine("2. Jätka teed.");
            Console.WriteLine("3. Tõsta oma relv, ettevaatlikult uurides rajamaja ümbrust.");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Astusid sisse ja kohtasid vana meest. Ta räägib, et ta on vahi alla pandud nõid.");
                Console.WriteLine("Ta pakub sulle pakkumise. Kas tahad aidata teda?");
                Console.WriteLine("1. Aita teda, et saada oma aidata.");
                Console.WriteLine("2. Keeldu ja mine edasi.");

                string subChoice = Console.ReadLine();
                if (subChoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Sa aitasid nõida lahti pääseda. Ta annab sulle võlujõu.");
                    Console.WriteLine("Kasutades oma uusi jõude, leidsid sa suure aardekirstu!");
                    gold += 50; // Kuld, mis saadakse aarelt
                    experience += 10; // Kogemuspunkte
                    StartAdventure(); // Tagasi seiklusele
                }
                else if (subChoice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Sa keeldusid ja lahkusid rajamajast. Edasi minnes leidsid metsast vana kaevu.");
                    Console.WriteLine("Kas tahad kaevu uurida?");
                    Console.WriteLine("1. Uuri kaevu.");
                    Console.WriteLine("2. Liigu edasi.");

                    string furtherChoice = Console.ReadLine();
                    if (furtherChoice == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Kaevus olid vanad mündid ja vesi, kuid see viib sind edasi koopasse.");
                        gold += 20; // Kuld, mis saadakse kaevust
                        experience += 5; // Kogemuspunkte
                        StartAdventure(); // Tagasi seiklusele
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Liikusid edasi ja leidsid elu täis rikkaid seeni! Tervis taastub veidi.");
                        health = Math.Min(100, health + 10); // Tervis taastub
                        StartAdventure(); // Tagasi seiklusele
                    }
                }
                else
                {
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    LeftPath();
                }
            }
            else
            {
                Console.WriteLine("Vale valik. Proovi uuesti.");
                LeftPath();
            }
        }

        private static void RightPath()
        {
            Console.Clear();
            Console.WriteLine("Valisid parema raja. Rajal kohtad järsku hiiglaslikku madu!");
            Console.WriteLine("Kas tahad rünnata või ära joosta?");
            Console.WriteLine("1. Rünnata madu.");
            Console.WriteLine("2. Püüa jooksu panna.");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Sa ründasid madut, aga ta oli liiga tugev. Õnneks pääsesid sa vigastatuna, kuid elus.");
                health = Math.Max(0, health - 30); // Väheneb tervis
                gold += 10; // Väike kulla lisand
                experience += 5; // Väikesed kogemuspunkte
                StartAdventure(); // Tagasi seiklusele
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Sa jooksid ja leidsid end salapärasest koopast. Kas tahad minna sisse?");
                Console.WriteLine("1. Mine sisse.");
                Console.WriteLine("2. Liigu edasi.");

                string subChoice = Console.ReadLine();
                if (subChoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Sisenesid koopasse ja leidsid iidse aardekirstu.");
                    gold += 100; // Kuld aardest
                    experience += 20; // Kogemuspunkte
                    StartAdventure(); // Tagasi seiklusele
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Jõudsid lõksu. Õnneks pääsesid sa elusalt, kuid väsinuna.");
                    health = Math.Max(0, health - 10); // Väheneb tervis
                    StartAdventure(); // Tagasi seiklusele
                }
            }
            else
            {
                Console.WriteLine("Vale valik. Proovi uuesti.");
                RightPath();
            }
        }

        private static void FindExit()
        {
            Console.Clear();
            Console.WriteLine("Püüad leida metsast välja, kuid kaotad suuna ja satud uude piirkonda.");
            Console.WriteLine("Kas tahad uurida piirkonda?");
            Console.WriteLine("1. Uuri piirkonda.");
            Console.WriteLine("2. Püüa tagasi minna.");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Leidsid vana lossivareme ja astusid lõksu.");
                EndGame();
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Õnnestus tagasi minna, kuid oled väsinud. Tervis taastub mõne võrra.");
                health = Math.Min(100, health + 20); // Tervis taastub
                StartAdventure(); // Tagasi seiklusele
            }
            else
            {
                Console.WriteLine("Vale valik. Proovi uuesti.");
                FindExit();
            }
        }

        private static void EndGame()
        {
            Console.WriteLine("Mäng läbi! Kas tahad mängu uuesti alustada?");
            Console.WriteLine("1. Jah");
            Console.WriteLine("2. Ei");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                StartAdventure();
            }
            else
            {
                ExitGame();
            }
        }

        private static void ExitGame()
        {
            Console.WriteLine("Aitäh, et mängisid!");
            Environment.Exit(0);
        }
    }
}
