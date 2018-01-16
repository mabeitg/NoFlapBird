using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NoFlapBird
{
    class Snowflake
    {
        //-----Fält-----
        Texture2D texture;
        Vector2 position, velocity;

        //-----Konstruktor-----
        public Snowflake(Texture2D texture, Vector2 startPosition)
        {
            this.texture = texture;
            position = startPosition;
        }

        //-----Metoder-----

        //Kod för en fin fallande flinga!
        public void Update(/*Valfritt med parametrar*/)
        {
            
        }

        //Ritar ut flingan
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }



    }
}
