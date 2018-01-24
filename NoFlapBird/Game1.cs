using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace NoFlapBird
{
    //Våra Gamestates
    enum GamesStates { StartScreen, InGame}


    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GamesStates currentGameState;
        Player player;

        //FRÅGA 9: Hur ska vi göra om listan ska kunna innehålla objekt av både NormalPipe och UpsideDownPipe?
        //Ändra typ till List<Pipe>, alltså basklassens typ
        List<NormalPipe> pipes = new List<NormalPipe>();

        Texture2D pipeTexture, startScreenTexture;
        
        public static Vector2 gravity;
//        Song christmasMusic;

        Random rng = new Random();

        double countdown = 1000;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.ApplyChanges();

            gravity = new Vector2(0, 0.4f);

            currentGameState = GamesStates.StartScreen;

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

            Texture2D playerSprite = Content.Load<Texture2D>("flappybird");
            pipeTexture = Content.Load<Texture2D>("flappypipe");
            startScreenTexture = Content.Load<Texture2D>("noflapbird_logo");

//            christmasMusic = Content.Load<Song>("LetItSnow");

            player = new Player(playerSprite);

//            MediaPlayer.Play(christmasMusic);
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

            //Om spelet är i gång
            if (currentGameState == GamesStates.InGame)
            {
                //FRÅGA 1: Hur fungerar den här uträkningen?
                //countdown minskas med tiden det gått sedan förra uppdateringen
                countdown -= gameTime.ElapsedGameTime.TotalMilliseconds;

                if (countdown <= 0)
                {
                    Vector2 newVelocity = new Vector2();

                    //FRÅGA 3: Varför används NextDouble() i stället för Next()?
                    //För att kunna få "alla" tal, inte bara heltal
                    newVelocity.X = (float)(-10 * rng.NextDouble());
                    newVelocity.Y = -(float)rng.NextDouble();

                    pipes.Add(new NormalPipe(pipeTexture, newVelocity));
                    //FRÅGA 2: Vad kan vi göra här med countdown för att inte få så många pipes?
                    //Återställ countdown, t ex 
                    //countdown = 1000;
                }

                player.Update();

                //FRÅGA 8: Hur fungerar en foreach-sats?
                //Den loopar igenom varje objekt i en lista eller array
                foreach (NormalPipe pipe in pipes)
                {
                    pipe.Update();
                    if (pipe.Hitbox.Intersects(player.Hitbox))
                    {
                        Exit();
                    }

                    //FRÅGA 10: Hur skulle vi kunna ta bort alla pipes som har passerat vänsterkanten av skärmen?
                    //Undersöka positionens x-komposant. Om den är "tillräckligt negativ", ta bort den
                    //ur listan.
                }
            }

            //Om titelskärmen visas
            else
            {
                if(Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    //STARTA SPELET!!1
                    currentGameState = GamesStates.InGame;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            //Om spelet är i gång
            if (currentGameState == GamesStates.InGame)
            {
                //Rita ut spelaren!
                spriteBatch.Begin();
                player.Draw(spriteBatch);
                foreach (NormalPipe pipe in pipes)
                {
                    pipe.Draw(spriteBatch);

                }
                spriteBatch.End();
            }

            //Om spelet inte är i gång, visa titelskärmen
            else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(startScreenTexture, Vector2.Zero, Color.White);
                spriteBatch.End();
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
