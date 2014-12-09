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
        KeyboardState kb, kbAnt;
        int forma;
        //Creas una figura, El primer parametro define el color(1-5) y el segundo parametro define forma de la figura(1-7)
        Pieza p = new Pieza(5, 1);
        //Puedes rotar la figura presionando D
        Tablero t = new Tablero();

        public Game1() {
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
            p.LoadContent(Content);
            t.LoadContent(Content);
        }

        //Descargar contenido
        protected override void UnloadContent() {
        }

        //Actualizar
        protected override void Update(GameTime gameTime) {
         
            p.Update(gameTime, t.Update(p.position, p.FIGURA_SELECT));
         
            base.Update(gameTime);
        }

        //Dibujar
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            t.Draw(spriteBatch);
            p.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
