using Allied_Tion_Monogame_Test.MapNamespace;
using Microsoft.Xna.Framework;
using TestMonogame;

namespace Allied_Tion_Monogame_Test
{
    public static class CollisionDetector
    {
        public static bool HasCollisionWithObject(Player player, int targetPositionX, int targetPositionY, Map map, Vector2 mapPosition)
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

        public static bool HasCollisionWithItem(Player player, Map map, Vector2 mapPosition, out int hashcodeOfItemToRemove)
        {
            Rectangle sad = new Rectangle(player.PositionX, player.PositionY, player.Skin.Width, player.Skin.Height);

            foreach (var mapItem in map.MapItems)
            {
                bool intersects =
                    sad.Intersects(new Rectangle(mapItem.TopLeft.X + (int)mapPosition.X, mapItem.TopLeft.Y + (int)mapPosition.Y, mapItem.Image.Width,
                        mapItem.Image.Height));
                if (intersects)
                {
                    hashcodeOfItemToRemove = mapItem.GetHashCode();
                    return true;
                }
            }

            hashcodeOfItemToRemove = 0;
            return false;
        }
    }
}
