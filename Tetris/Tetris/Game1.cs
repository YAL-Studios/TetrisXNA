using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Tetris.Piezas;
using Tetris.Table;

namespace Tetris
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Creas una figura, El primer parametro define el color(1-5) y el segundo parametro define forma de la figura(1-7)
        Pieza p;// = new Pieza(1, 1);
        //Puedes rotar la figura presionando D
        Tablero t = new Tablero();
        Random r;
        bool Land = true, gameOver = false;
        KeyboardState kb, kbAnt;
        bool Land = true, gameOver, FirstBanderazo = true;
        int NextFig;

        Song music;

        public Game1 () {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 584;
            graphics.PreferredBackBufferHeight = 704;
            Content.RootDirectory = "Content";
        }

        //Inicializar cosas
        protected override void Initialize() {
            base.Initialize();
        }

        //Cargar contenido
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            music = Content.Load<Song>("Canciones/Theme B");
            t.LoadContent(Content);

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(music);
            MediaPlayer.Volume = 0.05f;
            
        }

        //Descargar contenido
        protected override void UnloadContent() {
        }

        //Actualizar
        protected override void Update (GameTime gameTime) {
            if (!gameOver) { 

                kb = Keyboard.GetState();
                if (kbAnt.IsKeyUp(Keys.M) && kb.IsKeyDown(Keys.M)) MediaPlayer.IsMuted = !MediaPlayer.IsMuted;
                if (kbAnt.IsKeyUp(Keys.PageUp) && kb.IsKeyDown(Keys.PageUp)) MediaPlayer.Volume += 0.01f;
                if (kbAnt.IsKeyUp(Keys.PageDown) && kb.IsKeyDown(Keys.PageDown)) MediaPlayer.Volume -= 0.01f;
                
                kbAnt = kb;
                if (Land) {
                    if (FirstBanderazo) {
                    r = new Random();              
                        p = new Pieza(r.Next(1, 8), r.Next(1, 8));
                        NextFig = p.NextFig;
                        FirstBanderazo = false;
                    } else {
                        p = new Pieza(NextFig, r.Next(1, 8));
                        NextFig = p.NextFig;
                    }
                    p.LoadContent(Content);
                }
                Land = p.Update(gameTime);

                t.Update(p);
                if (t.GameOver())
                    gameOver = true;
               


                base.Update(gameTime);
            } else {
                Exit();
            }
            
        }

        //Dibujar
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            t.Draw(spriteBatch);
            if (!Land)
                p.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
