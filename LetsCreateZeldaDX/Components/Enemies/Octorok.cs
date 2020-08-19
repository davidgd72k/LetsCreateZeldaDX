using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreateZeldaDX.Manager;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Components.Enemies
{
    public class Octorok : Component
    {
        private BaseObject player;
        private List<OctorokBullet> bullets;
        private double counter;
        private int cooldown;
        private Texture2D bulletTexture;
        private ManagerMap map;

        public override ComponentType ComponentType
        {
            get { return ComponentType.EnemyOctorok; }
        }

        public Octorok(BaseObject player, Texture2D bulletTexture, ManagerMap map, int cooldown = 1000)
        {
            this.player = player;
            this.bullets = new List<OctorokBullet>();
            this.cooldown = cooldown;
            this.counter = 0;
            this.bulletTexture = bulletTexture;
            this.map = map;
        }

        public override void Update(double gameTime)
        {
            counter += gameTime;

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);

                if (bullets[i].Dead)
                {
                    bullets.RemoveAt(i);
                }
            }

            if (counter < cooldown)
            {
                return;
            }

            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            var playerSprite = player.GetComponent<Sprite>(ComponentType.Sprite);
            var animation = GetComponent<Animation>(ComponentType.Animation);
            if (sprite == null || animation == null || playerSprite == null)
            {
                return;
            }

            switch (animation.CurrentDirection)
            {
                case Direction.Up:

                    if (playerSprite.Position.Y < sprite.Position.Y)
                    {
                        NewBullet(Direction.Up);
                    }
                    
                    break;

                case Direction.Down:

                    if (playerSprite.Position.Y > sprite.Position.Y)
                    {
                        NewBullet(Direction.Down);
                    }

                    break;

                case Direction.Left:

                    if (playerSprite.Position.X < sprite.Position.X)
                    {
                        NewBullet(Direction.Left);
                    }

                    break;

                case Direction.Right:

                    if (playerSprite.Position.X > sprite.Position.X)
                    {
                        NewBullet(Direction.Right);
                    }

                    break;
            }

            counter = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var octorokBullet in bullets)
            {
                octorokBullet.Draw(spriteBatch);
            }
        }

        private void NewBullet(Direction direction)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            bullets.Add(new OctorokBullet(new Sprite(bulletTexture, 10, 10, sprite.Position), new Collision(map), player, direction));
        }
    }
}
