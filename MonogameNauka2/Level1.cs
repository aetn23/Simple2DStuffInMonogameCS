using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MonogameNauka2
{
    public class Level1 : GenericLevelMethods
    {
       
        private ContentManager Content;
        private Texture2D RedB, BlueB, GreenB, WhiteB, TableO; //B - Background, O - object
        public List<Object> Objects { get; private set; }
        public Level1(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
        {
            Content = new ContentManager(serviceProvider, "Content");
            Objects = new List<Object>();
            LoadContent();
            SetLevelBoundaries(RedB.Width + BlueB.Width, BlueB.Height + RedB.Height);
            
        }

        private void LoadContent()
        {
            //Backgrounds, first - 1, last - n
            RedB = Content.Load<Texture2D>("RedB");
            BlueB = Content.Load<Texture2D>("BlueB");
            GreenB = Content.Load<Texture2D>("GreenB");
            WhiteB = Content.Load<Texture2D>("WhiteB");

            //Objects, ;-;
            TableO = Content.Load<Texture2D>("table");

            //Objects, initialzing, nomen omen, object class 
            for(int i =0; i < 100; i++)
                Objects.Add(new Object(TableO, new Vector2(30+ i * TableO.Width, 30 + i*TableO.Height)));
        }
        public void Update(GameTime gameTime, KeyboardState kState)
        {
            GenericLevelUpdate(gameTime, kState, Objects);
        }
        // <summary>
        // True if collide
        // </summary>
        
        public void Draw(SpriteBatch spriteBatch)
        {
            // DrawBackgrounds(spriteBatch, Player.Position);

            DrawBackgrounds(spriteBatch);
            DrawObjects(spriteBatch);

        }
        private void DrawObjects(SpriteBatch spriteBatch)
        {
            int ln = Objects.Count;
            for(int i= 0; i < ln;i++)
            {
                Objects[i].Draw(spriteBatch);
            }
        }
        private void DrawBackgrounds(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(WhiteB, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(RedB, new Vector2(1000, 1000), Color.White);
            spriteBatch.Draw(GreenB, new Vector2(0, 1000), Color.White);
            spriteBatch.Draw(BlueB, new Vector2(1000, 0), Color.White);
            
        }
    }
}
