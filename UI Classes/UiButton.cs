using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic_Clergy.UI_Classes
{
    class UiButton : UiInteractable
    {
        protected GameState? stateToLoad;
        protected int? levelToLoad;

        public GameState? StateToLoad { get { return stateToLoad; } }
        public int? LevelToLoad { get { return levelToLoad; } }

        /// <summary>
        /// Creates a UI button
        /// </summary>
        /// <param name="texture">The texture to be displayed</param>
        /// <param name="rectangle">The rectangle to use</param>
        public UiButton(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
            stateToLoad = null;
            levelToLoad = null;
        }

        /// <summary>
        /// Creates a UI button
        /// </summary>
        /// <param name="texture">The texture to be displayed</param>
        /// <param name="rectangle">The rectangle to use</param>
        /// <param name="hoverColor">The color to use when the mouse is hovering over the button</param>
        public UiButton(Texture2D texture, Rectangle rectangle, Color hoverColor)
            : base(texture, rectangle, hoverColor)
        {
            stateToLoad = null;
            levelToLoad = null;
        }

        /// <summary>
        /// Creates a UI button
        /// </summary>
        /// <param name="texture">The texture to be displayed</param>
        /// <param name="rectangle">The rectangle to use</param>
        /// <param name="hoverColor">The color to use when the mouse is hovering over the button</param>
        /// <param name="clickedColor">The color to use when the mouse clicked the button</param>
        public UiButton(Texture2D texture, Rectangle rectangle, Color hoverColor, Color clickedColor)
            : base(texture, rectangle, hoverColor, clickedColor)
        {
            stateToLoad = null;
            levelToLoad = null;
        }

        /// <summary>
        /// Creates a UI button
        /// </summary>
        /// <param name="texture">The texture to be displayed</param>
        /// <param name="rectangle">The rectangle to use</param>
        /// <param name="hoverColor">The color to use when the mouse is hovering over the button</param>
        /// <param name="clickedColor">The color to use when the mouse clicked the button</param>
        /// <param name="stateToLoad">The game state to load when the button is clicked</param>
        public UiButton(Texture2D texture, Rectangle rectangle, Color hoverColor, Color clickedColor, GameState? stateToLoad)
            : base(texture, rectangle, hoverColor, clickedColor)
        {
            this.stateToLoad = stateToLoad;
            levelToLoad = null;
        }

        /// <summary>
        /// Creates a UI button
        /// </summary>
        /// <param name="texture">The texture to be displayed</param>
        /// <param name="rectangle">The rectangle to use</param>
        /// <param name="hoverColor">The color to use when the mouse is hovering over the button</param>
        /// <param name="clickedColor">The color to use when the mouse clicked the button</param>
        /// <param name="levelToLoad">The level to load when the button is clicked</param>
        public UiButton(Texture2D texture, Rectangle rectangle, Color hoverColor, Color clickedColor, Color baseColor, int? levelToLoad)
            : base(texture, rectangle, hoverColor, clickedColor, baseColor)
        {
            stateToLoad = null;
            this.levelToLoad = levelToLoad;
        }
    }
}
