﻿using Microsoft.Xna.Framework;
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
        public int color, figura, forma, formaAnt, NextFig, NextCol;
        Texture2D texture;
        KeyboardState kb, kbAnt;
        public Vector2 position = new Vector2(3, 2);
        public char[,] FIGURA_SELECT = new char[5, 5];
        public char[,] NEXT_FORM = new char[5, 5];
        public char[,] NEXT_FIG = new char[5, 5];
        float time, timeD, timeA;
        public bool Enabled = true, moveR, moveL, moveD, toBottom, cReq;

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
        

        public Pieza(int _figura, int nextFig) {
            NextCol = NextFig = nextFig;
            color = figura = _figura;
            CopyMatrix(figura, FIGURA_SELECT);
            TMatrix(FIGURA_SELECT);
            CopyMatrix(nextFig, NEXT_FIG);
            TMatrix(NEXT_FIG);
        }

        public void LoadContent(ContentManager Content) {
            switch (color) { 
                case 7:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Amarilla");
                    break;
                case 6:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Azul");
                    break;
                case 4:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Morada");
                    break;
                case 3:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Roja");
                    break;
                case 2:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Verde");
                    break;
                case 5:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Naranja");
                    break;
                case 1:
                    texture = Content.Load<Texture2D>("Piezas/Pieza_Celeste");
                    break;
            }
        }

        public bool Update(GameTime gameTime, int lvl) {
            time += gameTime.ElapsedGameTime.Milliseconds;
            timeD += gameTime.ElapsedGameTime.Milliseconds;
            timeA += gameTime.ElapsedGameTime.Milliseconds;
            kb = Keyboard.GetState();
            if (kbAnt.IsKeyUp(Keys.W) && kb.IsKeyDown(Keys.W) && Enabled) cReq = true;
            if (kbAnt.IsKeyUp(Keys.D) && kb.IsKeyDown(Keys.D) && Enabled) moveR = true;
            if (!moveR && kb.IsKeyDown(Keys.D)) {
                if (timeD >= 300) moveR = true;
            } else timeD = 0;
                
            if (kbAnt.IsKeyUp(Keys.A) && kb.IsKeyDown(Keys.A) && Enabled) moveL = true;
            if (!moveL && kb.IsKeyDown(Keys.A)) {
                if (timeA >= 300) moveL = true;  
            } else timeA = 0;
            if (kb.IsKeyDown(Keys.S) && Enabled) toBottom = true;
            else toBottom = false;
            if (kbAnt.IsKeyUp(Keys.Space) && kb.IsKeyDown(Keys.Space) && Enabled ) {
            }
                
            kbAnt = kb;
            if (figura <= 3 && forma > 1) forma = 0;
            if (figura <= 6 && forma > 3) forma = 0;
            if (forma != formaAnt) {
                CopyMatrix(figura, FIGURA_SELECT);
                TMatrix(FIGURA_SELECT);
            }
            formaAnt = forma;

            if (Enabled) {
                if (toBottom) {
                    if (time >= 10) {
                        moveD = true;
                        time = 0;
                    }
                } else {
                    if (time >= 420 - (lvl * 20)) {
                        moveD = true;
                        time = 0;
                    }
                }
            }

            if (!Enabled) return true;
            return false;

        }
        
        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (FIGURA_SELECT[i, j] == 'I' && Enabled) {
                        spriteBatch.Draw(texture, new Vector2(32 * (i + position.X),32 * ((j - 5) + position.Y)), Color.White);
                    }
                }
            }
        }

        void TMatrix(char[,] matrix) {
            for (int i = 0; i < 5; i++) {
                for (int j = i; j < 5; j++) {
                    char temp;
                    temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
        }

        void CopyMatrix(int fig, char[,] matrix) {
            int f;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    switch (fig) { 
                        case 1: // 2
                            matrix[i, j] = FIGURA_I[forma, i, j];
                            f = forma > 0 ? 0 : 1;
                            NEXT_FORM[i, j] = FIGURA_I[f, i, j];
                            break;
                        case 2:
                            matrix[i, j] = FIGURA_S[forma, i, j];
                            f = forma > 0 ? 0 : 1;
                            NEXT_FORM[i, j] = FIGURA_S[f, i, j];
                            break;
                        case 3:
                            matrix[i, j] = FIGURA_Z[forma, i, j];
                            f = forma > 0 ? 0 : 1;
                            NEXT_FORM[i, j] = FIGURA_Z[f, i, j];
                            break;
                        case 4:
                            matrix[i, j] = FIGURA_T[forma, i, j];
                            f = forma > 2 ? 0 : forma + 1;
                            NEXT_FORM[i, j] = FIGURA_T[f, i, j];
                            break;
                        case 5:
                            matrix[i, j] = FIGURA_L[forma, i, j];
                            f = forma > 2 ? 0 : forma + 1;
                            NEXT_FORM[i, j] = FIGURA_L[f, i, j];
                            break;
                        case 6:
                            matrix[i, j] = FIGURA_J[forma, i, j];
                            f = forma > 2 ? 0 : forma + 1;
                            NEXT_FORM[i, j] = FIGURA_J[f, i, j];
                            break;
                        case 7:
                            matrix[i, j] = FIGURA_O[i, j];
                            NEXT_FORM[i, j] = FIGURA_O[i, j];
                            break;
                    }
                }   
            }
        }
    }
}
