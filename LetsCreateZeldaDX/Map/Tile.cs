using LetsCreateZeldaDX.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX.Map
{
    public class Tile
    {
        private const int Width = 16;
        private const int Height = 16;

        public int XPos { get; set; }
        public int YPos { get; set; }
        public int ZPos { get; set; }

        public List<TileFrame> TileFrames { get; set; }
        public int AnimationSpeed { get; set; }

        public string TextureName { get; set; }

        protected Texture2D _texture;
        public ManagerCamera ManagerCamera { get; set; }
        private double _counter;
        private int _animationIndex;

        public Vector2 Position
        {
            get { return new Vector2(XPos * 16, YPos * 16); }
        }

        public Tile()
        {

        }

        public Tile(int xPos, int yPos, int zPos, List<TileFrame> tileFrames, int animationSpeed, string textureName, ManagerCamera managerCamera)
        {
            XPos = xPos;
            YPos = yPos;
            ZPos = zPos;

            TileFrames = tileFrames;
            AnimationSpeed = animationSpeed;
            _animationIndex = 0;

            TextureName = textureName;

            ManagerCamera = managerCamera;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(TextureName);
        }

        public void Update(double gameTime)
        {
            if (TileFrames.Count <= 1)
            {
                return;
            }

            _counter += gameTime;
            if (_counter > AnimationSpeed)
            {
                _counter = 0;
                _animationIndex++;
                if (_animationIndex >= TileFrames.Count)
                {
                    _animationIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var position = ManagerCamera.WorldToScreenPosition(Position);

            if (ManagerCamera.InScreenCheck(Position))
            {
                spriteBatch.Draw(
                    _texture
                    , new Rectangle((int)position.X, (int)position.Y, Width, Height)
                    , new Rectangle(TileFrames[_animationIndex].TextureXPos * Width, TileFrames[_animationIndex].TextureYPos * Height, Width, Height)
                    , Color.White
                    );
            }
        }
    }
}
