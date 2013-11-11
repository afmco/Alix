using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Win8.Models
{
    public interface IGameObject
    {
        #region Methods

        /// <summary>
        /// Draws the game object by using the <c>SpriteBatch</c>
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch</param>
        void Draw(SpriteBatch spriteBatch);
        
        /// <summary>
        /// Where to move the game object to
        /// </summary>
        /// <param name="amount">The distance to move the game object</param>
        void Move(Vector2 amount);

        #endregion
    }
}
