using Microsoft.Xna.Framework.Graphics;

namespace AlliedTionOOP
{
    public static class MainClass
    {
        public const int WindowWidth = 1280;
        public const int WindowHeight = 720;
        public const string WindowTitle = "Magic University BETA v0.3";
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
