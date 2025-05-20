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
            Console.WriteLine("1.To-Do List");
            Console.WriteLine("2.Marianna elu");
            Console.WriteLine("3.Cedar Creek");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Tee oma elu valik, tont.");
            string gamedecision = Console.ReadLine();
            switch (gamedecision)
            {
                case "1":
                    manager.Run();
                    break;
                case "2":
                    game.StartGame();
                    break;
                case "3":
                    cedar.StartCedarCreek();
                    break;
                default:
                    Console.WriteLine("Vale valik. Palun proovi uuesti.");
                    break;
            }
        }
    }
}
