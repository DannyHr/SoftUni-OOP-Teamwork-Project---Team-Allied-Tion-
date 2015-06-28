using System.Threading;
using System.Threading.Tasks;
using Allied_Tion_Monogame_Test;
using Allied_Tion_Monogame_Test.MapNamespace;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestMonogame
{
    public class Engine : Game
    {
        private const int WindowWidth = 1280;
        private const int WindowHeight = 720;
        private const string WindowTitle = "Allied Tion OOP Teamwork Test Application";
        private const string Music = "../../../Content/Sound/valkyries.mp3";
        private const string GotItem = "../../../Content/Sound/successful2.mp3";
        private const string MapCoordinates = "../../../Content/map-coordinates.txt";

        private readonly int currentScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private readonly int currentScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Sound getItemSound;
        private Sound musicTheme;

        //private SpriteFont spriteFont;
        //private bool intersects = false;

        private Map map;
        private Player player;
        private Vector2 mapPosition;

        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //window settings
            this.graphics.PreferredBackBufferWidth = WindowWidth;
            this.graphics.PreferredBackBufferHeight = WindowHeight;

            this.Window.Title = WindowTitle;

            this.Window.Position = new Point((currentScreenWidth - WindowWidth) / 2,
                (currentScreenHeight - WindowHeight) / 2);

            //this.graphics.ToggleFullScreen();
            //this.Window.IsBorderless = true;

            // TODO: Add your initialization logic here

            this.getItemSound = new Sound(GotItem);
            this.musicTheme = new Sound(Music);

            this.musicTheme.Play(true);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.map = new Map();
            MapFactory.LoadMapImage(map, Content.Load<Texture2D>("MapElementsTextures/map"));
            MapFactory.LoadMapObjectsFromTextFile(map, MapCoordinates, this.Content);

            mapPosition = new Vector2(0, 0);
            
            //this.spriteFont = Content.Load<SpriteFont>("SpriteFont");

            player = new Player(5, 5, Content.Load<Texture2D>("CharacterTextures/wizzard"), 3);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        //TODO:Play audio in Update method!!!
        protected override void Update(GameTime gameTime)
        {

            //TODO: Player gets stuck with objects in some pixels?
            #region ChecksForInputs
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (player.PositionX < WindowWidth / 2
                    || mapPosition.X + map.Image.Width < WindowWidth)
                {
                    if (player.PositionX < WindowWidth - player.Skin.Width
                      && !CollisionDetector.HasCollisionWithObject(player, (player.PositionX + player.Speed.X), player.PositionY, map, mapPosition))
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

            #endregion

            int hashcodeOfCollidedItem;
            bool hasCollisionWithItem = CollisionDetector.HasCollisionWithItem(player, map, mapPosition, out hashcodeOfCollidedItem);

            if (hasCollisionWithItem)
            {
                MapFactory.RemoveMapItemByHashCode(map, hashcodeOfCollidedItem);
                new Thread(() => getItemSound.Play()).Start();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();

            map.Draw(spriteBatch, mapPosition); // draw map with all its elements

            spriteBatch.Draw(player.Skin, new Vector2(player.PositionX, player.PositionY)); // draw player

            ////draw some text
            //spriteBatch.DrawString(spriteFont, new StringBuilder("Intersects: " + intersects), new Vector2(100, 20), Color.WhiteSmoke);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

