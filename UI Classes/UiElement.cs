using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic_Clergy.UI_Classes
{
    class UiElement
    {
        protected Rectangle rectangle;
        protected Texture2D texture;
        protected Color color;

        public UiElement(Texture2D texture, Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.texture = texture;
            color = Color.White;
        }

        public UiElement(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.rectangle = rectangle;
            this.texture = texture;
            this.color = color;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}
