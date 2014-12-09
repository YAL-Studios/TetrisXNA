using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Tetris.Piezas;

namespace Tetris.Table
{
    public class Tablero
    {
        Texture2D fondo, marco;
        int pt = 0;
        char[,] tablero = new char[22, 12] { 
        #region Inicializacion del tablero
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', '1', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', '1', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', '1', '1', '1', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'U'},
        #endregion
        };

        public Tablero() {
        }

        public void LoadContent(ContentManager Content){
            fondo = Content.Load<Texture2D>("Tablero/BG");
            marco = Content.Load<Texture2D>("Tablero/Marco");
        }

        public void Update(Pieza p)
        {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) { 
                    if (p.NEXT_FIG[j, i] == 'I') {
                        if (p.cReq) {
                            if (i + (int)p.position.X > 0 && i < 3) { 
                                if (tablero[(j + (int)p.position.Y), (i + (int)p.position.X)] == 'U') {
                                    //p.position.X++;
                                } else pt++;
                            }
                            else {
                                if (i + (int)p.position.X == 0) p.position.X++;
                                if (i + (int)p.position.X == 3) p.position.X--;
                            }
                            
                            if (pt == 4) {
                                p.forma++;
                                p.cReq = false;
                                pt = 0;
                            }
                        }
                    } 
                }
            }
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (p.FIGURA_SELECT[i, j] == 'I' && !p.cReq) {
                        if (tablero[(j + (int)p.position.Y) + 1, (i + (int)p.position.X)] != 'X' &&
                            tablero[(j + (int)p.position.Y) + 1, (i + (int)p.position.X)] != 'U') {
                            p.Enabled = false;                       
                        }
                        if (i + (int)p.position.X > 0) {
                            if (tablero[(j + (int)p.position.Y), (i + (int)p.position.X) - 1] == 'U') p.FL = false;
                            else p.FL = true;
                        } else p.position.X += 1;
                        if (i + (int)p.position.X < 11) {
                            if (tablero[(j + (int)p.position.Y), (i + (int)p.position.X) + 1] == 'U') p.FR = false;
                            else p.FR = true;
                        } else p.position.X -= 1;     
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 22; i++) {
                for (int j = 0; j < 12; j++) {
                    if (tablero[i, j] == 'X') {
                        spriteBatch.Draw(fondo, new Vector2(32 * j, 32 * i), Color.White);
                    }
                    if (tablero[i, j] == 'U' || tablero[i, j] == 'F') {
                        spriteBatch.Draw(marco, new Vector2(32 * j, 32 * i), Color.White);
                    }
                }
            }
        }

    }
}
