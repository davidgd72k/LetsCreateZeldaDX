#region Using zone

#region System
using System;
using System.Collections.Generic;
#endregion

#region XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

#region LetsCreateZeldaDX
using LetsCreateZeldaDX.Components;
using LetsCreateZeldaDX.Components.Movement;
using LetsCreateZeldaDX.Manager;
using LetsCreateZeldaDX.Components.Enemies;
using LetsCreateZeldaDX.Map;
#endregion

#endregion

#region TODO List
// TODO: seguir del vídeo Parte 8 desde el min. 05:37.
#endregion

namespace LetsCreateZeldaDX
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /*
        private BaseObject _player;
        private BaseObject _testNPC;
        private BaseObject _testEnemy;
        */
        private ManagerInput _managerInput;
        private ManagerMap _managerMap;
        private ManagerCamera _managerCamera;
        private Entities _entities;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferWidth = 160;
            this.graphics.PreferredBackBufferHeight = 128;            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {            
            _entities = new Entities();            
            _managerInput = new ManagerInput();
            _managerCamera = new ManagerCamera();
            _managerMap = new ManagerMap("test", _managerCamera);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            BaseObject player = new BaseObject();
            player.AddComponent(new Sprite(Content.Load<Texture2D>("Sprites/link_full"), 16, 16, new Vector2(50, 60)));
            player.AddComponent(new PlayerInput());
            player.AddComponent(new Animation(16, 16));
            player.AddComponent(new Collision(_managerMap));
            player.AddComponent(new Camera(_managerCamera));

            BaseObject testNPC = new BaseObject();
            testNPC.AddComponent(new Sprite(Content.Load<Texture2D>("Sprites/Marin"), 16, 16, new Vector2(60, 20)));
            testNPC.AddComponent(new AIMovementRandom(200));
            testNPC.AddComponent(new Animation(16, 16));
            testNPC.AddComponent(new Collision(_managerMap));
            testNPC.AddComponent(new Camera(_managerCamera));

            BaseObject testEnemy = new BaseObject();
            testEnemy.AddComponent(new Sprite(Content.Load<Texture2D>("Sprites/Octorok"), 16, 16, new Vector2(80, 20)));
            testEnemy.AddComponent(new AIMovementRandom(1000, 0.5f));
            testEnemy.AddComponent(new Animation(16, 16));
            testEnemy.AddComponent(new Collision(_managerMap));
            testEnemy.AddComponent(new Octorok(player, Content.Load<Texture2D>("Sprites/Octorok_bullet"), _managerMap));
            testEnemy.AddComponent(new Camera(_managerCamera));

            _entities.AddEntity(player);
            _entities.AddEntity(testNPC);
            _entities.AddEntity(testEnemy);

            _managerMap.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            double realGameTime = gameTime.ElapsedGameTime.Milliseconds;

            _managerInput.Update(realGameTime);
            _managerCamera.Update(realGameTime);

            _entities.Update(realGameTime);     

            _managerMap.Update(realGameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(192, 207, 161));

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            _managerMap.Draw(spriteBatch);

            _entities.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
