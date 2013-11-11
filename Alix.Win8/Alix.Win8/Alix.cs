using Alix.Win8.Input;
using Alix.Win8.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace Alix.Win8
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Alix : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        public static int ScreenWidth;
        public static int ScreenHeight;
        const int PaddleOffset = 70;
        const float BallStartSpeed = 8f;
        const float KeyboardPaddleSpeed = 10f;
        const float Spin = 2.5f;
        Player player1;
        Player player2;
        Ball ball;
        SpriteFont retroFont;
        Texture2D middleTexture;

        public Alix()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            player1 = new Player();
            player2 = new Player();
            ball = new Ball();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player1.Texture = Content.Load<Texture2D>("Paddle");
            player1.Position = new Vector2(PaddleOffset, ScreenHeight / 2 - player1.Texture.Height / 2);

            player2.Texture = Content.Load<Texture2D>("Paddle");
            player2.Position = new Vector2(ScreenWidth - player2.Texture.Width - PaddleOffset, ScreenHeight / 2 - player2.Texture.Height / 2);

            ball.Texture = Content.Load<Texture2D>("Ball");
            ball.Launch(BallStartSpeed);

            retroFont = Content.Load<SpriteFont>("RetroFont");

            middleTexture = Content.Load<Texture2D>("Middle");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ball.Move(ball.Velocity);

            Vector2 player1Velocity = PlayerInput.GetKeyboardInputDirection(PlayerIndex.One) * KeyboardPaddleSpeed;
            Vector2 player2Velocity = PlayerInput.GetKeyboardInputDirection(PlayerIndex.Two) * KeyboardPaddleSpeed;

            player1.Move(player1Velocity);
            player2.Move(player2Velocity);

            Vector2 player1TouchVelocity;
            Vector2 player2TouchVelocity;

            PlayerInput.ProcessTouchInput(out player1TouchVelocity, out player2TouchVelocity);
            player1.Move(player1TouchVelocity);
            player2.Move(player2TouchVelocity);

            if (player1TouchVelocity.Y > 0f)
            {
                player1Velocity = player1TouchVelocity;
            }
            if (player2TouchVelocity.Y > 0f)
            {
                player2Velocity = player2TouchVelocity;
            }

            if (player1Velocity.Y != 0)
            {
                player1Velocity.Normalize();
            }
            if (player2Velocity.Y != 0)
            {
                player2Velocity.Normalize();
            }

            if (GameObject.CheckPaddleBallCollision(player1, ball))
            {
                ball.Velocity.X = Math.Abs(ball.Velocity.X);
                ball.Velocity += player1Velocity * Spin;
            }

            if (GameObject.CheckPaddleBallCollision(player2, ball))
            {
                ball.Velocity.X = -Math.Abs(ball.Velocity.X);
                ball.Velocity += player2Velocity * Spin;
            }

            if (ball.Position.X + ball.Texture.Width < 0)
            {
                ball.Launch(BallStartSpeed);
                player2.Score++;
            }
            if (ball.Position.X > ScreenWidth)
            {
                ball.Launch(BallStartSpeed);
                player1.Score++;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _spriteBatch.Draw(middleTexture, new Rectangle(ScreenWidth / 2 - middleTexture.Width / 2, 0, middleTexture.Width, ScreenHeight), null, Color.White);
            var scoreString = player1.Score + "    " + player2.Score;
            _spriteBatch.DrawString(retroFont, scoreString, new Vector2(ScreenWidth / 2 - retroFont.MeasureString(scoreString).X / 2, 0), Color.Cyan);
            player1.Draw(_spriteBatch);
            player2.Draw(_spriteBatch);
            ball.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
