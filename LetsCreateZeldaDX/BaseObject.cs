using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX
{
    class BaseObject
    {
        public int Id { get; set; }
        private readonly List<Component> components;

        public BaseObject()
        {
            components = new List<Component>();
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return components.Find(c => c.ComponentType == componentType) as TComponentType;
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
            component.Initialize(this);
        }

        public void AddComponent(List<Component> components)
        {
            components.AddRange(components);
            foreach (var component in components)
            {
                component.Initialize(this);
            }
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }

        public void Update(double gameTime)
        {
            foreach(var component in components)
            {
                component.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
