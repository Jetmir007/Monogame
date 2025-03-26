﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;

namespace Monogame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

<<<<<<< Updated upstream
    Texture2D pixel;
    SpriteFont fontScore;


    Paddle paddleLeft;

    Paddle paddleRight;

    Ball ball;

    int scoreLeftPlayer = 0;

    int scoreRightPlayer = 0;

=======
>>>>>>> Stashed changes
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferHeight = 1200;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

<<<<<<< Updated upstream
        pixel = Content.Load<Texture2D>(assetName: "pixel");
        fontScore = Content.Load<SpriteFont>(assetName: "Scores");

<<<<<<< HEAD
=======
>>>>>>> Stashed changes
=======

        ball = new Ball(pixel);
        paddleLeft = new Paddle(pixel, new Rectangle(10, 540, 20, 200), Keys.W, Keys.S);
        paddleRight = new Paddle(pixel, new Rectangle(1890, 200, 20, 200), Keys.Up, Keys.Down);

>>>>>>> c7b5dc989a8cbe53f3c0da3726a6a0df2fc3e9aa
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

<<<<<<< HEAD
<<<<<<< Updated upstream
            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W) && paddleLeft.Y > 0){
                paddleLeft.Y-=5;
=======
            paddleLeft.Update();

            paddleRight.Update();
            
            ball.Update();
            if(paddleLeft.Rectangle.Intersects(ball.Rectangle) || paddleRight.Rectangle.Intersects(ball.Rectangle)){
                ball.Bounce();
>>>>>>> c7b5dc989a8cbe53f3c0da3726a6a0df2fc3e9aa
            }
            
    
            if(ball.Rectangle.X <= 0){
                ball.Reset();
                scoreRightPlayer++;
            }

            else if(ball.Rectangle.X + ball.Rectangle.Width >=1920){
                ball.Reset();
                scoreLeftPlayer++;
            }
            
            
            



=======
>>>>>>> Stashed changes
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightSkyBlue);


        // TODO: Add your drawing code here
<<<<<<< Updated upstream
        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontScore, scoreLeftPlayer.ToString(), new Vector2(40, 10), Color.DarkOrange);
        _spriteBatch.DrawString(fontScore, scoreRightPlayer.ToString(), new Vector2(1840, 10), Color.DarkOrange);

        paddleLeft.Draw(_spriteBatch);
        paddleRight.Draw(_spriteBatch);
        ball.Draw(_spriteBatch);

        _spriteBatch.End();
=======

>>>>>>> Stashed changes
        base.Draw(gameTime);
    }
}
