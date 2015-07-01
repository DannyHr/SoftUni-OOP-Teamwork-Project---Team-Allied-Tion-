using System.Collections.Generic;
using System.Linq;
using AlliedTionOOP.Objects;
using AlliedTionOOP.Objects.Creatures;
using AlliedTionOOP.Objects.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlliedTionOOP.MapNamespace
{
    public class Map
    {
        public Map()
        {
            this.MapElements = new List<MapElement>();
            this.MapCreatures = new List<Creature>();
            this.MapItems = new List<Item>();
        }

        public List<MapElement> MapElements { get; private set; }

        public List<Creature> MapCreatures { get; private set; }

        public List<Item> MapItems { get; private set; }

        public Texture2D Image { get; set; }

        public void AddElement(MapElement mapElementToAdd)
        {
            this.MapElements.Add(mapElementToAdd);
        }

        public void AddCreature(Creature creatureToAdd)
        {
            this.MapCreatures.Add(creatureToAdd);
        }

        public void AddItem(Item itemToAdd)
        {
            this.MapItems.Add(itemToAdd);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 mapPosition)
        {
            spriteBatch.Draw(this.Image, mapPosition);

            foreach (var mapElement in this.MapElements)
            {
                spriteBatch.Draw(mapElement.Image, new Vector2(mapElement.TopLeftX + mapPosition.X, mapElement.TopLeftY + mapPosition.Y));
            }

            foreach (var mapCreature in this.MapCreatures)
            {
                spriteBatch.Draw(mapCreature.Image, new Vector2(mapCreature.TopLeftX + mapPosition.X, mapCreature.TopLeftY + mapPosition.Y));
            }

            foreach (var mapItem in this.MapItems)
            {
                spriteBatch.Draw(mapItem.Image, new Vector2(mapItem.TopLeftX + mapPosition.X, mapItem.TopLeftY + mapPosition.Y));
            }
        }


        public void RemoveMapItemByHashCode(Map map, int hashCodeOfItemToRemove)
        {
            map.MapItems.Remove(map.MapItems.Single(el => el.GetHashCode() == hashCodeOfItemToRemove));
        }

        public void RemoveEnemyByHashCode(Map map, int hashCodeOfEnemyToRemove)
        {
            map.MapCreatures.Remove(map.MapCreatures.Single(en => en.GetHashCode() == hashCodeOfEnemyToRemove));
        }
    }
}
