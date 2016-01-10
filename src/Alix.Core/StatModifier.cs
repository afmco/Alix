namespace Alix.Core
{
    using System;
    using Alix.Core.Interfaces;

    public class StatModifier : IStatModifier
    {
        public int Id { get; set; }
        public double Value { get; set; }

        public string OutputValue
        {
            get
            {
                if (this.Value >= 0)
                {
                    return "+ " + Math.Abs(this.Value);
                }
                else
                {
                    return "- " + Math.Abs(this.Value);
                }
            }
        }

        public int CompareTo(IStatModifier other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(IStatModifier other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
