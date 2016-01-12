namespace Alix.Core.Interfaces
{
    using System.Collections.Generic;
    using Alix.Core.Interfaces.Enums;

    public interface IPlayer
    {
        IStat CurrentHitPoints { get; set; }
        IStat MaximumHitPoints { get; set; }
        IStat CurrentMagicPoints { get; set; }
        IStat MaximumMagicPoints { get; set; }
        IStat Strength { get; set; }
        IStat Speed { get; set; }
        IStat Intelligence { get; set; }
        double ExperiencePoints { get; set; }
        double Level { get; set; }
        ILeveler Leveler { get; set; }
        Dictionary<EquipmentSlot, IEquipment> Equipment { get; set; }

        void Equip(IEquipment equipment);
        void UnEquip(EquipmentSlot slot);
        bool IsEquipped(IEquipment equipment);
        bool ReadyToLevelUp();
        bool AddExperiencePoints(double experiencePoints);
        ILevelUp CreateLevelUp();
        void ApplyLevelUp(ILevelUp levelUp);
    }
}