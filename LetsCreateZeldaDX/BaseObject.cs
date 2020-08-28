using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX
{
    /// <summary>
    /// Objeto base que contiene y utiliza componentes.
    /// </summary>
    public class BaseObject
    {
        public int Id { get; set; }
        private readonly List<Component> _components;

        public BaseObject()
        {
            _components = new List<Component>();
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _components.Find(c => c.ComponentType == componentType) as TComponentType;
        }

        public void AddComponent(Component component)
        {
            _components.Add(component);
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
            _components.Remove(component);
        }

        public void Update(double gameTime)
        {   
            // Se usa un bucle FOR por ser más flexible en el tema de modificar la lista.
            for (int i = 0; i < _components.Count; i++)
            {
                var component = _components[i];
                component.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < _components.Count; i++)
            {
                var component = _components[i];
                component.Draw(spriteBatch);
            }
        }
    }
}
