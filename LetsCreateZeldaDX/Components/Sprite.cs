using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Components
{
    class Sprite : Component
    {
        private Texture2D texture;
        private int width;
        private int height;
        private Vector2 position;

        public override ComponentType ComponentType
        {
            get { return ComponentType.Sprite; } 
        }

        public Sprite(Texture2D texture, int width, int height, Vector2 position)
        {
            this.texture = texture;
            this.width = width;
            this.height = height;
            this.position = position;
        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, width, height), Color.White );
        }
    }
}
