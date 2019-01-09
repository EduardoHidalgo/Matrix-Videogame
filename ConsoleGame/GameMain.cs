using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ConsoleGame
{
    public class GameMain : Game
    {
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;

        SpriteFont Font;
        Vector2 Position;

        Ejemplo.Loop loop;

        

        public GameMain()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
            Position = new Vector2(100, 10);
            loop.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            loop = new Ejemplo.Loop(this, SpriteBatch);
            Font = Content.Load<SpriteFont>("Console24"); ////////////

            loop.LoadContent();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Position.Y += 1;
            loop.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);

            SpriteBatch.Begin();
            SpriteBatch.DrawString(Font, "Hola Mundo", Position, Color.Blue); //////////////
            loop.Draw();
            SpriteBatch.End();
        }
    }
}
