using Allied_Tion_Monogame_Test.MapNamespace;
using Microsoft.Xna.Framework;
using TestMonogame;

namespace Allied_Tion_Monogame_Test
{
    public static class CollisionDetector
    {
        public static bool CheckForCollision(Player player, int targetPositionX, int targetPositionY, Map map, Vector2 mapPosition)
        {
            Rectangle sad = new Rectangle(targetPositionX, targetPositionY, player.Skin.Width,
                player.Skin.Height);

            foreach(var mapElement in map.MapElements)
            {
                bool intersects =
                    sad.Intersects(new Rectangle(mapElement.TopLeft.X + (int)mapPosition.X, mapElement.TopLeft.Y + (int)mapPosition.Y, mapElement.Image.Width,
                        mapElement.Image.Height));
                if (intersects)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
