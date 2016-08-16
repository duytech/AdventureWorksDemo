namespace AW.Bussiness.Person
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IPersonManager
    {
        IEnumerable<DataAccess.Entities.Person> FindBy(Expression<Func<DataAccess.Entities.Person, bool>> predicate);

        IEnumerable<DataAccess.Entities.Person> Search();
    }
}
