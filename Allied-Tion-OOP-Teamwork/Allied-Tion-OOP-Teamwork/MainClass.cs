namespace Allied_Tion_Monogame_Test
{
    public static class MainClass
    {
        private static void Main()
        {
            var engine = new Engine.Engine();

            using (engine)
            {
                engine.Run();
            }
        }
    }
}
