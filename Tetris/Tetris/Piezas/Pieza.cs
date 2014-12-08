using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris.Piezas
{
    public class Pieza {
        int color, figura, forma, formaAnt;
        Texture2D texture;
        Vector2 position = new Vector2(300, 0);
        char[,] FIGURA_SELECT = new char[5, 5];
        #region FIGURA I
        char[,,] FORMAS_FIGURA_I = new char[2, 5, 5] {
            {
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'I', 'I', 'I', 'I', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            }
            
        };
        #endregion
        #region FIGURA T
        char[, ,] FORMAS_FIGURA_T = new char[4, 5, 5] {
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'I', 'I', 'I', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },  
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'I', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'I', 'I', 'I', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'I', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
        };
        #endregion
        public Pieza(int _color, int _figura) {
            color = _color;
            figura = _figura;
            CopyMatrix();
            TMatrix();
        }

        public void LoadContent(ContentManager Content) {
            switch (color) { 
                case 1:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Amarilla");
                    break;
                case 2:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Azul");
                    break;
                case 3:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Morada");
                    break;
                case 4:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Roja");
                    break;
                case 5:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Verde");
                    break;
            }
        }

        public void Update(ref int _forma) {
            if (figura == 1 && _forma > 1) _forma = 0;
            if (figura == 2 && _forma > 3) _forma = 0;
            forma = _forma;
            if (_forma != formaAnt) {
                CopyMatrix();
                TMatrix();
            }
            formaAnt = forma;
        }
        
        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (FIGURA_SELECT[i, j] == 'I') {
                        spriteBatch.Draw(texture, new Vector2(32 * i, 32 * j), Color.White);
                    }
                }
            }
        }

        void TMatrix() {
            for (int i = 0; i < 5; i++) {
                for (int j = i; j < 5; j++) {
                    char temp;
                    temp = FIGURA_SELECT[i, j];
                    FIGURA_SELECT[i, j] = FIGURA_SELECT[j, i];
                    FIGURA_SELECT[j, i] = temp;
                }
            }
        }
        void CopyMatrix() {
            switch (figura) { 
                case 1:
                    for (int i = 0; i < 5; i++) {
                        for (int j = 0; j < 5; j++) {
                            FIGURA_SELECT[i, j] = FORMAS_FIGURA_I[forma, i, j];
                        }
                    }
                break;
                case 2:
                    for (int i = 0; i < 5; i++) {
                        for (int j = 0; j < 5; j++)
                        {
                            FIGURA_SELECT[i, j] = FORMAS_FIGURA_T[forma, i, j];
                        }
                    }
                break;
            }
            
        }
    }
}
