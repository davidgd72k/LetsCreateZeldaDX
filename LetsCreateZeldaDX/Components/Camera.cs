using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreateZeldaDX.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Components
{
    public class Camera : Component
    {
        #region Variables
        private ManagerCamera _managerCamera;
        #endregion

        #region Propiedades
        public override ComponentType ComponentType
        {
            get { return ComponentType.Camera; }
        }
        #endregion

        #region Constructores
        public Camera(ManagerCamera camera)
        {
            _managerCamera = camera;
        }
        #endregion

        #region Main methods
        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
        #endregion

        public bool GetPosition(Vector2 position, out Vector2 newPosition)
        {
            newPosition = _managerCamera.WorldToScreenPosition(position);
            return _managerCamera.InScreenCheck(newPosition);
        }

        public void MoveCamera(Direction direction)
        {
            _managerCamera.Move(direction);
        }
    }
}
