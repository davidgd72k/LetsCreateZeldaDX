using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreateZeldaDX.Manager;
using LetsCreateZeldaDX.MyEventArgs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Screens
{
    public class ScreenStart : Screen
    {
        private Texture2D _image;

        public ScreenStart(ManagerScreen managerScreen) : base(managerScreen)
        {
            
        }

        private void ManagerInput_FireNewInput(object sender, NewInputEventArgs e)
        {
            if (e.Input == Input.Start)
            {
                ManagerScreen.LoadNewScreen(new ScreenWorld(ManagerScreen));
            }
        }       

        #region Main methods
        public override void Initialize()
        {
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
        }

        public override void Uninitialize()
        {
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
        }

        public override void LoadContent(ContentManager content)
        {
            _image = content.Load<Texture2D>("Backgrounds/ZeldaDX_title_screen");
        }

        public override void Update(double gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, new Rectangle(0, 0, 160, 128), Color.White);
        }
        #endregion
    }
}
