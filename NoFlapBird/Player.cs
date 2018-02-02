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
        Vector2 position, velocity, center;
        int points;
        float rotation;

        //Konstruktor
        public Player(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(50, 100);
            velocity = new Vector2(1, -5);
            center = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public Rectangle Hitbox
        {
            get
            {
                Rectangle hitbox = new Rectangle();
                hitbox.Location = position.ToPoint();

                hitbox.Width = texture.Width;
                hitbox.Height = texture.Height;

                return hitbox;
            }
        }

        public void Update()
        {
            //Gravitation
            velocity += Game1.gravity;

            //Fågeln rör sig
            position += velocity;

            //Rotation i färdriktning
            //rotation = (float)Math.Atan2(velocity.Y, velocity.X);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                velocity.Y = -3;

                //Rotation vid knapptryck
                rotation -= MathHelper.TwoPi / 50f;
            }
            else
                rotation += MathHelper.TwoPi / 100f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture, position, null,
                Color.White, rotation, center,
                1, SpriteEffects.None, 1);
        }
    }
}
