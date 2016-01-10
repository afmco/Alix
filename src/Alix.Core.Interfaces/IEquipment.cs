namespace Alix.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Alix.Core.Interfaces.Enums;

    public interface IEquipment : IComparable<IEquipment>, IEquatable<IEquipment>
    {
        int Id { get; set; }
        string Name { get; set; }
        Dictionary<StatSlot, IStatModifier> AdditionModifiers { get; set; }
        Dictionary<StatSlot, IStatModifier> MultiplyModifiers { get; set; }
        EquipmentSlot Slot { get; }
    }
}