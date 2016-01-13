namespace Alix.Core
{
    using System.Collections.Generic;
    using Alix.Core.Interfaces;
    using Alix.Core.Interfaces.Enums;

    public class LevelUp : ILevelUp
    {
        public double ExperiencePoints { get; set; }
        public double Level { get; set; }
        public Dictionary<DiceSlot, IDice> StatDice { get; set; }
    }
}
