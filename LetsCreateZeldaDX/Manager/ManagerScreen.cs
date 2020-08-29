using LetsCreateZeldaDX.Screens;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX.Manager
{
    public class ManagerScreen
    {
        private Screen _currentScreen;
        private Screen _lastScreen;
        private ContentManager _content;

        public ManagerScreen(ContentManager content)
        {
            _content = content;
        }

        public void LoadNewScreen(Screen screen)
        {
            _lastScreen = _currentScreen;

            if (_lastScreen != null)
            {
                _lastScreen.Uninitialize();
            }

            _currentScreen = screen;
            _currentScreen.Initialize();
            _currentScreen.LoadContent(_content);
        }

        public void GoBackOneScreen()
        {
            if (_lastScreen == null)
            {
                return;
            }

            _currentScreen.Uninitialize();
            _currentScreen = _lastScreen;
            _currentScreen.Initialize();
        }

        public void Update(double gameTime)
        {
            _currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(spriteBatch);
        }
    }
}
