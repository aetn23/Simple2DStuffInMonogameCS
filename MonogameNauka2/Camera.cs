using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MonogameNauka2
{
    public static class Camera
    {
        static Camera()
        {
            CameraMoveSpeed = new Vector2(300.0f, 300.0f);
            Zoom = 1.0f;
            Rotation = 0;
            RotationSpeed = 0.5f;
            ZoomSpeed = 0.5f;
           
            CameraTrackingRespondRane = 0.3f;
        }
        internal static Vector2 Position { get; private set; }
        public static float Zoom { get; private set; }
        public static float RotationSpeed {get; private set;}
        public static float ZoomSpeed {get; private set;}
        private static float Rotation { get; set; }
        private static Vector2 CameraMoveSpeed { get; set; }
        public static Vector2 Boundraies { get; set; }
        public static GameTime GameTime { get; set; }
        private static float CameraTrackingRespondRane;
        public static GraphicsDeviceManager Graphics { get; set; }

        public static void CameraInput(KeyboardState kState)
        {
            if (kState.IsKeyDown(Keys.Up) && !IsCameraOutOfBoundaries(new Vector2(Position.X, Position.Y-(CameraMoveSpeed.Y *(float)GameTime.ElapsedGameTime.TotalSeconds))) )
                ChangeCameraPos(new Vector2(0, -CameraMoveSpeed.Y));
            else if (kState.IsKeyDown(Keys.Down) && !IsCameraOutOfBoundaries(new Vector2(Position.X, Position.Y + (CameraMoveSpeed.Y* (float)GameTime.ElapsedGameTime.TotalSeconds))))
                ChangeCameraPos(new Vector2(0, CameraMoveSpeed.Y));
            if (kState.IsKeyDown(Keys.Right) && !IsCameraOutOfBoundaries(new Vector2(Position.X + (CameraMoveSpeed.X* (float)GameTime.ElapsedGameTime.TotalSeconds), Position.Y)))
                 ChangeCameraPos(new Vector2(CameraMoveSpeed.X, 0));
            else if (kState.IsKeyDown(Keys.Left) && !IsCameraOutOfBoundaries(new Vector2(Position.X - (CameraMoveSpeed.X* (float)GameTime.ElapsedGameTime.TotalSeconds), Position.Y)))
                ChangeCameraPos(new Vector2(-CameraMoveSpeed.X, 0));

            if (kState.IsKeyDown(Keys.Q))
            {
                AdjustZoom(ZoomSpeed);
                if (IsCameraOutOfBoundaries(Position))
                    AdjustZoom(-ZoomSpeed);
            }
            else if (kState.IsKeyDown(Keys.E))
            {
                AdjustZoom(-ZoomSpeed);
                if (IsCameraOutOfBoundaries(Position))
                    AdjustZoom(ZoomSpeed);
            }

            if (kState.IsKeyDown(Keys.Z))
                AdjustRotation(RotationSpeed);
            else if (kState.IsKeyDown(Keys.X))
                AdjustRotation(-RotationSpeed);
            
        }
        public static bool IsCameraOutOfBoundaries(Vector2 newPos)
        {
            if (newPos.X < 0 || newPos.X + (Graphics.PreferredBackBufferWidth / Zoom) > Boundraies.X || newPos.Y + (Graphics.PreferredBackBufferHeight/Zoom) > Boundraies.Y || newPos.Y < 0)
                return true;
            return false;
        }
        public static bool IsObjectInScene(Vector2 position, float width, float height)
        {
            //Vector2 ltc = position;
            //Vector2 rtc = new Vector2(position.X + width, position.Y);
            //Vector2 lbc = new Vector2(position.X, position.Y + height);
            //Vector2 rbc = new Vector2(position.X + width, position.Y+height);
            Rectangle rctl2 = new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height);          
            Rectangle rctl1 = new Rectangle((int)Position.X, (int)Position.Y,(int)(Graphics.PreferredBackBufferWidth / Zoom), (int)(Graphics.PreferredBackBufferHeight / Zoom));
            if (rctl1.Intersects(rctl2))
                return true;
            //if ((ltc.X > Position.X && ltc.X <= Position.X + (graphics.PreferredBackBufferWidth / Zoom))
            //    && (ltc.Y > Position.Y && ltc.Y <= Position.Y + (graphics.PreferredBackBufferHeight / Zoom))
            //     || (rtc.X > Position.X && rtc.X <= Position.X + (graphics.PreferredBackBufferWidth / Zoom))
            //    && (rtc.Y > Position.Y && rtc.Y <= Position.Y + (graphics.PreferredBackBufferHeight / Zoom))
            //    || (lbc.X > Position.X && lbc.X <= Position.X + (graphics.PreferredBackBufferWidth / Zoom))
            //    && (lbc.Y > Position.Y && lbc.Y <= Position.Y + (graphics.PreferredBackBufferHeight / Zoom))
            //    || (rbc.X > Position.X && rbc.X <= Position.X + (graphics.PreferredBackBufferWidth / Zoom))
            //    && (rbc.Y > Position.Y && rbc.Y <= Position.Y + (graphics.PreferredBackBufferHeight / Zoom)))
            //        return true;
        
    
            return false;
        }
        public static void AdjustZoom(float value)
        {
            Zoom += value * (float)GameTime.ElapsedGameTime.TotalSeconds;
            Zoom = MathHelper.Clamp(Zoom, 0.5f, 10.0f);
        }   
        public static void AdjustRotation(float value)
        {
            Rotation = value*(float)GameTime.ElapsedGameTime.TotalSeconds;
            
        }
        private static void ChangeCameraPos(Vector2 value)
        {
            if (!IsCameraOutOfBoundaries((value * (float)GameTime.ElapsedGameTime.TotalSeconds) + Position) )
                Position += value * (float)GameTime.ElapsedGameTime.TotalSeconds ;
        }
        public static void FollowThePlayerMode()
        {
            Vector2 PlayerPosition;
            PlayerPosition = Player.GetPosition();
            if(Position.X + (Graphics.PreferredBackBufferWidth /Zoom)- PlayerPosition.X < CameraTrackingRespondRane * Graphics.PreferredBackBufferWidth / Zoom  )
            {
                ChangeCameraPos(new Vector2(CameraMoveSpeed.X, 0));
                //Position = new Vector2(0, 0);
            }
            else if (PlayerPosition.X - Position.X  < Graphics.PreferredBackBufferWidth * CameraTrackingRespondRane / Zoom)
            {
                ChangeCameraPos(new Vector2(-CameraMoveSpeed.X, 0));
                //Position = new Vector2(0, 0);
            }
            if (Position.Y + (Graphics.PreferredBackBufferHeight / Zoom) - PlayerPosition.Y < CameraTrackingRespondRane * Graphics.PreferredBackBufferHeight / Zoom)
            {
                ChangeCameraPos(new Vector2(0, CameraMoveSpeed.Y));
                //Position = new Vector2(0, 0);
            }
            else if (PlayerPosition.Y - Position.Y < Graphics.PreferredBackBufferHeight * CameraTrackingRespondRane / Zoom)
            {
                ChangeCameraPos(new Vector2(0, -CameraMoveSpeed.Y));
                //Position = new Vector2(0, 0);
            }
        }
        public static Matrix CameraMatrix
        {
            get
            {
                return Matrix.CreateTranslation((int)-Position.X, (int)-Position.Y, 0) * Matrix.CreateRotationZ(Rotation)*Matrix.CreateScale(Zoom);
            }
        }
    }
}
        /* Nie wiem po co ten Viewport
        public Viewport CalcViewport(Vector2 windowsSize)
        {
            Viewport viewport = new Viewport();
            viewport.Width = (int)windowsSize.Y;
            viewport.Height = (int)windowsSize.X;
            return viewport;
        }
        */