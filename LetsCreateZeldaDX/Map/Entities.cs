using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX.Map
{
    public class Entities
    {
        private List<BaseObject> _entities;

        public Entities()
        {
            _entities = new List<BaseObject>();
        }

        public void AddEntity(BaseObject newObject)
        {
            _entities.Add(newObject);
        }

        public void Update(double gameTime)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                BaseObject baseObject = _entities[i];
                baseObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                BaseObject baseObject = _entities[i];
                baseObject.Draw(spriteBatch);
            }
        }
    }
}
