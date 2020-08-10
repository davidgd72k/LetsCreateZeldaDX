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
        public Direction currentDirection;

        private int width;
        private int height;
        private State currentState;
        private double counter;
        private int animationIndex;

        public Animation(int width, int height)
        {
            this.width = width;
            this.height = height;
            counter = 0;
            animationIndex = 0;
            currentState = State.Standing;
            TextureRectangle = new Rectangle(0, 0, width, height);
        }

        public override void Update(double gameTime)
        {
            switch (currentState)
            {
                case State.Walking:

                    counter += gameTime;

                    if (counter > 500)
                    {
                        ChangeState();
                        counter = 0;
                    }

                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        private void ChangeState()
        {
            switch (currentDirection)
            {
                case Direction.Up:

                    TextureRectangle = new Rectangle(width * animationIndex, height, width, height);

                    break;

                case Direction.Down:

                    TextureRectangle = new Rectangle(width * animationIndex, 0, width, height);

                    break;

                case Direction.Left:

                    TextureRectangle = new Rectangle(width * animationIndex, height * 2, width, height);

                    break;

                case Direction.Right:

                    TextureRectangle = new Rectangle(width * animationIndex, height * 3, width, height);

                    break;
            }

            animationIndex = animationIndex == 0 ? 1 : 0;
            currentState = State.Standing;
        }

        public void ResetCounter(State state, Direction direction)
        {
            if (currentDirection != direction)
            {
                counter = 1000;
                animationIndex = 0;
            }

            currentState = state;
            currentDirection = direction;
        }
    }
}
