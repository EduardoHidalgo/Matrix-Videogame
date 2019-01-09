using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleGame
{
    class Matrix
    {
        SpriteBatch SpriteBatch;
        Game Game;
        MatrixManager MatrixManager;

        SpriteFont[] FontArray; //Arreglo de fuentes
        Random Random;  //VAriable para aleatorizar

        string[] Rand = new string[26] {"A", "B", "C", "D",
        "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
        "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        const int Min = 7; //Mínimo tamaño del arreglo de letras
        const int Max = 24; //Máximo tamaño del arreglo de letras

        const int BufferX = 1200, BufferY = 700; //Tamaño del buffer

        public int Size; //Tamaño del arreglo de letras
        public int FontSize;
        public SpriteFont Font;
        public float Speed;
        public string Text;
        public Vector2 Position;
        public Vector2[] CharPositions;
        public Vector2 StringVector;
        int Seed;

        int Count;


        public Matrix(SpriteBatch spriteBatch, Game game, MatrixManager objectLister)
        {
            SpriteBatch = spriteBatch;
            Game = game;
            MatrixManager = objectLister;
            Random = new Random();
            FontArray = new SpriteFont[123]; //123 tamaños de fuentes disponibles
            Count = 0;

            LoadContent();
            CreateEntity();
        }

        public void Initialize()
        {

        }
        public void LoadContent()
        {
            //Carga de todas las fuentes
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
        }
        public void UnloadContent()
        {

        }
        public void Update()
        {
            Count++;
            Position.Y += Speed;

            //cada 40 conteos, aleatoriza letras del string
            if (Count >= 40)
            {
                Randomizer();
                Count = 0;
            }
            //si ya se salió de la pantalla, lo elimina
            if (Position.Y > 710)
            {
                MatrixManager.Positions[Seed] = false;
                MatrixManager.RemoveM(this);
            }
            //si no se ha salido de la pantalla, incrementa su posición sobre y
            else
            {
                for (int i = 0; i < CharPositions.Length; i++)
                {
                    CharPositions[i].Y += Speed;
                }
            }
        }
        public void Draw()
        {
            //Dibuja cada letra
            for (int i = 0; i < Size; i++)
            {
                SpriteBatch.DrawString(Font, Text.Substring(i, 1), CharPositions[i], Color.GreenYellow);
            }
        }

        private void CreateEntity()
        {

            Text = "";
            // aleatoriza el tamaño que va a tener el string
            int Size = Random.Next(Min, Max);
            //Inserta una letra aleatoria hasta llenar el string
            for (int i = 0; i < Size; i++)
            {
                Text += (Random.Next(Rand.Length));
            }

            RandomEntity();
            MatrixManager.ListEntitys.Add(this);

        }

        private void RandomEntity()
        {
            Seed = 0;


            //ASIGNA TAMAÑO DE FUENTE ALEATORIO
            Size = Random.Next(10, 40);
            FontSize = Random.Next(0, 40);

            CharPositions = new Vector2[Size]; //Instancia el arreglo de vectores

            //ASIGNA EL SPRITEFONT CON EL TAMAÑO DE FUENTE
            Font = FontArray[FontSize];
            //ASIGNA VELOCIDAD ALEATORIA
            Speed = Random.Next(1,4);
            //ASIGNA TAMAÑO DE 1 CARACTER CON LAS DIMENSIONES DE SU SPRITEFONT
            StringVector = Font.MeasureString("M");

            Text = "";
            //ASIGNA EL STRING QUE CONTENDRÁ LA ENTIDAD ALEATORIA
            for (int i = 1; i <= Size; i++)
            {
                Text += Rand[(Random.Next(Rand.Length))];
            }

            //ASIGNA POSICIÓN INICIAL DE LA ENTIDAD SEGÚN SUS DIMENSIONES
            bool Found = false;
            while (Found == false)
            {
                Seed = Random.Next(0, 40);
                if (MatrixManager.Positions[Seed] == false)
                {
                    Position.X = Seed * 30;
                    MatrixManager.Positions[Seed] = true;
                    Found = true;
                }
            }
            //Seed = Random.Next(0, 40);
            //Position.X = Seed * 30;


            Position.Y =  0 - (StringVector.Y * Text.Length);

            //ASIGNA EL ARREGLO DE CADA POSICIÓN DE LA LINEA
            for (int i = 0; i < Size; i++)
            {
                CharPositions[i] = new Vector2(Position.X,(0 - StringVector.Y * Text.Length) + (StringVector.Y * i));
            }

        }

        private void Randomizer()
        {
            string Replace = "";
            int Seed;

            for (int i = 0; i < Text.Length; i++)
            {
                //LA MODIFICO SEGUN VALOR ALEATORIO
                Seed = Random.Next(1, 8);
                if (Seed == 1)
                {
                    Replace += Rand[(Random.Next(Rand.Length))];
                }
                else
                {
                    Replace += Text.Substring(i, 1);
                }
            }
            Text = Replace;
        }
    }
}
