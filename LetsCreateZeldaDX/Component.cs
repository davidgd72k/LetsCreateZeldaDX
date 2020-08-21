﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX
{
    // TODO: poner descripción de QUE hace esta clase.
    /// <summary>
    /// 
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

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _baseObject == null ? null : _baseObject.GetComponent<TComponentType>(componentType);
        }

        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
