using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Game
    {
        // Mängu alguse funktsioon
        public void StartGame()
        {
            Console.WriteLine("Tere tulemast Marianna ellu!");
            ShowMenu();
        }

        // Kuvab peamenüü
        private void ShowMenu()
        {
            Console.WriteLine("Vali tegevus:");
            Console.WriteLine("1. Alusta mängu");
            Console.WriteLine("2. Välju mängust");
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

        // esimene osa
        private void StartAdventure()
        {
            Console.Clear();
            Console.WriteLine("Elaskord tüdruk Marianna, kes taahtis enda sõbrale külla minna. Aga kell on palja ja ta mõtleb, kas minna bussiga või jala");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna läheb bussiga");
            Console.WriteLine("2. Marianna läheb jala");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BusPath();
                    break;
                case "2":
                    FriendWalk();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }

        
        private void BusPath()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas minna bussiga ja ta jõudis turvaliselt sõbranna juurde.");
            Console.WriteLine("Neil oli tore õhtu kuniks marianna väsis ära ja mõtles aeg on koju tagasi minna aga kell oli nii palju, et ühtegi bussi enam ei sõida");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna jääb sõbra juurde ööseks");
            Console.WriteLine("2. Marianna läheb jala koju");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    FriendNight();
                    break;
                case "2":
                    HomeWalk();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }
        private void FriendWalk()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas minna jala");
            Console.WriteLine("Poole tee pealt tuli tal varas vastu, kes lasi ta maha");
            Console.WriteLine("Marianna suri...");
            EndGame();
        }


        private void FriendNight()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas jääda sõbra juurde ööseks");
            Console.WriteLine("Öösel jõudis sõbra isa koju ta tahtis Mariannat katsuda aga Marianna ei lubanud ja isa sai vihaseks");
            Console.WriteLine("Marianna suri...");
            EndGame();
        }

        // teine osa
        private void HomeWalk()
        {
            Console.Clear();
            Console.WriteLine("Marianna kõndis turvaliselt koju ja läks otse magama");
            Console.WriteLine("On uus päev ja Marianna mõtleb, kas minna trenni või sõbrannaga kinno");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna läheb trenni");
            Console.WriteLine("2. Marianna läheb sõbraga kinno");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Trenn();
                    break;
                case "2":
                    Kino();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }
        private void Trenn()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas trenni minna");
            Console.WriteLine("Ta pani asjad kokku jaa talle pakkus ema välja, et viib ta ise ära");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna läheb emaga koos");
            Console.WriteLine("2. Marianna otsustas üksi minna");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Momcar();
                    break;
                case "2":
                    Aloune();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }
        private void Momcar()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas minna emaga trenni");
            Console.WriteLine("Marianna ja ta ema sattusid liiklus õnnetusse");
            Console.WriteLine("Marianna suri...");
            EndGame();
        }
        private void Aloune()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas minna üksi trenni");
            Console.WriteLine("Marianna jõudis trenni, kus ta mängis tennis ja peale seda otsustas ta koju minna");
            Console.WriteLine("Kodus Marianna mõtles, kuidas tal elus vedanud on, et tal nii hea elu on");
            EndGame();           
        
        }

        private void Kino()
        {
            Console.Clear();
            Console.WriteLine("Marianna läks sõbrannaga kinno");
            Console.WriteLine("Peale kino mõtlesid Marianna ja ta sõber minna jäätist sööma");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna läheb jäätist sööma");
            Console.WriteLine("2. Marianna läheb üksi koju");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Icecreame();
                    break;
                case "2":
                    KinoWalk();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }
        private void Icecreame()
        {
            Console.Clear();
            Console.WriteLine("Marianna läks sõbranna jäätist sööma");
            Console.WriteLine("Peale jäätise söömist röövis kaubik Marianna ja ta sõbra ära");
            Console.WriteLine("Vargad ütlesid nad oleks vait");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna hakkab karjuma");
            Console.WriteLine("2. Marianna on vaikselt");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Scream();
                    break;
                case "2":
                    Quaiet();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }
        private void Scream()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas karjuma hakata");
            Console.WriteLine("Marianna ja ta sõber pussitati noaga...");
            Console.WriteLine("Marianna suri");
            EndGame();
        }
        private void Quaiet()
        {
            Console.Clear();
            Console.WriteLine("Marianna ja ta sõbranna olid vaikselt");
            Console.WriteLine("Röövlid andis mariannale valiku, kas Marianna saab vabaks ja ta sõbranna sureb või jääb siia ja mõlemad jäävad ellu");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna jäi sõbrannaga");
            Console.WriteLine("2. Marianna läks üksi ära");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Forever();
                    break;
                case "2":
                    Trauma();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }
        private void Forever()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas enda sõbraga jääda");
            Console.WriteLine("Peale 5h bussis olemist, jõudis politsei ja röövlid olid vahistatud");
            Console.WriteLine("Tuli välja, et Marianna ema hakkas muretsema ja kutsus politsei");
            Console.WriteLine("Marianna ja ta sõbranna olid sellest traumatiseeritud ja ta mõtles miks just temaga see juhtuma pidi");
            EndGame();
        }
        private void Trauma()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas sõbrannamaha jätta ja jooksis koju");
            Console.WriteLine("Hommikul sai ta teaba ta sõber oli kohtaval viisil ära tapetud ja ta oli surnud");
            Console.WriteLine("Mariannal oli eluaegne trauma sellest õhtust ja ta läks nööriga metsa...");
            Console.WriteLine("Mariannal suri");
            EndGame();
        }

        private void KinoWalk()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas ikkagi koju minna");
            Console.WriteLine("Poole tee peal nägi Marianna näljast kodutut kassi");
            Console.WriteLine("Marianna mõtles ta koju kaasa võtta");
            Console.WriteLine("Tee valik?");
            Console.WriteLine("1. Marianna võtab kassi endaga kaasa");
            Console.WriteLine("2. Marianna läheb üksi koju");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    HappyCat();
                    break;
                case "2":
                    SadCat();
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    StartAdventure();
                    break;
            }
        }
        private void HappyCat()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas kassi endaga kaasa võtta");
            Console.WriteLine("Marianna isa oli natuke pahane aga emale hakkas kass kohe kass meeldima");
            Console.WriteLine("Marianna oli koos kassiga õnnelik ja mõtles kuidas tal ikka vedanud on elus");
            EndGame();
        }
        private void SadCat()
        {
            Console.Clear();
            Console.WriteLine("Marianna otsustas kassi maha jätta ja kõndis edasi");
            Console.WriteLine("Kuna Marianna ei jäänud kassiga siis jõudis Marianna maja ette varem");
            Console.WriteLine("Seal seisis üks kaubik, mis röövis ta ära");
            Console.WriteLine("Mariannat ei nähtud enam kunagi");
            EndGame();
        }


        // Lõpetab mängu
        private void EndGame()
        {
            Console.WriteLine("Mäng läbi! Kas tahad mängu uuesti alustada?");
            Console.WriteLine("1. Jah");
            Console.WriteLine("2. Ei");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                StartGame();
            }
            else
            {
                ExitGame();
            }
        }

        // Väljub mängust
        private void ExitGame()
        {
            Console.WriteLine("Aitäh, et mängisid!");
            Environment.Exit(0);
        }
    }
}
