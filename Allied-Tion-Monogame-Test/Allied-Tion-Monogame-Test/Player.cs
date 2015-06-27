using Microsoft.Xna.Framework;

namespace TestMonogame
{
    using Microsoft.Xna.Framework.Graphics;

    public class Player
    {
        public Player(int positionX, int positionY, Texture2D skin, int speed)
        {
            this.Skin = skin;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Speed = new Point(speed, speed);
        }

        public Texture2D Skin { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Point Speed { get; set; }
    }
}

