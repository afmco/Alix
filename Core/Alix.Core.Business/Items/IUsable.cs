using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Items
{
    interface IUsable : IItem
    {
        #region Methods

        void Use();

        #endregion
    }
}
