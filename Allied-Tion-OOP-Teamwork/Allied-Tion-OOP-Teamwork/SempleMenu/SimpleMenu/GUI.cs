using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SimpleMenu
{
    public class GUI : Game
    {
        readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private MainMenu mainMenu;

        public GUI()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;

            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            Button playButton = new Button("play", Content.Load<Texture2D>("content_game/PlayBtn"), 700, 30);
            Button howToPlayButton = new Button("howToPlay", Content.Load<Texture2D>("content_game/HowToPlay"), 700, 200);
            Button aboutButton = new Button("about", Content.Load<Texture2D>("content_game/AboutBtn"), 700, 350);
            Button quitButton = new Button("quit", Content.Load<Texture2D>("content_game/Quit"), 700, 500);

            mainMenu = new MainMenu(Content.Load<Texture2D>("content_game/grunge-texture5"));

            playButton.Click += OnClick;
            howToPlayButton.Click += OnClick;
            aboutButton.Click += OnClick;
            quitButton.Click += OnClick;

            mainMenu.Buttons.Add(playButton);
            mainMenu.Buttons.Add(howToPlayButton);
            mainMenu.Buttons.Add(aboutButton);
            mainMenu.Buttons.Add(quitButton);

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            // TODO: Add your update logic here

            foreach (var button in mainMenu.Buttons)
            {
                if (button.ButtonRect.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    button.FireClick();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            this.mainMenu.Draw(spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void OnClick(object buttonClicked, EventArgs args)
        {
            Button currentClickedButton = buttonClicked as Button;
            switch (currentClickedButton.ButtonName)
            {
                case "play":
                    currentClickedButton.ButtonTopLeftX++;
                    break;
                case "howToPlay":
                    currentClickedButton.ButtonTopLeftY++;
                    break;
                case "about":
                    currentClickedButton.ButtonTopLeftX--;
                    break;
                case "quit":
                    this.Exit();
                    break;
            }
        }
    }
}
