using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Items
{
    public interface IEquipable : IItem
    {
        #region Properties

        /// <summary>
        /// Whether or not the item is equipped
        /// </summary>
        bool IsEquipped { get; set; }

        #endregion
    }
}
