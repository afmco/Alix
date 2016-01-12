namespace Alix.Core
{
    using System;
    using Alix.Core.Interfaces;

    public class Dice : IDice
    {
        private readonly Random random = new Random();

        public int Sides { get; set; }
        public int Rolls { get; set; }
        public int Modifier { get; set; }

        public Dice(int rolls, int sides, int modifier = 0)
        {
            this.Rolls = rolls;
            this.Sides = sides;
            this.Modifier = modifier;
        }

        public double Roll()
        {
            double total = 0;

            for (var i = 1; i <= this.Rolls; i++)
            {
                total += this.random.Next(1, this.Sides + 1);
            }

            return total + this.Modifier;
        }
    }
}
