using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Win8.Models
{
    public class Ball : GameObject
    {
        #region Properties

        public Vector2 Velocity;
        public Random Random;

        #endregion

        #region Constructors

        public Ball()
        {
            Random = new Random();
        }

        #endregion

        #region Public Methods

        public void Launch(float speed)
        {
            Position = new Vector2(Alix.ScreenWidth / 2 - Texture.Width / 2, Alix.ScreenHeight / 2 - Texture.Height / 2);
            float rotation = (float)(Math.PI / 2 + (Random.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));
            Velocity.X = (float)Math.Sin(rotation);
            Velocity.Y = (float)Math.Cos(rotation);

            if (Random.Next(2) == 1)
            {
                Velocity.X *= -1;
            }

            Velocity *= speed;
        }

        public void CheckWallCollision()
        {
            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;
            }
            if (Position.Y + Texture.Height > Alix.ScreenHeight)
            {
                Position.Y = Alix.ScreenHeight - Texture.Height;
                Velocity.Y *= -1;
            }
        }

        public override void Move(Vector2 amount)
        {
            base.Move(amount);
            CheckWallCollision();
        }

        #endregion
    }
}
