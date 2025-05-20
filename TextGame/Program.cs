using TextGame.CedarCreek;

namespace TextGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ToDoList Mihkel
            Story1 manager = new Story1();
            //manager.Run();
            Game game = new Game();
            //game.StartGame();

            PaertStory cedar = new PaertStory();
            //cedar.StartCedarCreek();
            //cedar.TavernInteractions();
            // Tsükkel, et programmis jääda menüüsse, kuni kasutaja valib lõpetamise
            while (true)
            {
                Console.Clear(); // Puhastab ekraani iga kord, kui tsükkel käivitub
                Console.WriteLine("1. To-Do List");
                Console.WriteLine("2. Marianna elu");
                Console.WriteLine("3. Cedar Creek");
                Console.WriteLine();
                Console.WriteLine("Tee oma elu valik, tont.");

                // Kasutaja sisend
                string gamedecision = Console.ReadLine();

                switch (gamedecision)
                {
                    case "1":
                        manager.Run(); // Käivitab To-Do Listi menüü
                        break;
                    case "2":
                        game.StartGame(); // Käivitab Marianna elu mängu
                        break;
                    case "3":
                        cedar.StartCedarCreek(); // Käivitab Cedar Creek
                        break;
                    default:
                        Console.WriteLine("Vale valik. Palun proovi uuesti.");
                        break;
                }

                // Kasutaja küsib, kas soovib jätkata või lõpetada
                Console.WriteLine("\nKas soovid jätkata? (Jah/ei)");
                string continueDecision = Console.ReadLine().ToLower();

                if (continueDecision != "jah")
                {
                    Console.WriteLine("Programmi lõpetamine...");
                    break; // Lõpetab programmi, kui kasutaja ei soovi jätkata
                }
            }
        }
    }
}
