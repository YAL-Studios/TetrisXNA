using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris.Table
{
    public class Tablero
    {
        Texture2D fondo, marco;
        Vector2 posFigura;
        char[,] figura;
        char[,] tablero = new char[22, 12] { 
        #region Inicializacion del tablero
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', '1', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        { 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U'},
        #endregion
        };

        public Tablero() {
        }

        public void LoadContent(ContentManager Content){
            fondo = Content.Load<Texture2D>("Tablero/BG");
            marco = Content.Load<Texture2D>("Tablero/Marco");
        }

        public bool Update(Vector2 _posFigura, char[,] _figura)
        {
            posFigura.X = _posFigura.X;
            posFigura.Y = _posFigura.Y;
            figura = _figura;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (figura[i, j] == 'I') {
                        if (tablero[(j + (int)posFigura.Y) + 1, (i + (int)posFigura.X)] != 'X') {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 22; i++) {
                for (int j = 0; j < 12; j++) {
                    if (tablero[i, j] == 'X') {
                        spriteBatch.Draw(fondo, new Vector2(32 * j, 32 * i), Color.White);
                    }
                    if (tablero[i, j] == 'U') {
                        spriteBatch.Draw(marco, new Vector2(32 * j, 32 * i), Color.White);
                    }
                }
            }
        }

    }
}
