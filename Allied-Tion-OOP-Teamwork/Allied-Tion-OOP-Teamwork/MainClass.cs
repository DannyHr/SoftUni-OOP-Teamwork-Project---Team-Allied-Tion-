using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test
{
    public static class MainClass
    {
        public const int WindowWidth = 1280;
        public const int WindowHeight = 720;
        public const string WindowTitle = "Allied Tion OOP Teamwork Test Application";
        public const string Music = "../../../Content/Sound/valkyries.mp3";
        public const string GotItem = "../../../Content/Sound/successful2.mp3";
        public const string MapCoordinates = "../../../Content/map-coordinates.txt";

        public static readonly int CurrentScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static readonly int CurrentScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

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
