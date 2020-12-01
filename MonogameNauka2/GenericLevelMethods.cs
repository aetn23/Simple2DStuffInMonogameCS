using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonogameNauka2
{
    public abstract class GenericLevelMethods
    {
        public void SetLevelBoundaries(float width, float height)
        {
            Camera.Boundraies = new Vector2(width, height);
        }
        public bool CheckCollision(GameTime gameTime, KeyboardState kState, List<Object>objects)
        {
            Vector2 tmp;
            tmp = Player.Position;
            if (kState.IsKeyDown(Keys.D))
                tmp.X += Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kState.IsKeyDown(Keys.A))
                tmp.X -= Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kState.IsKeyDown(Keys.W))
                tmp.Y -= Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kState.IsKeyDown(Keys.S))
                tmp.Y += Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int ln = objects.Count;
            for (int i = 0; i < ln; i++)
            {
                if (objects[i].IsPlayerCollidingWithObject(tmp))
                    return true;
            }

            return false;
        }
        public void GenericLevelUpdate(GameTime gameTime, KeyboardState kState, List<Object>objects)
        {
            Camera.GameTime = gameTime;
            Camera.CameraInput(kState);
            Camera.FollowThePlayerMode();
            if (!CheckCollision(gameTime, kState, objects))
                Player.HandleInput(kState, gameTime);
        }
    }
}
