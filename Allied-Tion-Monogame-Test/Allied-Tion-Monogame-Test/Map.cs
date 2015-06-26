using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test
{
    public class Map
    {
        public List<MapElement> MapElements { get; private set; }

        public Texture2D Image { get; set; }

        public void Initialize(Texture2D image)
        {
            this.MapElements = new List<MapElement>();
            this.Image = image;
        }

        public void AddMapElement(MapElement mapElToAdd)
        {
            this.MapElements.Add(mapElToAdd);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 mapPosition)
        {
            spriteBatch.Draw(this.Image, mapPosition);
            foreach (var mapElement in MapElements)
            {
                spriteBatch.Draw(mapElement.Image, new Vector2(mapElement.TopLeft.X + mapPosition.X, mapElement.TopLeft.Y + mapPosition.Y));
            }
        }
    }
}
