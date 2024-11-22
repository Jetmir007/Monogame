﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;

namespace Monogame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    SpriteFont fontScore;

    Rectangle paddleLeft = new Rectangle(10, 200, 20, 100);

    Rectangle paddleRight = new Rectangle(770, 200, 20, 100);

    Rectangle ball = new Rectangle(390, 230, 20, 20);

    float velocityX = 3;

    float velocityY = 3;

    int scoreLeftPlayer = 0;

    int scoreRightPlayer = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        pixel = Content.Load<Texture2D>(assetName: "pixel");
        fontScore = Content.Load<SpriteFont>(assetName: "Scores");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W) && paddleLeft.Y > 0){
                paddleLeft.Y-=5;
            }
            if(kState.IsKeyDown(Keys.S) && paddleLeft.Y + paddleLeft.Height < 480){
                paddleLeft.Y+=5;
            }

            if(kState.IsKeyDown(Keys.Up) && paddleRight.Y > 0){
                paddleRight.Y-=5;
            }
            if(kState.IsKeyDown(Keys.Down) && paddleRight.Y + paddleRight.Height < 480){
                paddleRight.Y+=5;
            }

            ball.Y += (int)velocityY;
            ball.X += (int)velocityX;
            if(ball.Intersects(paddleRight) || ball.Intersects(paddleLeft)){
                velocityX *= -1.1f;
                velocityY *= 1.1f;
            }
            if(ball.Y <= 0 || ball.Y + ball.Height >= 480){
                velocityY *= -1;
            }

            if(ball.X <= 0 || ball.X + ball.Width >= 800){
                ball.X = 390;
                ball.Y = 230;
                velocityX = 3;
                velocityY = 3;
            }
            
            



        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);



        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontScore, scoreLeftPlayer.ToString(), new Vector2(40, 10), Color.DarkOrange);
        _spriteBatch.DrawString(fontScore, scoreRightPlayer.ToString(), new Vector2(720, 10), Color.DarkOrange);

        _spriteBatch.Draw(pixel, paddleLeft, Color.DeepPink);
        _spriteBatch.Draw(pixel, paddleRight, Color.DarkBlue);
        _spriteBatch.Draw(pixel, ball, Color.Red);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
