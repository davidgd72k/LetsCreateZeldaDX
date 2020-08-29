using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreateZeldaDX.Components;
using LetsCreateZeldaDX.Components.Enemies;
using LetsCreateZeldaDX.Components.Movement;
using LetsCreateZeldaDX.Manager;
using LetsCreateZeldaDX.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZeldaDX.Screens
{
    public class ScreenWorld : Screen
    {
        private ManagerMap _managerMap;
        private ManagerCamera _managerCamera;
        private Entities _entities;

        public ScreenWorld(ManagerScreen managerScreen) : base(managerScreen)
        {
            _entities = new Entities();
            _managerCamera = new ManagerCamera();
            _managerMap = new ManagerMap("test", _managerCamera);
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            _managerMap.LoadContent(content);

            BaseObject player = new BaseObject();
            player.AddComponent(new Sprite(content.Load<Texture2D>("Sprites/link_full"), 16, 16, new Vector2(50, 60)));
            player.AddComponent(new PlayerInput());
            player.AddComponent(new Animation(16, 16));
            player.AddComponent(new Collision(_managerMap));
            player.AddComponent(new Camera(_managerCamera));

            BaseObject testNPC = new BaseObject();
            testNPC.AddComponent(new Sprite(content.Load<Texture2D>("Sprites/Marin"), 16, 16, new Vector2(60, 20)));
            testNPC.AddComponent(new AIMovementRandom(200));
            testNPC.AddComponent(new Animation(16, 16));
            testNPC.AddComponent(new Collision(_managerMap));
            testNPC.AddComponent(new Camera(_managerCamera));

            BaseObject testEnemy = new BaseObject();
            testEnemy.AddComponent(new Sprite(content.Load<Texture2D>("Sprites/Octorok"), 16, 16, new Vector2(80, 20)));
            testEnemy.AddComponent(new AIMovementRandom(1000, 0.5f));
            testEnemy.AddComponent(new Animation(16, 16));
            testEnemy.AddComponent(new Collision(_managerMap));
            testEnemy.AddComponent(new Octorok(player, content.Load<Texture2D>("Sprites/Octorok_bullet"), _managerMap));
            testEnemy.AddComponent(new Camera(_managerCamera));

            _entities.AddEntity(player);
            _entities.AddEntity(testNPC);
            _entities.AddEntity(testEnemy);
        }

        public override void Update(double gameTime)
        {
            _entities.Update(gameTime);
            _managerMap.Update(gameTime);
            _managerCamera.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _managerMap.Draw(spriteBatch);
            _entities.Draw(spriteBatch);
        }
    }
}
