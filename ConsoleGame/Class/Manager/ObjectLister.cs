using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleGame
{
    class ObjectLister
    {
        SpriteBatch SpriteBatch;
        Game Game;
        InputHandler InputHandler;
        MatrixManager MatrixManager;

        public ObjectLister(SpriteBatch spriteBatch, Game game)
        {
            SpriteBatch = spriteBatch;
            Game = game;
            InputHandler = new InputHandler(SpriteBatch, Game);
            MatrixManager = new MatrixManager(SpriteBatch, Game);

        }

        public void Initialize()
        {
            // InputHandler.Initialize();
            MatrixManager.Initialize();
        }

        public void LoadContent()
        {
            //  InputHandler.LoadContent();
            MatrixManager.LoadContent();
        }

        public void UnloadContent()
        {
            //  InputHandler.UnloadContent();
            MatrixManager.UnloadContent();
        }

        public void Update()
        {
            //  InputHandler.Update();
            MatrixManager.Update();
        }

        public void Draw()
        {
            //  InputHandler.Draw();
            MatrixManager.Draw();
        }
    }
}
