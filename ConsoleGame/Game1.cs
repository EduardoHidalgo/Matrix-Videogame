using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ConsoleGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;
        GameLoop GameLoop;

        //MEDIDAS DE PANTALLA Y POSICIÓN DE LA VENTANA
        int BufferX = 1200, BufferY = 700, PositionX = 20, PositionY = 20;

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //game configs
            Window.Position = new Point(PositionX, PositionY);
            Graphics.PreferredBackBufferWidth = BufferX;
            Graphics.PreferredBackBufferHeight = BufferY;
            Window.Title = "Antibodys vs Virus";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
            GameLoop.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            GameLoop = new GameLoop(SpriteBatch, this);
            GameLoop.LoadContent();
        }

        protected override void UnloadContent()
        {
            GameLoop.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

            GameLoop.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
            SpriteBatch.Begin();
            GameLoop.Draw();
            SpriteBatch.End();
        }
    }
}
