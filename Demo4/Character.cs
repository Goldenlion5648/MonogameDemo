using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Demo4
{
    class Character
    {
        Rectangle recChar;
        Texture2D recTexture;

        public int health { get; set; }

        public Character(Rectangle rec, Texture2D texture)
        {
            recChar = rec;
            recTexture = texture;
        }

        public void drawCharacter(SpriteBatch sb)
        {
            sb.Draw(recTexture, recChar, Color.White);
        }

        public void drawCharacter(SpriteBatch sb, Color color)
        {
            sb.Draw(recTexture, recChar, color);
        }
    }
}
