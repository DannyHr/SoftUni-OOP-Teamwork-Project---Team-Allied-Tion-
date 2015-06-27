using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test.MapNamespace
{
    public class MapItem : MapObject
    {
        public MapItem(Texture2D image, Point topLeft) : base(image, topLeft)
        {
        }

        public override int GetHashCode()
        {
            return this.Image.GetHashCode() ^ this.TopLeft.X.GetHashCode() ^ this.TopLeft.Y.GetHashCode();
        }
    }
}
