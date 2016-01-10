namespace Alix.Core
{
    using System.Collections.Generic;
    using Alix.Core.Interfaces;
    using Alix.Core.Interfaces.Enums;

    public class Player : IPlayer
    {
        public IStat CurrentHitPoints { get; set; }
        public IStat MaximumHitPoints { get; set; }
        public IStat CurrentMagicPoints { get; set; }
        public IStat MaximumMagicPoints { get; set; }
        public IStat Strength { get; set; }
        public IStat Speed { get; set; }
        public IStat Intelligence { get; set; }
        public Dictionary<EquipmentSlot, IEquipment> Equipment { get; set; }

        public Player()
        {
            this.Equipment = new Dictionary<EquipmentSlot, IEquipment>();
        }

        public void Equip(IEquipment equipment)
        {
            if (this.Equipment.ContainsKey(equipment.Slot))
            {
                this.UnEquip(equipment.Slot);
            }

            this.Equipment[equipment.Slot] = equipment;

            foreach (var additionModifier in equipment.AdditionModifiers)
            {
                switch (additionModifier.Key)
                {
                    case StatSlot.Strength:
                        this.Strength.AddModifier(additionModifier.Value);
                        break;
                    case StatSlot.Speed:
                        this.Speed.AddModifier(additionModifier.Value);
                        break;
                    case StatSlot.Intelligence:
                        this.Intelligence.AddModifier(additionModifier.Value);
                        break;
                }
            }

            foreach (var multiplyModifier in equipment.MultiplyModifiers)
            {
                switch (multiplyModifier.Key)
                {
                    case StatSlot.Strength:
                        this.Strength.AddModifier(multiplyModifier.Value);
                        break;
                    case StatSlot.Speed:
                        this.Speed.AddModifier(multiplyModifier.Value);
                        break;
                    case StatSlot.Intelligence:
                        this.Intelligence.AddModifier(multiplyModifier.Value);
                        break;
                }
            }
        }

        public void UnEquip(EquipmentSlot slot)
        {
            this.Equipment.Remove(slot);
        }
    }
}