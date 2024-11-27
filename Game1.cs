using Microsoft.Xna.Framework;
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


    Ball ball;

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


        ball = new Ball(pixel);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W) && paddleLeft.Y > 0){
                paddleLeft.Y-=10;
            }
            if(kState.IsKeyDown(Keys.S) && paddleLeft.Y + paddleLeft.Height < 480){
                paddleLeft.Y+=10;
            }
           

            if(kState.IsKeyDown(Keys.Up) && paddleRight.Y > 0){
                paddleRight.Y-=10;
            }
            if(kState.IsKeyDown(Keys.Down) && paddleRight.Y + paddleRight.Height < 480){
                paddleRight.Y+=10;
            }

            
            ball.Update();
            

            if(ball.Rectangle.X <= 0){
                ball.Reset();
                scoreRightPlayer++;
            }

            else if(ball.Rectangle.X + ball.Rectangle.Width >=800){
                ball.Reset();
                scoreLeftPlayer++;
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
        ball.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
