using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Components
{
    public class Animation : Component
    {
        public override ComponentType ComponentType
        {
            get { return ComponentType.Animation; }
        }

        public Rectangle TextureRectangle { get; private set; }
        public Direction CurrentDirection;

        private int _width;
        private int _height;
        private State _currentState;
        private double _counter;
        private int _animationIndex;

        public Animation(int width, int height)
        {
            _width = width;
            _height = height;
            _counter = 0;
            _animationIndex = 0;
            _currentState = State.Standing;
            TextureRectangle = new Rectangle(0, 0, width, height);
        }

        public override void Update(double gameTime)
        {
            switch (_currentState)
            {
                case State.Walking:

                    _counter += gameTime;

                    if (_counter > 250)
                    {
                        ChangeState();
                        _counter = 0;
                    }

                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        private void ChangeState()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:

                    TextureRectangle = new Rectangle(_width * _animationIndex, _height, _width, _height);

                    break;

                case Direction.Down:

                    TextureRectangle = new Rectangle(_width * _animationIndex, 0, _width, _height);

                    break;

                case Direction.Left:

                    TextureRectangle = new Rectangle(_width * _animationIndex, _height * 2, _width, _height);

                    break;

                case Direction.Right:

                    TextureRectangle = new Rectangle(_width * _animationIndex, _height * 3, _width, _height);

                    break;
            }

            _animationIndex = _animationIndex == 0 ? 1 : 0;
            _currentState = State.Standing;
        }

        public void ResetCounter(State state, Direction direction)
        {
            if (CurrentDirection != direction)
            {
                _counter = 1000;
                _animationIndex = 0;
            }

            _currentState = state;
            CurrentDirection = direction;
        }
    }
}
