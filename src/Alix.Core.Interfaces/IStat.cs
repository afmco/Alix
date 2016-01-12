namespace Alix.Core.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IStat : IComparable<IStat>, IEquatable<IStat>
    {
        string Name { get; set; }
        double Value { get; set; }
        IDice Dice { get; set; }
        IList<IStatModifier> AdditionModifiers { get; set; }
        IList<IStatModifier> MultiplyModifiers { get; set; }
        double Get();
        double GetBase();
        void AddModifier(IStatModifier modifier);
        void RemoveModifier(IStatModifier modifier);
    }
}