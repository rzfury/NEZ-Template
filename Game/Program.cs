using System;

namespace RZGame
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new())
            {
                game.Window.Title = "NEZ";
                game.Run();
            }
        }
    }
}
