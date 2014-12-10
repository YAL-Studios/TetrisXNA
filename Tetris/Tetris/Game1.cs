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

        public Game1 () {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 384;
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
            
            t.LoadContent(Content);
        }

        //Descargar contenido
        protected override void UnloadContent() {
        }

        //Actualizar
        protected override void Update (GameTime gameTime) {
            if (!gameOver) { 

                if (Land) {
                    r = new Random();              
                    p = new Pieza(r.Next(1, 6), r.Next(1, 8));
                    p.LoadContent(Content);
                }
                Land = p.Update(gameTime);
                t.Update(p);
            
                base.Update(gameTime);
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
