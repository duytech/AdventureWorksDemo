namespace AW.DataAccess.Implementations
{
    using System;
    using Common;
    using Entities;
    using Interfaces;

    public class PersonRepo : Repository<Person>, IPersonRepo
    {
        public PersonRepo(IAWDbFactory context) : base(context) { }
    }
}
