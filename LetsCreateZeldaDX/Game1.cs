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
using LetsCreateZeldaDX.Screens;
#endregion

#endregion

#region TODO List
// TODO: seguir del vídeo Parte 10 desde el min. 01:27.
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

        private ManagerInput _managerInput;
        private ManagerScreen _managerScreen;
        

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
            _managerInput = new ManagerInput();
            
            
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

            _managerScreen = new ManagerScreen(Content);
            _managerScreen.LoadNewScreen(new ScreenWorld(_managerScreen));
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
            _managerScreen.Update(realGameTime);

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

            _managerScreen.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
