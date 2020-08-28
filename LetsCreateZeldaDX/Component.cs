using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX
{
    /// <summary>
    /// Componente esencial para la creación de otros tipos de componentes para los BaseObject.
    /// Se usa heredando esta clase.
    /// </summary>
    public abstract class Component
    {
        private BaseObject _baseObject;
        public abstract ComponentType ComponentType { get; }

        public void Initialize(BaseObject baseObject)
        {
            _baseObject = baseObject;
        }

        public int GetOwnerId()
        {
            return _baseObject.Id;
        }

        public void RemoveMe()
        {
            _baseObject.RemoveComponent(this);
        }

        /// <summary>
        /// Comprueba si el BaseObject contiene dicho componente y lo devuelve.
        /// </summary>
        /// <typeparam name="TComponentType">El componente que se le indique.</typeparam>
        /// <param name="componentType">Nombre identificador del componente.</param>
        /// <returns>Si el BaseObject contiene ese componente.</returns>
        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _baseObject == null ? null : _baseObject.GetComponent<TComponentType>(componentType);
        }

        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
