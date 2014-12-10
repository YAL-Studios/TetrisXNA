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
        Texture2D texture;
        KeyboardState kb, kbAnt;
        public Vector2 position = new Vector2(4, 0);
        public char[,] FIGURA_SELECT = new char[5, 5];
        public char[,] NEXT_FIG = new char[5, 5];
        float time, lastMovesTimer, difficulty;
        public bool Enabled = true, FR = true, FL = true, cReq;
            bool lastMoves, isFalling = true;

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

        public bool Update(GameTime gameTime) {

            if (lastMoves) {
                lastMovesTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (lastMovesTimer >= 200) {
                    Enabled = false;
                }
            } else lastMovesTimer = 0;

            kb = Keyboard.GetState();
            if (kbAnt.IsKeyUp(Keys.Space) && kb.IsKeyDown(Keys.Space) && Enabled) forma++; //cReq = true;
            if (kbAnt.IsKeyUp(Keys.D) && kb.IsKeyDown(Keys.D) && Enabled && FR) {
                position.X++;
            }
            if (kbAnt.IsKeyUp(Keys.A) && kb.IsKeyDown(Keys.A) && Enabled && FL) {
                if (position.X > -1)
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
            if (time >= 200 && Enabled && isFalling) {
                position.Y += 1;
                time = 0;
            }
            if (!Enabled) return true;
            return false;

        }
        
        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (FIGURA_SELECT[i, j] == 'I' && Enabled) {
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
            int f;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    switch (figura) { 
                        case 1: // 2
                            FIGURA_SELECT[i, j] = FIGURA_I[forma, i, j];
                            f = forma > 0 ? 0 : 1;
                            NEXT_FIG[i, j] = FIGURA_I[f, i, j];
                            break;
                        case 2:
                            FIGURA_SELECT[i, j] = FIGURA_S[forma, i, j];
                            f = forma > 0 ? 0 : 1;
                            NEXT_FIG[i, j] = FIGURA_S[f, i, j];
                            break;
                        case 3:
                            FIGURA_SELECT[i, j] = FIGURA_Z[forma, i, j];
                            f = forma > 0 ? 0 : 1;
                            NEXT_FIG[i, j] = FIGURA_Z[f, i, j];
                            break;
                        case 4:
                            FIGURA_SELECT[i, j] = FIGURA_T[forma, i, j];
                            f = forma > 2 ? 0 : forma + 1;
                            NEXT_FIG[i, j] = FIGURA_T[f, i, j];
                            break;
                        case 5:
                            FIGURA_SELECT[i, j] = FIGURA_L[forma, i, j];
                            f = forma > 2 ? 0 : forma + 1;
                            NEXT_FIG[i, j] = FIGURA_L[f, i, j];
                            break;
                        case 6:
                            FIGURA_SELECT[i, j] = FIGURA_J[forma, i, j];
                            f = forma > 2 ? 0 : forma + 1;
                            NEXT_FIG[i, j] = FIGURA_J[f, i, j];
                            break;
                        case 7:
                            FIGURA_SELECT[i, j] = FIGURA_O[i, j];
                            NEXT_FIG[i, j] = FIGURA_O[i, j];
                            break;
                    }
                }   
            }
        }

        public void LastMoves (bool _lastMoves) {
            lastMoves = _lastMoves;
            if (_lastMoves) {
                isFalling = false;
            } else isFalling = true;
        }
    }
}
