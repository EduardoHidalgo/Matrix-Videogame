using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleGame
{
    class MatrixManager
    {

        SpriteBatch SpriteBatch;
        Game Game;

        public List<Matrix> ListEntitys;
        public List<Matrix> TempListEntitys;
        public List<bool> Positions;

        public MatrixManager(SpriteBatch spriteBatch, Game game)
        {
            SpriteBatch = spriteBatch;
            Game = game;

            ListEntitys = new List<Matrix>();
            TempListEntitys = new List<Matrix>();
            Positions = new List<bool>();

            for (int i = 0; i < 40; i++)
            {
                Positions.Add(false);
            }
        }
        public void Initialize()
        {
        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update()
        {
            if (ListEntitys.Count < 41)
            {
                Matrix TempM = new Matrix(SpriteBatch, Game, this);

                ListEntitys.Add(TempM);
            }

            for (int i = ListEntitys.Count - 1; i >= 0; i--)
            {
                //EVITA LA PÉRDIDA DE LA VARIABLE AL REMOVERSE
                Matrix M = ListEntitys[i];

                if (TempListEntitys.Contains(M))
                {
                    ListEntitys.Remove(M);
                    TempListEntitys.Remove(M);
                }
                else
                {
                    M.Update();
                }
            }

        }

        public void Draw()
        {
            for (int i = ListEntitys.Count - 1; i >= 0; i--)
            {
                //EVITA LA PÉRDIDA DE LA VARIABLE AL REMOVERSE
                Matrix M = ListEntitys[i];

                if (TempListEntitys.Contains(M))
                {
                    ListEntitys.Remove(M);
                    TempListEntitys.Remove(M);
                }
                else
                {
                    M.Draw();
                }
            }
        }

        public void RemoveM(Matrix M)
        {
            TempListEntitys.Add(M);
        }
    }
}