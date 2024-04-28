using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Texture2D ballTexture2;
        Vector2 ballPosition, ballPosition2;
        float ballSpeed;



        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight / 2);
            ballPosition2 = new Vector2(_graphics.PreferredBackBufferWidth * 3 / 4, _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            ballTexture = Content.Load<Texture2D>("ball1");
            ballTexture2 = Content.Load<Texture2D>("ball2");
        }


    static bool CheckCollision(Vector2 position1, Vector2 position2, Texture2D texture1, Texture2D texture2)
        {
           float distanceThreshold = texture1.Width / 3.33f + texture2.Width / 3.33f;
           if (Vector2.Distance(position1, position2) < distanceThreshold)
           {
           return true; // Collision occurred
           }
            return false; // No collision
        }

    protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            Vector2 previousBallPosition = ballPosition;
            Vector2 previousBallPosition2 = ballPosition2;


            var kstate = Keyboard.GetState();
            if (kstate.IsKeyUp(Keys.Up))
            {
                ballPosition.Y -= ballSpeed * 0;
                if(kstate.IsKeyDown(Keys.Up)) { 
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            if (kstate.IsKeyDown(Keys.W))
            {
                ballPosition2.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                ballPosition2.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                ballPosition2.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.D))
            {
                ballPosition2.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 4.75)
            {
                ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 4.75f;
            }

            else if (ballPosition.X < ballTexture.Width / 4.75)
            {
                ballPosition.X = ballTexture.Width / 4.75f;
            }

            if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 4.75)
            {
                ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 4.75f;
            }

            else if (ballPosition.Y < ballTexture.Height / 4.75)
            {
                ballPosition.Y = ballTexture.Height / 4.75f;
            }

            if (ballPosition2.X > _graphics.PreferredBackBufferWidth - ballTexture2.Width / 2.75)
            {
                ballPosition2.X = _graphics.PreferredBackBufferWidth - ballTexture2.Width / 2.75f;
            }

            else if (ballPosition2.X < ballTexture2.Width / 2.75)
            {
                ballPosition2.X = ballTexture2.Width / 2.75f;
            }

            if (ballPosition2.Y > _graphics.PreferredBackBufferHeight - ballTexture2.Height / 2.75)
            {
                ballPosition2.Y = _graphics.PreferredBackBufferHeight - ballTexture2.Height / 2.75f;
            }

            else if (ballPosition2.Y < ballTexture2.Height / 2.75)
            {
                ballPosition2.Y = ballTexture2.Height / 2.75f;
            }

            if(CheckCollision(ballPosition, ballPosition2, ballTexture, ballTexture2))
            {
                ballPosition = previousBallPosition;
                ballPosition2= previousBallPosition2;  
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, ballPosition, null, Color.White, 0f, new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.Draw(ballTexture2, ballPosition2, null, Color.White, 0f, new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}