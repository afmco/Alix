using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Items
{
    public interface IItem
    {
        #region Properties

        /// <summary>
        /// The ID of the item
        /// </summary>
        int Id { get; set; }

        #endregion
    }
}
