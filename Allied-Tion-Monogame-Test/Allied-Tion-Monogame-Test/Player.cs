using Microsoft.Xna.Framework;

namespace TestMonogame
{
    using Microsoft.Xna.Framework.Graphics;

    public class Player
    {
        public Player(string name, float positionX, float positionY, Texture2D skin, float speed)
        {
            this.Name = name;
            this.Skin = skin;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Speed = new Vector2(speed, speed);
        }

        public string Name { get; set; }

        public Texture2D Skin { get; set; }

        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public Vector2 Speed { get; set; }
    }
}

