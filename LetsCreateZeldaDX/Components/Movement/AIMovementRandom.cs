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
        private Direction _currentDirection;
        private readonly int _frequency;
        private double _counter;
        private float _speed;

        public override ComponentType ComponentType
        {
            get { return ComponentType.AIMovement; }
        }


        #region Constructores
        public AIMovementRandom(int frequency, float speed = 1.5f)
        {
            _frequency = frequency;
            _speed = speed;
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

            _counter += gameTime;
            if (_counter > _frequency)
            {
                ChangeDirection();
            }

            var collision = GetComponent<Collision>(ComponentType.Collision);

            var x = 0f;
            var y = 0f;

            switch (_currentDirection)
            {
                case Direction.Up:
                    y = _speed * -1;
                    break;

                case Direction.Down:
                    y = _speed;
                    break;

                case Direction.Left:
                    x = _speed * -1;
                    break;

                case Direction.Right:
                    x = _speed;
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
            _counter = 0;
            _currentDirection = (Direction)ManagerFunction.Random(0, 3);
        }
        #endregion
    }
}
