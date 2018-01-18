using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlapBird
{
    abstract class Pipe
    {
        protected Texture2D texture;
        protected Vector2 position, velocity;

        //FRÅGA 4: Vad kallas en sån här?
        //Konstruktor. (Metod som anropas när objekt skapas)
        public Pipe(Texture2D texture, Vector2 velocity)
        {
            this.texture = texture;
            this.velocity = velocity;
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
            position += velocity;
        }

        //FRÅGA 5: Vadå virtual?
        //Metoden kan komma att skrivas över (överskuggas) 
        //av en annan version i en subklass
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
