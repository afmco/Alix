namespace Alix.Core.Tests
{
    using System.Collections.Generic;
    using Alix.Core.Equipment;
    using Alix.Core.Interfaces;
    using Alix.Core.Interfaces.Enums;
    using Alix.Core.Stats;
    using NUnit.Framework;

    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void StatUpdateTest()
        {
            // Arrange
            var player = new Player
            {
                CurrentHitPoints = new HitPoints(100),
                MaximumHitPoints = new HitPoints(100),
                CurrentMagicPoints = new MagicPoints(100),
                MaximumMagicPoints = new MagicPoints(100),
                Strength = new Strength(100),
                Intelligence = new Intelligence(100),
                Speed = new Speed(100)
            };

            // Act
            player.Speed.AddModifier(new StatModifier {Id = 2, Value = 10});
            player.Speed.AddModifier(new StatModifier {Id = 4, Value = 100});
            player.Speed.AddModifier(new StatModifier {Id = 1, Value = 0.1});
            player.Speed.AddModifier(new StatModifier {Id = 3, Value = -0.5});

            // Assert
            Assert.AreEqual(player.Speed.GetBase(), 100);
            Assert.AreEqual(player.Speed.Get(), 126);
        }

        [Test]
        public void EquipAddModifierTest()
        {
            // Arrange
            var player = new Player
            {
                CurrentHitPoints = new HitPoints(100),
                MaximumHitPoints = new HitPoints(100),
                CurrentMagicPoints = new MagicPoints(100),
                MaximumMagicPoints = new MagicPoints(100),
                Strength = new Strength(100),
                Intelligence = new Intelligence(100),
                Speed = new Speed(100)
            };

            var weapon = new Weapon
            {
                Id = 1,
                Name = "Test Weapon",
                AdditionModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {StatSlot.Strength, new StatModifier {Id = 2, Value = 5}}
                }
            };

            // Act
            player.Equip(weapon);

            // Assert
            Assert.AreEqual(player.Strength.GetBase(), 100);
            Assert.AreEqual(player.Strength.Get(), 105);
        }

        [Test]
        public void EquipMultiplyModifierTest()
        {
            // Arrange
            var player = new Player
            {
                CurrentHitPoints = new HitPoints(100),
                MaximumHitPoints = new HitPoints(100),
                CurrentMagicPoints = new MagicPoints(100),
                MaximumMagicPoints = new MagicPoints(100),
                Strength = new Strength(100),
                Intelligence = new Intelligence(100),
                Speed = new Speed(100)
            };

            var weapon = new Weapon
            {
                Id = 1,
                Name = "Test Weapon",
                MultiplyModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {StatSlot.Strength, new StatModifier {Id = 1, Value = 0.1}}
                }
            };

            // Act
            player.Equip(weapon);

            // Assert
            Assert.AreEqual(player.Strength.GetBase(), 100);
            Assert.AreEqual(player.Strength.Get(), 110);
        }

        [Test]
        public void EquipMultipleModifiersTest()
        {
            // Arrange
            var player = new Player
            {
                CurrentHitPoints = new HitPoints(100),
                MaximumHitPoints = new HitPoints(100),
                CurrentMagicPoints = new MagicPoints(100),
                MaximumMagicPoints = new MagicPoints(100),
                Strength = new Strength(100),
                Intelligence = new Intelligence(100),
                Speed = new Speed(100)
            };

            var weapon = new Weapon
            {
                Id = 1,
                Name = "Test Weapon",
                AdditionModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {StatSlot.Strength, new StatModifier {Id = 2, Value = 5}}
                },
                MultiplyModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {StatSlot.Strength, new StatModifier {Id = 1, Value = 0.1}}
                }
            };

            var armor = new Armor
            {
                Id = 2,
                Name = "Test Armor",
                AdditionModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {StatSlot.Strength, new StatModifier {Id = 4, Value = 5}}
                }
            };

            // Act
            player.Equip(weapon);
            player.Equip(armor);
            
            // Assert
            Assert.AreEqual(player.Strength.GetBase(), 100);
            Assert.AreEqual(player.Strength.Get(), 121);
        }
    }
}
