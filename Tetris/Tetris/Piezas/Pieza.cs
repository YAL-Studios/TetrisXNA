using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris.Piezas
{
    public class Pieza {
        int color;
        Texture2D texture;
        Vector2 position;
        public Pieza(int _color) {
            color = _color;
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
       
        public void Update() { 
        
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
