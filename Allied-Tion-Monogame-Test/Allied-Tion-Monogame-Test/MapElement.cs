using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test
{
    public class MapElement
    {
        public MapElement(Texture2D image, Point topLeft)
        {
            this.Image = image;
            this.TopLeft = topLeft;
            this.BottomLeft = new Point(this.TopLeft.X, this.TopLeft.Y + this.Image.Height);
            this.TopRight = new Point(this.TopLeft.X + this.Image.Width, this.TopLeft.Y);
            this.BottomRight = new Point(this.TopLeft.X + image.Width, this.TopLeft.Y + this.Image.Height);
        }

        public Point TopLeft { get; set; }
        public Point BottomLeft { get; set; }
        public Point TopRight { get; set; }
        public Point BottomRight { get; set; }

        public Texture2D Image { get; set; }
    }
}
