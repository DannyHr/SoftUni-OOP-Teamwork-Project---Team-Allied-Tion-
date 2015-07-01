using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlliedTionOOP.Objects.Creatures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AlliedTionOOP.GUI
{
    public static class Target
    {
        public static void DrawTarget(Creature creature, SpriteBatch spriteBatch, ContentManager content, Vector2 mapPosition)
        {
            const int targetImageWidth = 15;
            const int offsetY = 28;

            float topLeftX = creature.TopLeftX + mapPosition.X + (creature.Image.Width / 2 - targetImageWidth / 2 + 2);
            float topLeftY = creature.TopLeftY + mapPosition.Y - offsetY;

            spriteBatch.Draw(content.Load<Texture2D>("CharacterTextures/target"), new Vector2(topLeftX, topLeftY));
        }
    }
}
