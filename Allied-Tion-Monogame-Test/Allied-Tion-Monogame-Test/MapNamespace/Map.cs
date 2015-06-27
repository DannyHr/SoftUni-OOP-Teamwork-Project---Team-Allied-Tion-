using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test.MapNamespace
{
    public class Map
    {
        public Map()
        {
            this.MapElements = new List<MapElement>();
            this.MapCreatures = new List<MapCreature>();
            this.MapItems = new List<MapItem>();
        }

        public List<MapElement> MapElements { get; private set; }

        public List<MapCreature> MapCreatures { get; private set; }

        public List<MapItem> MapItems { get; private set; }

        public Texture2D Image { get; set; }

        public void LoadMapImage(Texture2D mapImage)
        {
            this.Image = mapImage;
        }

        public void AddMapElement(MapElement elementToAdd)
        {
            this.MapElements.Add(elementToAdd);
        }

        public void AddMapCreature(MapCreature creatureToAdd)
        {
            this.MapCreatures.Add(creatureToAdd);
        }

        public void AddMapItem(MapItem itemToAdd)
        {
            this.MapItems.Add(itemToAdd);
        }

        public void RemoveMapItemByHashCode(int hashCodeOfItemToRemove)
        {
            MapItems.Remove(this.MapItems.Single(el => el.GetHashCode() == hashCodeOfItemToRemove));
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 mapPosition)
        {
            spriteBatch.Draw(this.Image, mapPosition);
            foreach (var mapElement in this.MapElements)
            {
                spriteBatch.Draw(mapElement.Image, new Vector2(mapElement.TopLeft.X + mapPosition.X, mapElement.TopLeft.Y + mapPosition.Y));
            }
            foreach (var mapCreature in this.MapCreatures)
            {
                spriteBatch.Draw(mapCreature.Image, new Vector2(mapCreature.TopLeft.X + mapPosition.X, mapCreature.TopLeft.Y + mapPosition.Y));
            }
            foreach (var mapItem in this.MapItems)
            {
                spriteBatch.Draw(mapItem.Image, new Vector2(mapItem.TopLeft.X + mapPosition.X, mapItem.TopLeft.Y + mapPosition.Y));
            }
        }
    }
}
