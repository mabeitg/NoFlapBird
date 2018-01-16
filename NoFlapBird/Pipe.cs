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
        public Pipe(Texture2D texture, Vector2 velocity)
        {
            this.texture = texture;
            this.velocity = velocity;
        }

        public void Update()
        {
            position += velocity;
        }

        //FRÅGA 5: Vadå virtual?
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
