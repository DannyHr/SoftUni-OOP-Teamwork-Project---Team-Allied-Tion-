using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test
{
    public class MapElement : IObject
    {
        public MapElement(Texture2D image, Point topLeft)
        {
            this.Image = image;
            this.TopLeft = topLeft;
        }

        public Point TopLeft { get; set; }

        public Texture2D Image { get; set; }
    }
}
