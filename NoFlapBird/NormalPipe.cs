using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlapBird
{
    class NormalPipe:Pipe
    {

        //FRÅGA 5: Vad betyder det där med base(...)?
        //Anropar basklassens konstruktor
        public NormalPipe(Texture2D texture, Vector2 velocity):base(texture, velocity)
        {
            float x = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + 100;
            float y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height+ - 2*texture.Height;

            position = new Vector2(x,y);
            
        }


    }
}
