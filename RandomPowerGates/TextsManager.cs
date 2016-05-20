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
        public List<staticText> staticTexts = new List<staticText>();

        public TextManager(SpriteFont spriteFont)
        {
            this.textFont = spriteFont;
        }

        public void addStaticText(string text, Vector2 textPosition, Color textColor)
        {
            staticTexts.Add(new staticText(text, textPosition, textColor));
        }
        public void addDynamicText()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(staticText st in staticTexts)
            {
                spriteBatch.DrawString(textFont, st.text, st.textPosition, st.textColor);
            }
        }
    }
    class staticText
    {
        public string text { get; private set; }
        public Vector2 textPosition { get; private set; }
        public Color textColor { get; private set; }
        public staticText(string text, Vector2 textPosition, Color textColor)
        {
            this.text = text;
            this.textPosition = textPosition;
            this.textColor = textColor;
    }
    }
}
