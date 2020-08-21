using LetsCreateZeldaDX.Components;
using LetsCreateZeldaDX.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateZeldaDX.Manager
{
    public class ManagerMap
    {
        private List<Tile> _tiles;
        private List<TileCollision> _tileCollisions;
        private string _mapName;
        private ManagerCamera _managerCamera;

        public ManagerMap(string mapName, ManagerCamera managerCamera)
        {
            _tiles = new List<Tile>();
            _tileCollisions = new List<TileCollision>();
            _mapName = mapName;
            _managerCamera = managerCamera;
        }

        public void LoadContent(ContentManager content)
        {
            var tiles = new List<Tile>();
            XMLSerialization.LoadXML(out tiles, string.Format("Content\\{0}_map.xml", _mapName));
            if (tiles != null)
            {
                _tiles = tiles;
                _tiles.Sort((n, i) => n.ZPos > i.ZPos ? 1 : 0);

                foreach (var tile in this._tiles)
                {
                    tile.LoadContent(content);
                    tile.ManagerCamera = _managerCamera;
                }
            }

            var tilesCollision = new List<TileCollision>();
            XMLSerialization.LoadXML(out tilesCollision, string.Format("Content\\{0}_map_collision.xml", _mapName));
            if (tilesCollision != null)
            {
                _tileCollisions = tilesCollision;
                _tileCollisions.ForEach(t => t.ManagerCamera = _managerCamera);
            }
        }

        public void Update(double gameTime)
        {
            foreach (var tile in _tiles)
            {
                tile.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in _tiles)
            {
                tile.Draw(spriteBatch);
            }
        }

        public bool CheckCollision(Rectangle rectangle)
        {
            return _tileCollisions.Any(tile => tile.Intersect(rectangle));
        }
    }
}
