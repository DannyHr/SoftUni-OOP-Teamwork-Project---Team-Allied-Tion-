using AlliedTionOOP.MapNamespace;
using AlliedTionOOP.Objects.PlayerTypes;
using Microsoft.Xna.Framework;

namespace AlliedTionOOP.Engine
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

        public static bool HasCollisionWithEnemy(Player player, Map map, Vector2 mapPosition, out int hashcodeOfCollidedEnemy)
        {
            Rectangle playerRectangle = new Rectangle(player.TopLeftX, player.TopLeftY, player.Image.Width, player.Image.Height);

            foreach (var creature in map.MapCreatures)
            {
                bool intersects =
                    playerRectangle.Intersects(new Rectangle(creature.TopLeftX + (int)mapPosition.X, creature.TopLeftY + (int)mapPosition.Y, creature.Image.Width,
                        creature.Image.Height));
                if (intersects)
                {
                    hashcodeOfCollidedEnemy = creature.GetHashCode();
                    return true;
                }
            }

            hashcodeOfCollidedEnemy = 0;
            return false;
        }
    }
}
