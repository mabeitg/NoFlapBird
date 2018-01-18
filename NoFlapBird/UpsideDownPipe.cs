using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlapBird
{
    class UpsideDownPipe:Pipe
    {
        public UpsideDownPipe(Texture2D texture, Vector2 velocity):base(texture, velocity)
        {
            //FRÅGA 6: Om det här är ett rör som ska starta högst upp, vilka startkoordinater bör det ha?
            //T ex (1250, 0)
        }

        //FRÅGA 7: Vadå override?
        //Överskuggar/Ersätter metod med samma namn i basklassen
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipVertically, 1);

        }
    }
}
