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
    public class Collision : Component
    {
        #region Variables
        private ManagerMap managerMap;
        #endregion

        #region Propiedades
        public override ComponentType ComponentType
        {
            get { return ComponentType.Collision; }
        }
        #endregion
        
        #region Constructores
        public Collision(ManagerMap managerMap)
        {
            this.managerMap = managerMap;
        }
        #endregion

        #region Main Methods
        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
        #endregion

        #region Other methods
        public bool CheckCollision(Rectangle rectangle, bool fixBox = true)
        {
            rectangle = new Rectangle(
                (int) (rectangle.X + (rectangle.Width * 0.4) / 2)
                , (int) (rectangle.Y + rectangle.Height * 0.5)
                , (int) (rectangle.Width * 0.6)
                , (int) (rectangle.Height * 0.5)
                );
            return managerMap.CheckCollision(rectangle);
        }
        #endregion
    }
}
