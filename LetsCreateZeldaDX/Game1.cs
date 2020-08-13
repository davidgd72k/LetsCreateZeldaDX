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
#endregion

#endregion

#region TODO List

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

        private BaseObject player;
        private BaseObject testNPC;
        private ManagerInput managerInput;
        private ManagerMap managerMap;

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
            player = new BaseObject();
            testNPC = new BaseObject();
            managerInput = new ManagerInput();
            managerMap = new ManagerMap("test");
            
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
            
            player.AddComponent(new Sprite(Content.Load<Texture2D>("Spritesheet/link_full"), 16, 16, new Vector2(50, 60)));
            player.AddComponent(new PlayerInput());
            player.AddComponent(new Animation(16, 16));
            player.AddComponent(new Collision(managerMap));

            testNPC.AddComponent(new Sprite(Content.Load<Texture2D>("Spritesheet/Marin"), 16, 16, new Vector2(60, 20)));
            testNPC.AddComponent(new AIMovementRandom(200));
            testNPC.AddComponent(new Animation(16, 16));
            testNPC.AddComponent(new Collision(managerMap));

            managerMap.LoadContent(Content);
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

            managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);
            player.Update(gameTime.ElapsedGameTime.Milliseconds);
            testNPC.Update(gameTime.ElapsedGameTime.Milliseconds);
            managerMap.Update(gameTime.ElapsedGameTime.Milliseconds);

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

            managerMap.Draw(spriteBatch);
            player.Draw(spriteBatch);
            testNPC.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
