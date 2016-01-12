namespace Alix.Core.Levelers
{
    using System;
    using Alix.Core.Interfaces;

    public class PlayerLeveler : ILeveler
    {
        public double NextLevelExperiencePoints(double currentLevel)
        {
            double exponent = 1.5;
            double baseExperiencePoints = 1000;
            return Math.Floor(baseExperiencePoints*Math.Pow(currentLevel, exponent));
        }
    }
}
