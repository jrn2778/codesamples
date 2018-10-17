using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic_Clergy.UI_Classes
{
    abstract class UiInteractable : UiElement
    {
        protected Color baseColor;
        protected Color hoverColor;
        protected Color clickedColor;
        protected bool active;
        protected bool clicking;    // Whether or not the mouse button is being held down over the object

        private MouseState mouseState;
        private MouseState previousMouseState;

        // Handles what happens when the interactable is clicked.
        // NOTE: Do not forget to add a function to OnClick when
        // creating the interactable object
        public delegate void ClickDelegate(UiInteractable elementClicked);
        public event ClickDelegate OnClick;

        public Rectangle Rectangle { get { return rectangle; } }
        public bool Active { get { return active; } }

        public UiInteractable(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            hoverColor = Color.White;
            clickedColor = hoverColor;
            baseColor = hoverColor;
            active = true;
        }

        public UiInteractable(Texture2D texture, Rectangle rectangle, Color hoverColor)
            : base(texture, rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.hoverColor = hoverColor;
            clickedColor = hoverColor;
            baseColor = Color.White;
            active = true;
        }

        public UiInteractable(Texture2D texture, Rectangle rectangle, Color hoverColor, Color clickedColor)
            : base(texture, rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.hoverColor = hoverColor;
            this.clickedColor = clickedColor;
            baseColor = Color.White;
            active = true;
        }
        public UiInteractable(Texture2D texture, Rectangle rectangle, Color hoverColor, Color clickedColor, Color baseColor)
    : base(texture, rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.hoverColor = hoverColor;
            this.clickedColor = clickedColor;
            this.baseColor = baseColor;
            active = true;
        }

        public void Update()
        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && IsMouseOver())
                clicking = true;
            if(mouseState.LeftButton == ButtonState.Released && 
                previousMouseState.LeftButton == ButtonState.Pressed)
            {
                clicking = false;

                if (IsMouseOver() && OnClick != null)
                    OnClick(this);
            }
        }

        /// <summary>
        /// Returns true if the mouse is over this UI object
        /// </summary>
        public bool IsMouseOver()
        {
            if(Mouse.GetState().X > rectangle.X &&
                Mouse.GetState().X < (rectangle.X + rectangle.Width) &&
                Mouse.GetState().Y > rectangle.Y &&
                Mouse.GetState().Y < (rectangle.Y + rectangle.Height))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws this UI object
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(active)
            {
                if (clicking)
                    spriteBatch.Draw(texture, rectangle, clickedColor);
                else if (IsMouseOver())
                    spriteBatch.Draw(texture, rectangle, hoverColor);
                else
                    spriteBatch.Draw(texture, rectangle, baseColor);
            }
        }
    }
}
