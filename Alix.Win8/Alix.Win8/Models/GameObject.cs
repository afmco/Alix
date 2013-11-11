using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Win8.Models
{
    public class GameObject : IGameObject
    {
        #region Fields

        public Vector2 Position;
        public Texture2D Texture;

        #endregion

        #region Properties

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        #endregion

        #region Public Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public virtual void Move(Vector2 amount)
        {
            Position += amount;
        }

        public static bool CheckPaddleBallCollision(Player player, Ball ball)
        {
            if (player.Bounds.Intersects(ball.Bounds))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
