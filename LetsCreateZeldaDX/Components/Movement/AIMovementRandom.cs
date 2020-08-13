using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreateZeldaDX.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Components.Movement
{
    public class AIMovementRandom : Component
    {
        private Direction currentDirection;
        private readonly int frequency;
        private double counter;

        public override ComponentType ComponentType
        {
            get { return ComponentType.AIMovement; }
        }


        #region Constructores
        public AIMovementRandom(int frequency)
        {
            this.frequency = frequency;
            ChangeDirection();
        }
        #endregion
        
        #region Main methods
        public override void Update(double gameTime)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
            {
                return;
            }

            counter += gameTime;
            if (counter > frequency)
            {
                ChangeDirection();
            }

            var collision = GetComponent<Collision>(ComponentType.Collision);

            var x = 0f;
            var y = 0f;

            switch (currentDirection)
            {
                case Direction.Up:
                    y = -1.5f;
                    break;

                case Direction.Down:
                    y = 1.5f;
                    break;

                case Direction.Left:
                    x = -1.5f;
                    break;

                case Direction.Right:
                    x = 1.5f;
                    break;
                default:
                    return;
            }

            if (collision.CheckCollision(new Rectangle((int)(sprite.Position.X + x), (int)(sprite.Position.Y + y), sprite.Width, sprite.Height)))
            {
                ChangeDirection();
                return;
            }

            sprite.Move(x, y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
        #endregion

        #region Funcionamiento de la IA
        private void ChangeDirection()
        {
            counter = 0;
            currentDirection = (Direction)ManagerFunction.Random(0, 3);
        }
        #endregion
    }
}
