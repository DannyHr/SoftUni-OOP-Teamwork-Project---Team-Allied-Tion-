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
