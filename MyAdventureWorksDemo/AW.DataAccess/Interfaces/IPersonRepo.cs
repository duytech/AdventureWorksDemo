using AW.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DataAccess.Interfaces
{
    using AW.DataAccess.Entities;
    public interface IPersonRepo : IRepository<Person>
    {

    }
}
