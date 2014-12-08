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

namespace Tetris
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState kb, kbAnt;
        int forma;
        Pieza p = new Pieza(2, 2);

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
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
        }

        //Descargar contenido
        protected override void UnloadContent() {
        }

        //Actualizar
        protected override void Update(GameTime gameTime) {
            kb = Keyboard.GetState();
            if (kbAnt.IsKeyUp(Keys.D) && kb.IsKeyDown(Keys.D)) forma++;
                p.Update(ref forma);
            kbAnt = kb;
            base.Update(gameTime);
        }

        //Dibujar
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            p.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
