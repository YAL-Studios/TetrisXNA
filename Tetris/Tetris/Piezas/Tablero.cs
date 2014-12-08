using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris.Piezas
{
    class Tablero
    {
        char[,] tablero = new char[20, 10] { 
        #region Inicializacion del tablero
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', },
        #endregion
        };

        public void LoadContent(ContentManager Content){

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
