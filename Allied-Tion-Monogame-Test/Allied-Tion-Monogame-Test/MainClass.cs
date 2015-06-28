using Allied_Tion_Monogame_Test;
using System;
using System.Threading.Tasks;

namespace TestMonogame
{
    public static class MainClass
    {
        private static void Main()
        {
            var engine = new Engine();
            using (engine)
            {
                engine.Run();
            }
        }
    }
}
