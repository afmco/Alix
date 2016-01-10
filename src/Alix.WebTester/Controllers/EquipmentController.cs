namespace Alix.WebTester.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Alix.Core;
    using Alix.Core.Equipment;
    using Alix.Core.Interfaces;
    using Alix.Core.Interfaces.Enums;
    using Alix.Core.Stats;
    using Alix.WebTester.ViewModels.Equipment;

    public class EquipmentController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult FirstTest()
        {
            var player = new Player
            {
                CurrentHitPoints = new HitPoints(100),
                MaximumHitPoints = new HitPoints(100),
                CurrentMagicPoints = new MagicPoints(100),
                MaximumMagicPoints = new MagicPoints(100),
                Strength = new Strength(50),
                Speed = new Speed(20),
                Intelligence = new Intelligence(30)
            };

            var weapon = new Weapon
            {
                Id = 1,
                Name = "Test Weapon",
                AdditionModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {
                        StatSlot.Strength, new StatModifier
                        {
                            Id = 2,
                            Value = 10
                        }
                    }
                }
            };

            var armor = new Armor
            {
                Id = 2,
                Name = "Test Armor",
                AdditionModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {
                        StatSlot.Speed, new StatModifier
                        {
                            Id = 4,
                            Value = -10
                        }
                    }
                }
            };

            var helmet = new Helmet
            {
                Id = 3,
                Name = "Test Helmet",
                AdditionModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {
                        StatSlot.Speed, new StatModifier
                        {
                            Id = 6,
                            Value = 10
                        }
                    }
                }
            };

            var shield = new Shield
            {
                Id = 4,
                Name = "Test Shield",
                AdditionModifiers = new Dictionary<StatSlot, IStatModifier>
                {
                    {
                        StatSlot.Strength, new StatModifier
                        {
                            Id = 8,
                            Value = 5
                        }
                    }
                }
            };

            var viewModel = new FirstTestViewModel
            {
                Player = player,
                Equipment = new List<IEquipment>
                {
                    weapon,
                    armor,
                    helmet,
                    shield
                }
            };

            player.Equip(weapon);

            return this.View(viewModel);
        }
    }
}