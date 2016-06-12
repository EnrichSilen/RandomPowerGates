using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace RandomPowerGates
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random rng = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //seting HD resolution of screen
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Global.instance.crosshair = new Crosshair();
            Global.instance.player = new Player(new Vector2(200, 200), 100);
            Global.instance.textManager = new TextManager(Content.Load<SpriteFont>("defaultTextFont"));
            Global.instance.moveManager = new MoveManager();
            Global.instance.mapManager = new MapManager();
            Global.instance.atackManager = new AtackManager();
            Global.instance.aiManager = new AiManager();

            Global.instance.mapManager.Initialize();

            Global.instance.windowWidth = Window.ClientBounds.Width;
            Global.instance.windowHeight = Window.ClientBounds.Height;
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
            


            //Player init and content loading
            Global.instance.player.LoadContent(Content, "Player/Player.png");
            Global.instance.crosshair.LoadContent(Content, "Player/Crosshair.png");
            //Walls init and content loading
            Global.instance.mapManager.LoadContent(Content);
            Global.instance.aiManager.LoadContent(Content);
            //Atacking
            Global.instance.projectileTexture = Content.Load<Texture2D>("Player/Projectile.png");
            //Texts
            Global.instance.textManager.addText("", new Vector2(1000, 100),Color.Green, "hp");


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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || Global.instance.player.hp == 0)
                Exit();

            

            Global.instance.moveManager.Move(Keyboard.GetState());
            Global.instance.player.Update(gameTime);

            Global.instance.atackManager.Update(gameTime);
            Global.instance.atackManager.Shoot(Content, Keyboard.GetState());
            Global.instance.aiManager.Update(gameTime);
            Global.instance.textManager.Update(gameTime);



#if DEBUG
                        Global.instance.crosshair.Update(gameTime, Mouse.GetState());
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Global.instance.aiManager.addAI(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
                Global.instance.aiManager.LoadContent(Content);
                Global.instance.npcs[Global.instance.npcs.Count - 1].speed = rng.Next(1, 4);
            }
#endif
            //Global.instance.projectileTexture = Content.Load<Texture2D>("Backgroun/non");


            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //drawing code starts here 
            Global.instance.mapManager.Draw(spriteBatch);
            Global.instance.atackManager.Draw(spriteBatch);
            Global.instance.textManager.Draw(spriteBatch);
            Global.instance.aiManager.Draw(spriteBatch);
            Global.instance.player.Draw(spriteBatch);

#if DEBUG
            Global.instance.crosshair.Draw(spriteBatch);
#endif
            //drawing code ends here

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
