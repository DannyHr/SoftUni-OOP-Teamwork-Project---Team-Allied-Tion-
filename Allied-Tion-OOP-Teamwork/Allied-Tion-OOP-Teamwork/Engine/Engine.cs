using System.Threading;
using Allied_Tion_Monogame_Test.MapNamespace;
using Allied_Tion_Monogame_Test.Objects.PlayerTypes;
using Allied_Tion_Monogame_Test.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Allied_Tion_Monogame_Test.Engine
{
    public class Engine : Game
    {
        private const int WindowWidth = 1280;
        private const int WindowHeight = 720;
        private const string WindowTitle = "Allied Tion OOP Teamwork Test Application";
        private const string Music = "../../../Content/Sound/valkyries.mp3";
        private const string GotItem = "../../../Content/Sound/successful2.mp3";
        private const string MapCoordinates = "../../../Content/map-coordinates.txt";

        protected static Texture2D BugImage;
        protected static Texture2D ExceptionImage;
        protected static Texture2D ExamBossImage;

        protected static Texture2D PlayerNerdSkin;
        protected static Texture2D PlayerNormalSkin;
        protected static Texture2D PlayerPartySkin;

        protected static Texture2D ProcessorUpgradeImage;
        protected static Texture2D MemoryUpgradeImage;
        protected static Texture2D DiskUpgradeImage;
        protected static Texture2D NakovBookImage;
        protected static Texture2D ResharperImage;
        protected static Texture2D BeerImage;
        protected static Texture2D RedBullImage;

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

            LoadImages();

            // TODO: Add your initialization logic here

            this.getItemSound = new Sound(GotItem);
            this.musicTheme = new Sound(Music);

            this.map = new Map();

            this.musicTheme.Play(true);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MapFactory.LoadMapImage(map, Content.Load<Texture2D>("MapElementsTextures/map"));
            MapFactory.LoadMapObjectsFromTextFile(map, MapCoordinates, this.Content);

            mapPosition = new Vector2(0, 0);

            //this.spriteFont = Content.Load<SpriteFont>("SpriteFont");

            player = new NormalStudent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {

            //TODO: Player gets stuck with objects in some pixels?
            #region ChecksForInputs
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (player.TopLeftX < WindowWidth / 2
                    || mapPosition.X + map.Image.Width < WindowWidth)
                {
                    if (player.TopLeftX < WindowWidth - player.Image.Width
                      && !CollisionDetector.HasCollisionWithObject(player, (player.TopLeftX + player.Speed.X), player.TopLeftY, map, mapPosition))
                    {
                        player.TopLeftX += player.Speed.X;
                    }
                }
                else
                {
                    mapPosition.X -= player.Speed.X;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (player.TopLeftX >= WindowWidth / 2
                    || mapPosition.X >= map.Image.Bounds.Left)
                {
                    if (player.TopLeftX > 0
                        && !CollisionDetector.HasCollisionWithObject(player, (int)(player.TopLeftX - player.Speed.X), (int)player.TopLeftY, map, mapPosition))
                    {
                        player.TopLeftX -= player.Speed.X;
                    }
                }
                else
                {
                    mapPosition.X += player.Speed.X;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (player.TopLeftY < WindowHeight / 2
                    || mapPosition.Y + map.Image.Height < WindowHeight)
                {
                    if (player.TopLeftY < WindowHeight - player.Image.Height
                        && !CollisionDetector.HasCollisionWithObject(player, (player.TopLeftX), (player.TopLeftY + player.Speed.Y), map, mapPosition))
                    {
                        player.TopLeftY += player.Speed.Y;
                    }
                }
                else
                {
                    mapPosition.Y -= player.Speed.Y;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (player.TopLeftY >= WindowHeight / 2
                    || mapPosition.Y >= map.Image.Bounds.Top)
                {
                    if (player.TopLeftY > 0
                        && !CollisionDetector.HasCollisionWithObject(player, (int)(player.TopLeftX), (int)(player.TopLeftY - player.Speed.Y), map, mapPosition))
                    {
                        player.TopLeftY -= player.Speed.Y;
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

            spriteBatch.Draw(player.Image, new Vector2(player.TopLeftX, player.TopLeftY)); // draw player

            ////draw some text
            //spriteBatch.DrawString(spriteFont, new StringBuilder("Intersects: " + player.CurrentFocus), new Vector2(100, 20), Color.WhiteSmoke);
            //spriteBatch.DrawString(spriteFont, new StringBuilder("Intersects: " + player.TotalFocus), new Vector2(100, 20), Color.WhiteSmoke);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void LoadImages()
        {
            BugImage = Content.Load<Texture2D>("CharacterTextures/bug");
            ExceptionImage = Content.Load<Texture2D>("CharacterTextures/exception");
            ExamBossImage = Content.Load<Texture2D>("CharacterTextures/exam");

            PlayerNerdSkin = Content.Load<Texture2D>("CharacterTextures/wizzard");
            PlayerNormalSkin = Content.Load<Texture2D>("CharacterTextures/wizzard");
            PlayerPartySkin = Content.Load<Texture2D>("CharacterTextures/wizzard");

            ProcessorUpgradeImage = Content.Load<Texture2D>("ItemsTextures/cpu-x35");
            MemoryUpgradeImage = Content.Load<Texture2D>("ItemsTextures/ram");
            DiskUpgradeImage = Content.Load<Texture2D>("ItemsTextures/hdd");
            NakovBookImage = Content.Load<Texture2D>("ItemsTextures/book");
            ResharperImage = Content.Load<Texture2D>("ItemsTextures/RSharper");
            BeerImage = Content.Load<Texture2D>("ItemsTextures/beerx32");
            RedBullImage = Content.Load<Texture2D>("ItemsTextures/redbull");
        }
    }
}

