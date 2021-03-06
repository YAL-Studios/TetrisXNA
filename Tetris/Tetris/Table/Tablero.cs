﻿using System;
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
        Texture2D fondo, marco, Ama, Azul, Rojo, Mora, Ver, Cel, Nar;
        SpriteFont Arial;
        int fr, fl, fd, ff, pIguales, ultI = 0, color, NextColor, puntos, filasMult, filasTot, lvl;
        char[,] NextFig;
        bool qPieza;
        Vector2 posNextP = new Vector2(365, 60);
        char[,] tablero = new char[27, 12] { 
        #region Inicializacion del tablero
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},
        {'U', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'U'},//AQUUI
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
        char[,] HUD = new char[22, 7] {
        #region HUD
            {'X', 'F', 'F', 'F', 'F','F', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'F', 'F', 'F', 'F','F', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'X', 'X', 'X', 'X','X', 'F'},
            {'X', 'F', 'F', 'F', 'F','F', 'F'},
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
            Cel = Content.Load<Texture2D>("Piezas/Pieza_Celeste");
            Nar = Content.Load<Texture2D>("Piezas/Pieza_Naranja");
            Arial = Content.Load<SpriteFont>("Fonts/Arial");
        }

        public void Update(Pieza p, ref int _lvl, ref int _puntos) {
            NextFig = p.NEXT_FIG;
            NextColor = p.NextCol;
            #region Cambio de forma
            if (p.cReq && !p.toBottom) {
                for (int i = 0; i < 5; i++) {
                    for (int j = 0; j < 5; j++) {
                        if ((i + (int)p.position.X) > 0) {
                            if (p.NEXT_FORM[j, i] == 'I') {
                                if (tablero[(j + (int)p.position.Y), (i + (int)p.position.X)] == 'X') {
                                    ff++;
                                }
                            }
                        }
                        if (ff == 4) break;
                    }
                    if (ff == 4) break;
                }
                if (ff == 4) p.forma++;
                ff = 0;
                p.cReq = false;
            }

            #endregion
            #region Caida
            if (p.moveD) {
                for (int i = 0; i < 5; i++) {
                    for (int j = 0; j < 5; j++) {
                        if (p.FIGURA_SELECT[i, j] == 'I') {  
                            if (tablero[(j + (int)p.position.Y) + 1, (i + (int)p.position.X)] == 'X') {
                                fd++;
                            }
                        }
                        if (fd == 4) break;
                    }
                    if (fd == 4) break;
                }

                if (fd == 4) {
                    p.position.Y += 1;
                    if (p.toBottom)
                        puntos = _puntos++;
                } else {
                    p.Enabled = false;
                    CopyTo(p.color, p.FIGURA_SELECT, p.position);
                }
                p.moveD = false;
                fd = 0;
            }
            #endregion
            #region Movimiento X
            if ((p.moveR || p.moveL) && !p.cReq) {
                for (int i = 0; i < 5; i++) {
                    for (int j = 0; j < 5; j++) {
                        if (p.FIGURA_SELECT[i, j] == 'I') {
                            if (p.moveR && tablero[(j + (int)p.position.Y), (i + (int)p.position.X) + 1] == 'X') {
                                fr++;
                            }
                            if (p.moveL && tablero[(j + (int)p.position.Y), (i + (int)p.position.X) - 1] == 'X') {
                                fl++;
                            }
                        }
                        if (fl == 4 || fr == 4) break;
                    }
                    if (fl == 4 || fr == 4) break;
                }

                if (fr == 4) p.position.X += 1;
                p.moveR = false;
                fr = 0;
                
                if (fl == 4) p.position.X -= 1;
                p.moveL = false;
                fl = 0;
            }
            #endregion
            #region Quitar Piezas
            if (qPieza) {
                for (int i = 5 + ultI; i < 26; i++) {
                    for (int j = 1; j < 11; j++) {
                        if (tablero[i, j] != 'X') {
                            pIguales++;
                            ultI = i;
                        } else {
                            pIguales = 0;
                            break;
                        }
                    }
                    if (pIguales == 10) {
                        filasMult++;
                        filasTot++;
                        if (filasTot % 3 == 0) {
                            _lvl++;
                            lvl = _lvl;
                        }
                        break;
                    }        
                }
                if (pIguales == 10) {
                    for (int j = 1; j < 11; j++) {
                        tablero[ultI, j] = 'X';
                        pIguales--;
                    }
                    for (int i = ultI; i > 0; i--) {
                        for (int j = 1; j < 11; j++) {
                            char temp;
                            temp = tablero[i, j];
                            tablero[i, j] = tablero[i - 1, j];
                            tablero[i - 1, j] = temp;                   
                        }
                    }
                    if (ultI == 25) {
                        qPieza = false;
                        puntos = _puntos += (1000 * filasMult) * _lvl;
                        filasMult = 0;
                    }
                }
                ultI = 0; 
            }
            #endregion

        }

        public bool GameOver () {
            for (int i = 0; i < 5; i++) {
                for (int j = 1; j < 11; j++) {
                    if (tablero[i, j] != 'X') {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Draw (SpriteBatch spriteBatch) {
            #region Dibujar shits
            for (int i = 5; i < 27; i++) {
                for (int j = 0; j < 12; j++) {
                    if (tablero[i, j] == 'X') {
                        spriteBatch.Draw(fondo, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    }
                    if (tablero[i, j] == 'U' || tablero[i, j] == 'F') {
                        spriteBatch.Draw(marco, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    }
                    if (tablero[i, j] == '1')
                        spriteBatch.Draw(Cel, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    if (tablero[i, j] == '2')
                        spriteBatch.Draw(Ver, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    if (tablero[i, j] == '3')
                        spriteBatch.Draw(Rojo, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    if (tablero[i, j] == '4')
                        spriteBatch.Draw(Mora, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    if (tablero[i, j] == '5')
                        spriteBatch.Draw(Nar, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    if (tablero[i, j] == '6')
                        spriteBatch.Draw(Azul, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                    if (tablero[i, j] == '7')
                        spriteBatch.Draw(Ama, new Vector2(32 * j, 32 * (i - 5)), Color.White);
                }
            }
            #endregion
            #region JUD
            for (int i = 0; i < 22; i++) {
                for (int j = 0; j < 7; j++) {
                    if (HUD[i, j] == 'F') {
                        spriteBatch.Draw(marco, new Vector2(32 * (j + 11), 32 * (i)), Color.White);
                    }
                }
            }
            spriteBatch.DrawString(Arial, "SCORE:", new Vector2(420, 310), Color.Yellow);
            spriteBatch.DrawString(Arial, puntos.ToString(), new Vector2(445, 350), Color.White);
            spriteBatch.DrawString(Arial, "LINES:", new Vector2(400, 400), Color.Yellow);
            spriteBatch.DrawString(Arial, filasTot.ToString(), new Vector2(490, 400), Color.White);
            spriteBatch.DrawString(Arial, "LEVEL:", new Vector2(400, 450), Color.Yellow);
            spriteBatch.DrawString(Arial, lvl.ToString(), new Vector2(490, 450), Color.White);
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (NextFig[i, j] == 'I') {
                        switch (NextColor) {
                            case 7:
                                spriteBatch.Draw(Ama, new Vector2(posNextP.X + (32 * i), posNextP.Y + (32 * j)), Color.White);
                                break;
                            case 6:
                                spriteBatch.Draw(Azul, new Vector2(posNextP.X + (32 * i), posNextP.Y + (32 * j)), Color.White);
                                break;
                            case 4:
                                spriteBatch.Draw(Mora, new Vector2(posNextP.X + (32 * i), posNextP.Y + (32 * j)), Color.White);
                                break;
                            case 3:
                                spriteBatch.Draw(Rojo, new Vector2(posNextP.X + (32 * i), posNextP.Y + (32 * j)), Color.White);
                                break;
                            case 2:
                                spriteBatch.Draw(Ver, new Vector2(posNextP.X + (32 * i), posNextP.Y + (32 * j)), Color.White);
                                break;
                            case 5:
                                spriteBatch.Draw(Nar, new Vector2(posNextP.X + (32 * i), posNextP.Y + (32 * j)), Color.White);
                                break;
                            case 1:
                                spriteBatch.Draw(Cel, new Vector2(posNextP.X + (32 * i), posNextP.Y + (32 * j)), Color.White);
                                break;
                        }
                    }
                }
            }
            #endregion
        }

        void CopyTo(int _color, char[,] fig, Vector2 pos) {
            color = _color;
            qPieza = true;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (fig[i, j] == 'I') {
                        switch (color) { 
                            case 1:
                                if (tablero[(j + (int)pos.Y), (i + (int)pos.X)] == 'X')
                                    tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '1';
                                break;
                            case 2:
                                if (tablero[(j + (int)pos.Y), (i + (int)pos.X)] == 'X')
                                    tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '2';
                                break;
                            case 3:
                                if (tablero[(j + (int)pos.Y), (i + (int)pos.X)] == 'X')
                                    tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '3';
                                break;
                            case 4:
                                if (tablero[(j + (int)pos.Y), (i + (int)pos.X)] == 'X')
                                    tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '4';
                                break;
                            case 5:
                                if (tablero[(j + (int)pos.Y), (i + (int)pos.X)] == 'X')
                                    tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '5';
                                break;
                            case 6:
                                if (tablero[(j + (int)pos.Y), (i + (int)pos.X)] == 'X')
                                    tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '6';
                                break;
                            case 7:
                                if (tablero[(j + (int)pos.Y), (i + (int)pos.X)] == 'X')
                                    tablero[(j + (int)pos.Y), (i + (int)pos.X)] = '7';
                                break;
                        }  
                    }
                }
            }
        }
    }
}
