using Allied_Tion_Monogame_Test.MapNamespace;
using Allied_Tion_Monogame_Test.Objects.PlayerTypes;
using Microsoft.Xna.Framework;

namespace Allied_Tion_Monogame_Test.Engine
{
    public static class CollisionDetector
    {
        public static bool HasCollisionWithObject(Player player, int targetPositionX, int targetPositionY, Map map, Vector2 mapPosition)
        {
            Rectangle sad = new Rectangle(targetPositionX, targetPositionY, player.Image.Width,
                player.Image.Height);

            foreach(var mapElement in map.MapElements)
            {
                bool intersects =
                    sad.Intersects(new Rectangle(mapElement.TopLeftX + (int)mapPosition.X, mapElement.TopLeftY + (int)mapPosition.Y, mapElement.Image.Width,
                        mapElement.Image.Height));
                if (intersects)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasCollisionWithItem(Player player, Map map, Vector2 mapPosition, out int hashcodeOfCollidedItem)
        {
            Rectangle playerRectangle = new Rectangle(player.TopLeftX, player.TopLeftY, player.Image.Width, player.Image.Height);

            foreach (var mapItem in map.MapItems)
            {
                bool intersects =
                    playerRectangle.Intersects(new Rectangle(mapItem.TopLeftX + (int)mapPosition.X, mapItem.TopLeftY + (int)mapPosition.Y, mapItem.Image.Width,
                        mapItem.Image.Height));
                if (intersects)
                {
                    hashcodeOfCollidedItem = mapItem.GetHashCode();
                    return true;
                }
            }

            hashcodeOfCollidedItem = 0;
            return false;
        }
    }
}
