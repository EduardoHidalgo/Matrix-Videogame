using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleGame
{
    class GameLoop
    {
        SpriteBatch SpriteBatch;
        Game Game;
        ObjectLister ObjectLister;

        public GameLoop(SpriteBatch spriteBatch, Game game)
        {
            SpriteBatch = spriteBatch;
            Game = game;
            ObjectLister = new ObjectLister(SpriteBatch, Game);
        }

        public void Initialize()
        {
            ObjectLister.Initialize();
        }

        public void LoadContent()
        {
            ObjectLister.LoadContent();
        }

        public void UnloadContent()
        {
            ObjectLister.UnloadContent();
        }

        public void Update()
        {
            ObjectLister.Update();
        }

        public void Draw()
        {
            ObjectLister.Draw();
        }
    }
}
