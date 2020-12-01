using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameNauka2
{
    public class Object
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public Object(Texture2D texture, Vector2 position)
        {
            Position = position;
            Texture = texture;
            Height = Texture.Height;
            Width = Texture.Width;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Camera.IsObjectInScene(Position, Width, Height))
                spriteBatch.Draw(Texture, Position, Color.White);
            //else
            //    spriteBatch.Draw(Texture, Player.Position, Color.White);
        }
        public bool IsPlayerCollidingWithObject(Vector2 PlayerPositionToBe)
        {
            Rectangle Rect1 = new Rectangle((int)PlayerPositionToBe.X, (int)PlayerPositionToBe.Y, (int)Player.Width, (int)Player.Height);
            Rectangle Rect2 = new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height);
            if (Rect1.Intersects(Rect2))
                return true;
            return false;
        }



}
}
