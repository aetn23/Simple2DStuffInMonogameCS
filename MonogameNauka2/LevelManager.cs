using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace MonogameNauka2
{
    public class LevelManager
    {

        public int LevelLoaded { get; private set; }
        private IServiceProvider ServiceProvider;
        private GraphicsDeviceManager Graphics;
        private List<GenericLevelMethods> Levels;
        public LevelManager(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
        {
            ServiceProvider = serviceProvider;
            Graphics = graphics;
            Levels = new List<GenericLevelMethods>();
            Levels[0] = new Level1(serviceProvider, graphics);
            
        }
        public void LoadLevel(int levelToLoad)
        { 
            switch(levelToLoad)
            {
                case 1:
                    Level1 level = new Level1(ServiceProvider, Graphics);
                    break;

            }
        }
        public void LoadContent()
        {
            //level.LoadContent();
        }
        
    }
}
