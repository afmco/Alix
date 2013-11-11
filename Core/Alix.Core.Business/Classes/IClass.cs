using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alix.Core.Business.Classes
{
    public interface IClass
    {
        #region Properties

        int Id { get; }
        string Name { get; set; }
        string Description { get; set; }

        #endregion
    }
}
