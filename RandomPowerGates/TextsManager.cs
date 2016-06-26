using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RandomPowerGates
{
    class TextManager
    {
        private SpriteFont textFont;
        public List<Text> Texts = new List<Text>();

        public TextManager(SpriteFont spriteFont)
        {
            textFont = spriteFont;
        }

        public void addText(string text, Vector2 textPosition, Color textColor, string identifier)
        {
            Texts.Add(new Text(text, textPosition, textColor, identifier));
        }

        public void Update(GameTime gameTime)
        {
            foreach (Text t in Texts)
            {
                if(t.identifier == "hp")
                    t.text = "HP : " + Global.instance.player.hp.ToString();
                if (t.identifier == "points")
                    t.text = "Body : " + Global.instance.player.points.ToString();
#if DEBUG
                if (t.identifier == "room")
                    t.text = "Cimra:  : " + Global.instance.warpIndex.ToString(); 
#endif
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Text st in Texts)
            {
                spriteBatch.DrawString(textFont, st.text, st.textPosition, st.textColor);
            }
        }
    }

    class Text
    {
        public string text;
        public Vector2 textPosition;
        public Color textColor;
        public string identifier;
        public Text(string text, Vector2 textPosition, Color textColor, string identifier)
        {
            
            this.text = text;
            this.textPosition = textPosition;
            this.textColor = textColor;
            this.identifier = identifier;
        }
    }
}
