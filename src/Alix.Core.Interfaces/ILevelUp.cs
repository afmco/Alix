namespace Alix.Core.Interfaces
{
    using System.Collections.Generic;
    using Alix.Core.Interfaces.Enums;

    public interface ILevelUp
    {
        double ExperiencePoints { get; set; }
        double Level { get; set; }
        Dictionary<StatSlot, IDice> StatDice { get; set; }
    }
}
