using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;

namespace MonogameNauka2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Level1 level1;
        private Vector2 Position;
        private KeyboardState KState;
        private Texture2D PlayerTexture;
        private Matrix ScaleMatrix;
        private Vector3 ScaleVector;
        public static Point WorldSize { get; private set; }
        private SpriteFont SpriteFont { get; set; }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GraphicInitialize();
            CalcualteScale();
            InitializeCamera();
            base.Initialize();
        }
        private void InitializeCamera()
        {
            Camera.Graphics = graphics;
        }

        private void GraphicInitialize()
        {
            IsFixedTimeStep = false;
            graphics.PreferredBackBufferWidth = 1980;
            graphics.PreferredBackBufferHeight = 1080;
            WorldSize = new Point(1980, 1080);
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }
        private void CalcualteScale()
        {
            ScaleMatrix = new Matrix();
            ScaleVector = new Vector3(graphics.PreferredBackBufferWidth / (float)WorldSize.X, graphics.PreferredBackBufferHeight / (float)WorldSize.Y, 1);
            ScaleMatrix = Matrix.CreateScale(ScaleVector);
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            level1 = new Level1(Content.ServiceProvider, graphics);
            PlayerTexture = Content.Load<Texture2D>("character");
            SpriteFont = Content.Load<SpriteFont>("File");
            Player.InitializePlayer(PlayerTexture, Position, SpriteFont, graphics);
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KState = Keyboard.GetState();
            level1.Update(gameTime, KState);
            
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.CameraMatrix);
            level1.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
