using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Components
{
    public class Sprite : Component
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
            var animation = GetComponent<Animation>(ComponentType.Animation);

            if (animation != null)
            {
                spriteBatch.Draw(
                    texture
                    , new Rectangle((int)position.X, (int)position.Y, width, height)
                    , animation.TextureRectangle
                    , Color.White
                    );
            }
            else
            {
                spriteBatch.Draw(
                    texture
                    , new Rectangle((int)position.X, (int)position.Y, width, height)
                    , Color.White 
                    );
            }
        }

        public void Move(float x, float y)
        {
            position = new Vector2(position.X + x, position.Y + y);

            var animation = GetComponent<Animation>(ComponentType.Animation);

            if (animation == null)
            {
                return;
            }

            if (x > 0)
            {
                animation.ResetCounter(State.Walking, Direction.Right);
            }
            else if (x < 0)
            {
                animation.ResetCounter(State.Walking, Direction.Left);
            }
            else if (y > 0)
            {
                animation.ResetCounter(State.Walking, Direction.Down);
            }
            else if (y < 0)
            {
                animation.ResetCounter(State.Walking, Direction.Up);
            }
        }
    }
}
