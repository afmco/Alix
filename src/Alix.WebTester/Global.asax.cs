using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Alix.WebTester
{
    using Alix.Core;
    using Alix.Core.Equipment;
    using Alix.Core.Interfaces;
    using Alix.Core.Interfaces.Enums;
    using Alix.Core.Stats;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public static class Equipment
    {
        public static class FirstTest
        {
            public static readonly Weapon TestWeapon = new Weapon
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

            public static readonly Armor TestArmor = new Armor
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

            public static readonly Helmet TestHelmet = new Helmet
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

            public static readonly Shield TestShield = new Shield
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

            public static readonly IList<IEquipment> Equipment = new List<IEquipment>()
            {
                TestWeapon,
                TestArmor,
                TestHelmet,
                TestShield
            };

            public static readonly Player Player = new Player
            {
                CurrentHitPoints = new HitPoints(100),
                MaximumHitPoints = new HitPoints(100),
                CurrentMagicPoints = new MagicPoints(100),
                MaximumMagicPoints = new MagicPoints(100),
                Strength = new Strength(50),
                Speed = new Speed(20),
                Intelligence = new Intelligence(30)
            };
        }
    }
}
