
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ConsoleGame
{
    class InputHandler
    {
        SpriteBatch SpriteBatch;
        Game Game;

        MouseState MouseState;
        KeyboardState KeyBoardState;

        int Size;
        float Time;

        SpriteFont Temp;

        SpriteFont[] FontArray;
        SpriteFont Font;
        Vector2 Vector;
        Vector2 FontVectorSize;

        string Text;

        string LineSpacing, Value1;

        string SizeFont, Value2;


        public InputHandler(SpriteBatch spriteBatch, Game game)
        {
            SpriteBatch = spriteBatch;
            Game = game;
            Text = "=";
            FontArray = new SpriteFont[123];
            Vector = new Vector2(600, 350);
            Time = 0f;
            Size = 0;

            LoadContent();

        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {
            string tmp = "";

            for (int i = 6; i < FontArray.Length + 6; i++)
            {
                tmp = "" + i;
                if (i < 10)
                {
                    tmp = "0" + i;
                    FontArray[i - 6] = Game.Content.Load<SpriteFont>("Console" + tmp);
                }
                else
                {
                    FontArray[i - 6] = Game.Content.Load<SpriteFont>("Console" + tmp);
                }
            }

            Font = FontArray[0];
            Font.LineSpacing = 0;
            Font.Spacing = 0;
            
            FontVectorSize = Font.MeasureString(Text);
        }

        public void UnloadContent()
        {

        }

        public void Update()
        {
            Time += .01f;
            KeyBoardState = Keyboard.GetState();

            if (KeyBoardState.GetPressedKeys().Length != 0)
            {
                if (KeyBoardState.IsKeyDown(Keys.A) && Time > .02f)
                {
                    if (Size > 0)
                    {
                        Size--;
                        Font = FontArray[Size];
                    }
                    Time = 0;
                }
                if (KeyBoardState.IsKeyDown(Keys.S) && Time > .02f)
                {
                    if (Size < FontArray.Length - 1)
                    {
                        Size++;
                        Font = FontArray[Size];
                    }
                    Time = 0;
                }

                if (KeyBoardState.IsKeyDown(Keys.Left))
                {
                    if (Vector.X > 20)
                    {
                        Vector.X -= 3;
                    }
                }
                if (KeyBoardState.IsKeyDown(Keys.Right))
                {
                    if (Vector.X < 1180)
                    {
                        Vector.X += 3;
                    }
                }
                if (KeyBoardState.IsKeyDown(Keys.Up))
                {
                    if (Vector.Y > 20)
                    {
                        Vector.Y -= 3;
                    }
                }
                if (KeyBoardState.IsKeyDown(Keys.Down))
                {
                    if (Vector.Y < 680)
                    {
                        Vector.Y += 3;
                    }
                }
            }
            FontVectorSize = Font.MeasureString(Text);
            LineSpacing = "Vector: ";
            Value1 = "X: " + FontVectorSize.X + "   Y: " + FontVectorSize.Y;

            SizeFont = "SizeFont: ";
            Value2 = "" + (Size + 6);
        }

        public void Draw()
        {
            int SizeX = (int)FontVectorSize.X;
            int Iter = 1200 / (int)FontVectorSize.X;
            int Residue = 1200 % SizeX;
            int Separate = 0;
            int Count = 0;
            int X = 0;

            if (Residue != 0)
            {
                Separate = 1200 / Residue;
            }

            for (int i = 0; i < Iter; i++)
            {
                SpriteBatch.DrawString(Font, Text, new Vector2(X, 0 - (FontVectorSize.Y / 4)), Color.Blue);
                if (Separate != 0 && Count > Separate)
                {
                    Count = 0;
                    X++;
                }
                X += SizeX;
                Count += SizeX;
            }

            SpriteBatch.DrawString(FontArray[5], LineSpacing, new Vector2(20, 20), Color.White);
            SpriteBatch.DrawString(FontArray[5], Value1, new Vector2(200, 20), Color.White);

            SpriteBatch.DrawString(FontArray[5], SizeFont, new Vector2(20, 40), Color.White);
            SpriteBatch.DrawString(FontArray[5], Value2, new Vector2(200, 40), Color.White);

            SpriteBatch.DrawString(Font, Text, Vector, Color.Blue);
         
        }
    }
}
