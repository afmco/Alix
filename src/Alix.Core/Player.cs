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
        public IStat Defense { get; set; }
        public IStat Speed { get; set; }
        public IStat Intelligence { get; set; }
        public double ExperiencePoints { get; set; }
        public double NextLevelExperiencePoints => this.Leveler.NextLevelExperiencePoints(this.Level);
        public double Level { get; set; }
        public ILeveler Leveler { get; set; }
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
                    case StatSlot.Defense:
                        this.Defense.AddModifier(additionModifier.Value);
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
                    case StatSlot.Defense:
                        this.Defense.AddModifier(multiplyModifier.Value);
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

        public bool IsEquipped(IEquipment equipment)
        {
            if (!this.Equipment.ContainsKey(equipment.Slot)) return false;
            return this.Equipment[equipment.Slot].Equals(equipment);
        }

        public bool ReadyToLevelUp()
        {
            return this.ExperiencePoints >= this.Leveler.NextLevelExperiencePoints(this.Level);
        }

        public bool AddExperiencePoints(double experiencePoints)
        {
            this.ExperiencePoints += experiencePoints;
            return this.ReadyToLevelUp();
        }

        public ILevelUp CreateLevelUp()
        {
            return new LevelUp
            {
                ExperiencePoints = this.Leveler.NextLevelExperiencePoints(this.Level) * -1,
                Level = 1,
                StatDice = new Dictionary<DiceSlot, IDice>
                {
                    {DiceSlot.HitPoints, this.MaximumHitPoints.Dice},
                    {DiceSlot.MagicPoints, this.MaximumMagicPoints.Dice},
                    {DiceSlot.Strength, this.Strength.Dice},
                    {DiceSlot.Defense, this.Defense.Dice},
                    {DiceSlot.Speed, this.Speed.Dice},
                    {DiceSlot.Intelligence, this.Intelligence.Dice}
                }
            };
        }

        public void ApplyLevelUp(ILevelUp levelUp)
        {
            this.ExperiencePoints += levelUp.ExperiencePoints;

            if (this.ExperiencePoints < 0)
            {
                this.ExperiencePoints = 0;
            }

            this.Level += levelUp.Level;

            foreach (var statDie in levelUp.StatDice)
            {
                switch (statDie.Key)
                {
                    case DiceSlot.HitPoints:
                        this.MaximumHitPoints.Value += statDie.Value.Roll();
                        break;
                    case DiceSlot.MagicPoints:
                        this.MaximumMagicPoints.Value += statDie.Value.Roll();
                        break;
                    case DiceSlot.Strength:
                        this.Strength.Value += statDie.Value.Roll();
                        break;
                    case DiceSlot.Defense:
                        this.Defense.Value += statDie.Value.Roll();
                        break;
                    case DiceSlot.Speed:
                        this.Speed.Value += statDie.Value.Roll();
                        break;
                    case DiceSlot.Intelligence:
                        this.Intelligence.Value += statDie.Value.Roll();
                        break;
                }
            }
        }
    }
}