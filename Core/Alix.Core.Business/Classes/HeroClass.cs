using Alix.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Classes
{
    public class HeroClass : IClass
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region Constructors

        public HeroClass()
        {
            Id = Ids.Classes.Hero;
            Name = Names.Classes.Hero;
        }

        #endregion
    }
}
