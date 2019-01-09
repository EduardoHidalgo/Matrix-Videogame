using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleGame.Ejemplo
{
    public class Loop
    {
        Game Game;
        SpriteBatch SpriteBatch;
        GraphicsDevice GD;

        public SpriteFont Font;
        Vector2 Position;

        public Loop(Game game, SpriteBatch spriteBatch)
        {
            Game = game;
            SpriteBatch = spriteBatch;
        }

        public void Initialize()
        {
            Position = new Vector2(10, 10);
        }

        public void LoadContent()
        {
            Font = Game.Content.Load<SpriteFont>("Console24");
        }

        public void UnloadContent()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {
            SpriteBatch.DrawString(Font, "Hola Mundo", Position, Color.Green);
        }
    }
}
