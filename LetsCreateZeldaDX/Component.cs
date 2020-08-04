using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX
{
    abstract class Component
    {
        private BaseObject baseObject;
        public abstract ComponentType ComponentType { get; }

        public void Initialize(BaseObject baseObject)
        {
            this.baseObject = baseObject;
        }

        public int GetOwnerId()
        {
            return baseObject.Id;
        }

        public void RemoveMe()
        {
            baseObject.RemoveComponent(this);
        }

        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
