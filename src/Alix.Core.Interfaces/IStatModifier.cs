namespace Alix.Core.Interfaces
{
    using System;

    public interface IStatModifier : IComparable<IStatModifier>, IEquatable<IStatModifier>
    {
        int Id { get; set; }
        double Value { get; set; }
        string OutputValue { get; }
    }
}
