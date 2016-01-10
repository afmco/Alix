namespace Alix.Core
{
    using System.Collections.Generic;
    using Alix.Core.Interfaces;
    using Alix.Core.Interfaces.Enums;

    public abstract class BaseEquipment : IEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<StatSlot, IStatModifier> AdditionModifiers { get; set; }
        public Dictionary<StatSlot, IStatModifier> MultiplyModifiers { get; set; }
        public EquipmentSlot Slot { get; }

        public BaseEquipment(int id, string name, EquipmentSlot slot)
        {
            this.Id = id;
            this.Name = name;
            this.Slot = slot;

            this.AdditionModifiers = new Dictionary<StatSlot, IStatModifier>();
            this.MultiplyModifiers = new Dictionary<StatSlot, IStatModifier>();
        }

        public BaseEquipment(EquipmentSlot slot) : this(0, string.Empty, slot)
        {
        }

        public int CompareTo(IEquipment other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(IEquipment other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
