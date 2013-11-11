using Alix.Core.Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Characters
{
    public interface ICharacter
    {
        #region Properties

        /// <summary>
        /// The ID of the character
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The name of the character
        /// </summary>
        string Name { get; set; }


        #endregion
    }
}
