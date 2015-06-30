﻿using System.Collections.Generic;
using Allied_Tion_Monogame_Test.Objects;
using Allied_Tion_Monogame_Test.Objects.Creatures;
using Allied_Tion_Monogame_Test.Objects.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test.MapNamespace
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
    }
}