namespace AW.DataAccess.Implementations
{
    using System;
    using Common;
    using Entities;
    using Interfaces;

    public class PersonRepo : Repository<Person>, IPersonRepo
    {
        public PersonRepo(IDbFactory context) : base(context) { }
    }
}
