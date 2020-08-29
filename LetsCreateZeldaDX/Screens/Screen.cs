using LetsCreateZeldaDX.Manager;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX.Screens
{
    public abstract class Screen
    {
        protected ManagerScreen _managerScreen;

        public Screen(ManagerScreen managerScreen)
        {
            _managerScreen = managerScreen;
        }

        public virtual void Initialize() { }
        public virtual void Uninitialize() { }

        public abstract void LoadContent(ContentManager content);
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
