using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris.Piezas
{
    public class Pieza {
        public int color, figura, forma, formaAnt;
        public float wall = 8;
        Texture2D texture;
        KeyboardState kb, kbAnt;
        
        public Vector2 position = new Vector2(1, 0);
        public char[,] FIGURA_SELECT = new char[5, 5];
        float time;
        public bool Enabled = true, Right = true, Left = true;

        #region FIGURA I | 1
        char[,,] FIGURA_I = new char[2, 5, 5] {
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
        #region FIGURA S | 2
        char[, ,] FIGURA_S = new char[2, 5, 5] {
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'I', 'I', 'X'},
                {'X', 'I', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'I', 'X', 'X', 'X'},
                {'X', 'I', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            }
        };
        #endregion
        #region FIGURA Z | 3
        char[, ,] FIGURA_Z = new char[2, 5, 5] {
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'I', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'I', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'I', 'X'},
                {'X', 'X', 'I', 'I', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            }
        };
        #endregion
        #region FIGURA T | 4
        char[, ,] FIGURA_T = new char[4, 5, 5] {
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
        #region FIGURA L | 5
        char[, ,] FIGURA_L = new char[4, 5, 5] {
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'I', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'I', 'I', 'I', 'X'},
                {'X', 'I', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'I', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'I', 'X'},
                {'X', 'I', 'I', 'I', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            }
        };
        #endregion
        #region FIGURA J | 6
        char[, ,] FIGURA_J = new char[4, 5, 5] {
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'I', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'I', 'X', 'X', 'X'},
                {'X', 'I', 'I', 'I', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'I', 'I', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'I', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            },
            {
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'X', 'X', 'X', 'X'},
                {'X', 'I', 'I', 'I', 'X'},
                {'X', 'X', 'X', 'I', 'X'},
                {'X', 'X', 'X', 'X', 'X'}
            }
        };
        #endregion
        #region FIGURA O | 7
        char[,] FIGURA_O = new char[5, 5] {
            {'X', 'X', 'X', 'X', 'X'},
            {'X', 'X', 'I', 'I', 'X'},
            {'X', 'X', 'I', 'I', 'X'},
            {'X', 'X', 'X', 'X', 'X'},
            {'X', 'X', 'X', 'X', 'X'}
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

        public void Update(GameTime gameTime) {
            kb = Keyboard.GetState();
            if (kbAnt.IsKeyUp(Keys.Space) && kb.IsKeyDown(Keys.Space)) forma++;
            if (kbAnt.IsKeyUp(Keys.D) && kb.IsKeyDown(Keys.D) /*&& Right && Enabled /*&& position.X+1 < wall*/ && Enabled && position.X < 8)
            {
                position.X++;
            }
            if (kbAnt.IsKeyUp(Keys.A) && kb.IsKeyDown(Keys.A) /*&& Left && Enabled /*&& position.X > 0*/ && Enabled &&  position.X > 0)
            {
                position.X--;
            }
            kbAnt = kb;
            if (figura <= 3 && forma > 1) forma = 0;
            if (figura <= 6 && forma > 3) forma = 0;
            if (forma != formaAnt) {
                CopyMatrix();
                TMatrix();
            }
            formaAnt = forma;

            

            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time >= 1000 && Enabled) {
                position.Y += 1;
                time = 0;
            }

        }
        
        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (FIGURA_SELECT[i, j] == 'I') {
                        spriteBatch.Draw(texture, new Vector2(32 * (i + position.X), 32 * (j + position.Y)), Color.White);
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
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    switch (figura) { 
                        case 1: // 2
                            FIGURA_SELECT[i, j] = FIGURA_I[forma, i, j];
                            break;
                        case 2:
                            FIGURA_SELECT[i, j] = FIGURA_S[forma, i, j];
                            break;
                        case 3:
                            FIGURA_SELECT[i, j] = FIGURA_Z[forma, i, j];
                            break;
                        case 4:
                            FIGURA_SELECT[i, j] = FIGURA_T[forma, i, j];
                            break;
                        case 5:
                            FIGURA_SELECT[i, j] = FIGURA_L[forma, i, j];
                            break;
                        case 6:
                            FIGURA_SELECT[i, j] = FIGURA_J[forma, i, j];
                            break;
                        case 7:
                            FIGURA_SELECT[i, j] = FIGURA_O[i, j];
                            break;
                    }
                }   
            }
        }
    }
}
