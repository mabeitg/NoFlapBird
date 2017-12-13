using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlapBird
{
    class Player
    {
        Texture2D texture;
        Vector2 position, velocity;
        int points;

        //Konstruktor
        public Player(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(50, 100);
            velocity = new Vector2(1, -5);
        }

        public void Update()
        {
            //Gravitation
            velocity += Game1.gravity;

            //Fågeln rör sig
            position += velocity;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                velocity.Y = -3;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
