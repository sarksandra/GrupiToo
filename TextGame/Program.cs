namespace TextGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ToDoList Mihkel
            Story1 manager = new Story1();
            manager.Run();
            Game game = new Game();
            game.StartGame();
        }
    }
}
