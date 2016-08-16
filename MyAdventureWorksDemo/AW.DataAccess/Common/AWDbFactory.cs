using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AW.DataAccess.Entities;

namespace AW.DataAccess.Common
{
    public class AWDbFactory : IAWDbFactory
    {
        private AdventureWorks2014Entities entities;
        public AdventureWorks2014Entities GetDb()
        {
            return entities ?? (entities = new AdventureWorks2014Entities());
        }
    }
}
