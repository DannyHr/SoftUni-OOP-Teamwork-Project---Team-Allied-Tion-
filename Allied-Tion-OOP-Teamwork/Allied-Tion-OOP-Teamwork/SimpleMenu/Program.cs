using System;

namespace SimpleMenu
{
    public static class Program
    {
        static void Main()
        {
            using (var game = new GUI())
            {
                game.Run();
            }
        }
    }
}
