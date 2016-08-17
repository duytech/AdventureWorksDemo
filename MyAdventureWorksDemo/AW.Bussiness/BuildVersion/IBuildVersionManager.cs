using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Bussiness.BuildVersion
{
    public interface IBuildVersionManager
    {
        IEnumerable<Models.BuildVersion> GetAll();
    }
}
