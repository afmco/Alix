using Alix.Core.Business.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Parties
{
    public class Party
    {
        public IPlayable Alix { get; set; }
        public IPlayable Character2 { get; set; }
        public IPlayable Character3 { get; set; }
        public IPlayable Character4 { get; set; }
        public IPlayable Character5 { get; set; }
    }
}
