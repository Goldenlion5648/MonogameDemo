using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Demo4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont customFont;

        KeyboardState kb, oldkb;

        MouseState ms;

        Point mousePos;

        Color recColor;

        Character character1;
        int gameClock = 0;

        Character[,] board;

        int gridDimX = 10;
        int gridDimY = 5;

        int screenWidth = 1080;
        int screenHeight = 720;



        Rectangle rec1;
        Texture2D recTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferWidth = screenWidth;
            this.graphics.PreferredBackBufferHeight = screenHeight;

            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            rec1 = new Rectangle(100, 150, 240, 260);
            recTexture = Content.Load<Texture2D>("blankSquare");
            customFont = Content.Load<SpriteFont>("customFont");

            character1 = new Character(new Rectangle(400, 200, 50, 200), recTexture);

            board = new Character[gridDimY, gridDimX];

            for (int y = 0; y < gridDimY; y++)
            {
                for (int x = 0; x < gridDimX; x++)
                {
                    board[y,x] = new Character(new Rectangle(x* (screenWidth / gridDimX),
                        y * (screenHeight / gridDimY), (screenWidth / gridDimX),
                        (screenHeight / gridDimY)), recTexture);
                }
            }

            // TODO: use this.Content to load your game content here
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
            kb = Keyboard.GetState();
            ms = Mouse.GetState();

            mousePos = new Point(ms.X, ms.Y);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            movement();



            if(rec1.Contains(mousePos))
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    recColor = Color.Green;
                }
                else
                {
                recColor = Color.Blue;

                }
            }
            else
            {
                recColor = Color.Red;
            }

            //if (kb.IsKeyUp(Keys.T))
            //{
            //    rec1.Y += 4;
            //}

            if(kb.IsKeyDown(Keys.Space)&& oldkb.IsKeyUp(Keys.Space))
            {
                rec1.X += 100;
            }


            // TODO: Add your update logic here


            character1.health++;
            gameClock++;
            oldkb = kb;
            base.Update(gameTime);
        }

        private void movement()
        {
            if (kb.IsKeyDown(Keys.D) && gameClock % 6 == 0)
            {
                rec1.X += 4;
            }

            if (kb.IsKeyDown(Keys.A))
            {
                rec1.X -= 4;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //spriteBatch.Draw(recTexture, rec1, recColor);

            //spriteBatch.DrawString(customFont, "X: " + mousePos.X + " Y: " + mousePos.Y,
            //    new Vector2(5, 5), Color.Black);

            //spriteBatch.DrawString(customFont, "Health: " + character1.health,
            //    new Vector2(5, 100), Color.Black);


            //character1.drawCharacter(spriteBatch, Color.Fuchsia);

            for (int y = 0; y < gridDimY; y++)
            {
                for (int x = 0; x < gridDimX; x++)
                {
                    board[y, x].drawCharacter(spriteBatch, new Color(x * 50, y * 50, x * y * 10));
                }
            }
            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
