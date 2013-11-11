using Alix.Core.Business.Classes;
using Alix.Core.Business.Stats;
using Alix.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Characters
{
    public class AlixCharacter : IPlayable
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; set; }
        public IClass Class { get; set; }
        public long TotalHitPoints { get; set; }
        public long RemainingHitPoints { get; set; }
        public long TotalMagicPoints { get; set; }
        public long RemainingMagicPoints { get; set; }
        public int Level { get; set; }
        public long Experience { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Willpower { get; set; }
        public int Luck { get; set; }

        #endregion

        #region Constructors

        public AlixCharacter()
        {
            Id = Ids.Characters.Alix;
            Name = Names.Characters.Alix;
            Class = new HeroClass();
        }

        #endregion
    }
}
