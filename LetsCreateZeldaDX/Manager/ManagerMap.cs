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
        private List<Tile> tiles;
        private List<TileCollision> tileCollisions;
        private string mapName;

        public ManagerMap(string mapName)
        {
            tiles = new List<Tile>();
            tileCollisions = new List<TileCollision>();
            this.mapName = mapName;
        }

        public void LoadContent(ContentManager content)
        {
            var tiles = new List<Tile>();
            XMLSerialization.LoadXML(out tiles, string.Format("Content\\{0}_map.xml", mapName));
            if (tiles != null)
            {
                this.tiles = tiles;
                this.tiles.Sort((n, i) => n.ZPos > i.ZPos ? 1 : 0);

                foreach (var tile in this.tiles)
                {
                    tile.LoadContent(content);
                }
            }

            var tilesCollision = new List<TileCollision>();
            XMLSerialization.LoadXML(out tilesCollision, string.Format("Content\\{0}_map_collision.xml", mapName));
            if (tilesCollision != null)
            {
                this.tileCollisions = tilesCollision;
            }
        }

        public void Update(double gameTime)
        {
            foreach (var tile in this.tiles)
            {
                tile.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in this.tiles)
            {
                tile.Draw(spriteBatch);
            }
        }

        public bool CheckCollision(Rectangle rectangle)
        {
            return this.tileCollisions.Any(tile => tile.Intersect(rectangle));
        }
    }
}
