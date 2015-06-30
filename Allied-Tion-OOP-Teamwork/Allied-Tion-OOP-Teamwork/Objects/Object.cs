using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test.Objects
{
    public abstract class Object : Engine.Engine
    {
        protected Object(Texture2D image, int topLeftX, int topLeftY)
        {
            this.Image = image;
            this.TopLeftX = topLeftX;
            this.TopLeftY = topLeftY;
        }

        public int TopLeftX { get; set; }

        public int TopLeftY { get; set; }

        public Texture2D Image { get; set; }
    }
}
