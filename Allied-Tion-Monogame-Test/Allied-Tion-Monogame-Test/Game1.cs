using System;
using System.Linq;
using System.Text;
using Allied_Tion_Monogame_Test.MapNamespace;

namespace TestMonogame
{
    using Allied_Tion_Monogame_Test;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private const int WindowWidth = 1280;
        private const int WindowHeight = 720;
        private const string windowTitle = "Allied Tion OOP Teamwork Test Application";

        private readonly int currentScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private readonly int currentScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //private SpriteFont spriteFont;
        //private bool intersects = false;

        private Map map;
        private Player player;
        private Vector2 mapPosition;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //window settings
            this.graphics.PreferredBackBufferWidth = WindowWidth;
            this.graphics.PreferredBackBufferHeight = WindowHeight;
            this.Window.Title = windowTitle;

            this.Window.Position = new Point((currentScreenWidth - WindowWidth) / 2,
                (currentScreenHeight - WindowHeight) / 2);

            //this.graphics.ToggleFullScreen();
            //this.Window.IsBorderless = true;

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(5, 5, Content.Load<Texture2D>("CharacterTextures/wizzard"), 2);

            //this.spriteFont = Content.Load<SpriteFont>("SpriteFont");

            this.map = new Map(Content.Load<Texture2D>("MapElementsTextures/map"));
            MapFactory.LoadMapObjectsFromTextFile(map, "../../../map-coordinates.txt",this.Content);
            mapPosition = new Vector2(0, 0);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //intersects = CollisionDetector.HasCollisionWithObject(player, map, mapPosition);

            //TODO: Check if player with new location collides with something. If so, don't move.

            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (player.PositionX < WindowWidth / 2
                    || mapPosition.X + map.Image.Width < WindowWidth)
                {
                    if (player.PositionX < WindowWidth - player.Skin.Width
                      && !CollisionDetector.HasCollisionWithObject(player, (int)(player.PositionX + player.Speed.X), (int)player.PositionY, map, mapPosition))
                    {
                        player.PositionX += player.Speed.X;
                    }
                }
                else
                {
                    mapPosition.X -= player.Speed.X;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (player.PositionX >= WindowWidth / 2
                    || mapPosition.X >= map.Image.Bounds.Left)
                {
                    if (player.PositionX > 0
                        && !CollisionDetector.HasCollisionWithObject(player, (int)(player.PositionX - player.Speed.X), (int)player.PositionY, map, mapPosition))
                    {
                        player.PositionX -= player.Speed.X;
                    }
                }
                else
                {
                    mapPosition.X += player.Speed.X;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (player.PositionY < WindowHeight / 2
                    || mapPosition.Y + map.Image.Height < WindowHeight)
                {
                    if (player.PositionY < WindowHeight - player.Skin.Height
                        && !CollisionDetector.HasCollisionWithObject(player, (int)(player.PositionX), (int)(player.PositionY + player.Speed.Y), map, mapPosition))
                    {
                        player.PositionY += player.Speed.Y;
                    }
                }
                else
                {
                    mapPosition.Y -= player.Speed.Y;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (player.PositionY >= WindowHeight / 2
                    || mapPosition.Y >= map.Image.Bounds.Top)
                {
                    if (player.PositionY > 0
                        && !CollisionDetector.HasCollisionWithObject(player, (int)(player.PositionX), (int)(player.PositionY - player.Speed.Y), map, mapPosition))
                    {
                        player.PositionY -= player.Speed.Y;
                    }
                }
                else
                {
                    mapPosition.Y += player.Speed.Y;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            int hashcodeOfItemToRemove;
            bool hasCollisionWithItem = CollisionDetector.HasCollisionWithItem(player, map, mapPosition, out hashcodeOfItemToRemove);

            if (hasCollisionWithItem)
            {
                map.RemoveMapItemByHashCode(hashcodeOfItemToRemove);
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();

            //spriteBatch.Draw(map.Image, mapPosition, null, Color.Beige);

            //spriteBatch.Draw(bush1.Image, new Vector2(bush1.TopLeft.X,bush1.TopLeft.Y));
            map.Draw(spriteBatch, mapPosition); // draw map with all its elements

            spriteBatch.Draw(player.Skin, new Vector2(player.PositionX, player.PositionY)); // draw player
            //spriteBatch.DrawString(spriteFont, new StringBuilder("Intersects: " + intersects), new Vector2(100, 20), Color.WhiteSmoke);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

