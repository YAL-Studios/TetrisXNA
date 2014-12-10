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
        Texture2D fondo, marco, Ama, Azul, Rojo, Mora, Ver;
        int pt = 0, color;
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
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'F', 'U'},
        #endregion
        };

        public Tablero() {
        }

        public void LoadContent(ContentManager Content){
            fondo = Content.Load<Texture2D>("Tablero/BG");
            marco = Content.Load<Texture2D>("Tablero/Marco");
            Ama = Content.Load<Texture2D>("Piezas/Pieza_Amarilla");
            Azul = Content.Load<Texture2D>("Piezas/Pieza_Azul");
            Mora = Content.Load<Texture2D>("Piezas/Pieza_Morada");
            Rojo = Content.Load<Texture2D>("Piezas/Pieza_Roja");
            Ver = Content.Load<Texture2D>("Piezas/Pieza_Verde");
        }

        public void Update(Pieza p)
        {
            #region Rotarlo junto al muro
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
            #endregion
            #region Control de limites
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (p.FIGURA_SELECT[i, j] == 'I' && !p.cReq) {
                        if (tablero[(j + (int)p.position.Y) + 1, (i + (int)p.position.X)] != 'X' &&
                            tablero[(j + (int)p.position.Y) + 1, (i + (int)p.position.X)] != 'U') {
                            p.Enabled = false;
                            CopyTo(p.color, p.FIGURA_SELECT, p.position);
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
            #endregion
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
                    if (tablero[i, j] == '1') spriteBatch.Draw(Ama, new Vector2(32 * j, 32 * i), Color.White);
                    if (tablero[i, j] == '2') spriteBatch.Draw(Azul, new Vector2(32 * j, 32 * i), Color.White);
                    if (tablero[i, j] == '3') spriteBatch.Draw(Mora, new Vector2(32 * j, 32 * i), Color.White);
                    if (tablero[i, j] == '4') spriteBatch.Draw(Rojo, new Vector2(32 * j, 32 * i), Color.White);
                    if (tablero[i, j] == '5') spriteBatch.Draw(Ver, new Vector2(32 * j, 32 * i), Color.White);
                    
                }
            }
        }
        void CopyTo(int _color, char[,] fig, Vector2 pos) {
            color = _color;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (fig[i, j] == 'I') {
                        switch (color) { 
                            case 1:
                                tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '1';
                                break;
                            case 2:
                                tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '2';
                                break;
                            case 3:
                                tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '3';
                                break;
                            case 4:
                                tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '4';
                                break;
                            case 5:
                                tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '5';
                                break;
                        }
                        
                        
                    }
                }
            }
        }
    }
}
