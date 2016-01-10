namespace Alix.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Alix.Core.Interfaces;

    public abstract class BaseStat : IStat
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public IList<IStatModifier> AdditionModifiers { get; set; }
        public IList<IStatModifier> MultiplyModifiers { get; set; }

        public BaseStat(double value)
        {
            this.Value = value;

            this.AdditionModifiers = new List<IStatModifier>();
            this.MultiplyModifiers = new List<IStatModifier>();
        }

        public BaseStat() : this(0)
        {
        }

        public virtual double Get()
        {
            double total = this.Value + this.AdditionModifiers.Sum(additionModifier => additionModifier.Value);
            double multiplyTotal = this.MultiplyModifiers.Sum(multiplyModifier => multiplyModifier.Value);

            return total + (total*multiplyTotal);
        }

        public double GetBase()
        {
            return this.Value;
        }

        public void AddModifier(IStatModifier modifier)
        {
            if (this.IsAdditionModifier(modifier))
            {
                if (this.AdditionModifiers.Contains(modifier))
                {
                    this.RemoveModifier(modifier);
                }

                this.AdditionModifiers.Add(modifier);
            }
            else
            {
                if (this.MultiplyModifiers.Contains(modifier))
                {
                    this.RemoveModifier(modifier);
                }

                this.MultiplyModifiers.Add(modifier);
            }
        }

        public void RemoveModifier(IStatModifier modifier)
        {
            if (this.IsAdditionModifier(modifier))
            {
                this.AdditionModifiers.Remove(modifier);
            }
            else
            {
                this.MultiplyModifiers.Remove(modifier);
            }
        }

        private bool IsAdditionModifier(IStatModifier modifier)
        {
            // TODO: Actually implement this.
            if (modifier.Id%2 == 0)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(IStat other)
        {
            return string.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(IStat other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}