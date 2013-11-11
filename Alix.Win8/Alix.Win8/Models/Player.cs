using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Win8.Models
{
    public class Player : GameObject
    {
        #region Fields

        public int Score;

        #endregion

        #region Public Methods

        public override void Move(Vector2 amount)
        {
            base.Move(amount);
            if (Position.Y <= 0)
            {
                Position.Y = 0;
            }
            if (Position.Y + Texture.Height >= Alix.ScreenHeight)
            {
                Position.Y = Alix.ScreenHeight - Texture.Height;
            }
        }

        #endregion
    }
}
