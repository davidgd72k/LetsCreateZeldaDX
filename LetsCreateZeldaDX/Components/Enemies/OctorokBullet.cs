using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Components.Enemies
{
    public class OctorokBullet
    {
        private Sprite sprite;
        private BaseObject player;
        private Collision collision;
        private Direction direction;
        private float speed; 

        public bool Dead { get; private set; }

        public OctorokBullet(Sprite sprite, Collision collision, BaseObject player, Direction direction)
        {
            this.sprite = sprite;
            this.player = player;
            this.direction = direction;
            this.speed = 1.5f;
            this.collision = collision;
        }

        public void Update(double gameTime)
        {
            switch (direction)
            {
                case Direction.Up:

                    sprite.Move(0, speed * -1);

                    break;

                case Direction.Down:

                    sprite.Move(0, speed);

                    break;

                case Direction.Left:

                    sprite.Move(speed * - 1, 0);

                    break;

                case Direction.Right:

                    sprite.Move(speed, 0);

                    break;
            }

            if (collision.CheckCollision(new Rectangle((int)sprite.Position.X, (int)sprite.Position.Y, sprite.Width, sprite.Height), false))
            {
                Dead = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
