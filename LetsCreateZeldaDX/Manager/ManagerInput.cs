using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreateZeldaDX.MyEventArgs;
using Microsoft.Xna.Framework.Input;

namespace LetsCreateZeldaDX.Manager
{
    public class ManagerInput
    {
        private KeyboardState keyState;
        private KeyboardState lastKeyState;
        private Keys lastKey;
        private static event EventHandler<NewInputEventArgs> _FireNewInput;
        private double counter;
        private static double cooldown;

        public static event EventHandler<NewInputEventArgs> FireNewInput
        {
            add { _FireNewInput += value; }
            remove { _FireNewInput -= value; }
        }

        public static bool ThrottleInput { get; set; }
        public static bool LockMovement { get; set; }

        public ManagerInput()
        {
            ThrottleInput = false;
            LockMovement = false;
            counter = 0;
        }

        public void Update(double gameTime)
        {
            if (cooldown > 0)
            {
                counter += gameTime;

                if (counter > gameTime)
                {
                    cooldown = 0;
                    counter = 0;
                }
                else
                {
                    return;
                }

                ComputerControlls(gameTime);
            }
        }

        public void ComputerControlls(double gameTime)
        {
            keyState = Keyboard.GetState();

            if (keyState.IsKeyUp(lastKey) && lastKey != Keys.None)
            {
                if (_FireNewInput != null)
                {
                    _FireNewInput(this, new NewInputEventArgs(Input.None));
                }
            }

            CheckKeyState(Keys.Left, Input.Left);
            CheckKeyState(Keys.Right, Input.Right);
            CheckKeyState(Keys.Up, Input.Up);
            CheckKeyState(Keys.Down, Input.Down);

            lastKeyState = keyState;
        }

        private void CheckKeyState(Keys key, Input fireInput)
        {
            if (keyState.IsKeyDown(key))
            {
                if (!ThrottleInput || (ThrottleInput && lastKeyState.IsKeyUp(key)))
                {
                    if (_FireNewInput != null)
                    {
                        _FireNewInput(this, new NewInputEventArgs(fireInput));
                        lastKey = key;
                    }
                }
            }
        }
    }
}
