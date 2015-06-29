using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleMenu
{
    public class MainMenu //contains our all gui elements stany
    {
        List<GUIElement> main = new List<GUIElement>();

        public MainMenu() // parametreless ctor
        {
            main.Add(new GUIElement("content_game/grunge-texture5")); // menu
            main.Add(new GUIElement("content_game/PlayBtn"));
        }

        public void LoadContent(ContentManager content) // validation
        {
            foreach (GUIElement element in main)
            {
                element.LoadContent(content);
                element.CenterElement(800, 600);
                element.clickEvent +=  this.OnClick;

            }
           // main.Find(x => x.AssetName == "PlayBtn").MoveElement(0,-10);

        }

        public void Update()
        {
            foreach (GUIElement element in main)
            {
                element.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GUIElement element in main)
            {
                element.Draw(spriteBatch);
            }
        }

        public void OnClick(string element)
        {
            if (element == "PlayBtn")
            {
                // Play the game
            }
            else if (element == "AboutBtn")
            {
                // About 
            }
        
        }
    }
}