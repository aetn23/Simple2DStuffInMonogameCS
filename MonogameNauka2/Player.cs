using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonogameNauka2
{
    static class Player
    {
        public static Vector2 Position;
        public static Texture2D Texture { get; set; }
        public static int Width { get; private set; }
        public static int Height { get; private  set; }
        private static SpriteFont SpriteFont { get; set; }
        public static float Speed { get; private set; }
        public static GraphicsDeviceManager Graphics;
        public static Vector2 GetPosition()
        {
            return Position;
        }
        public static void InitializePlayer(Texture2D texture, Vector2 position, SpriteFont spriteFont, GraphicsDeviceManager graphics)
        {
            Texture = texture;
            Position = position;
            Width = Texture.Width;
            Height = Texture.Height;
            Speed = 300f;
            SpriteFont = spriteFont;
            Graphics = graphics;
        }
        public static void HandleInput(KeyboardState kState, GameTime gameTime)
        {
          
            if (kState.IsKeyDown(Keys.D) && !IsPlayerOOB(new Vector2((Speed * (float)gameTime.ElapsedGameTime.TotalSeconds )+ Position.X, Position.Y)))
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kState.IsKeyDown(Keys.A) && !IsPlayerOOB( new Vector2(Position.X - (Speed * (float)gameTime.ElapsedGameTime.TotalSeconds), Position.Y)))
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kState.IsKeyDown(Keys.W) && !IsPlayerOOB(new Vector2(Position.X, Position.Y - (Speed * (float)gameTime.ElapsedGameTime.TotalSeconds))))
                Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kState.IsKeyDown(Keys.S) && !IsPlayerOOB(new Vector2(Position.X, Position.Y + (Speed * (float)gameTime.ElapsedGameTime.TotalSeconds))))
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.DrawString(SpriteFont, "X: " + Position.X, new Vector2(40, 40) + Position, Color.Black);
            spriteBatch.DrawString(SpriteFont, "Y: " + Position.Y, new Vector2(40, 60) + Position, Color.Black);
            spriteBatch.DrawString(SpriteFont, "X: " + Camera.Position.X, new Vector2(200, 40) + Position, Color.Black);
            spriteBatch.DrawString(SpriteFont, "Y: " + Camera.Position.Y, new Vector2(200, 60) + Position, Color.Black);
        }
        private static bool IsPlayerOOB(Vector2 position)
        {
            if (position.X < 0 || position.Y < 0|| position.X +  Width > Camera.Boundraies.X * Camera.Zoom || position.Y + Height> Camera.Boundraies.Y * Camera.Zoom)
                return true;
            return false;
        }
    }
}
