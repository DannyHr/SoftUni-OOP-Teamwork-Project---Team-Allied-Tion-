using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlliedTionOOP.GUI.Menus
{
    public class MainMenu
    {
        public MainMenu(Texture2D background)
        {
            this.Background = background;
            this.Buttons = new List<Button>();
        }

        public List<Button> Buttons { get; set; }

        public Texture2D Background { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Background, new Vector2(0, 0));
            foreach (var button in this.Buttons)
            {
                spriteBatch.Draw(button.ButtonTexture, new Vector2(button.ButtonTopLeftX, button.ButtonTopLeftY));
            }
        }
    }
}