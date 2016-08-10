﻿namespace AW.DataAccess.Implementations
{
    using Entities;
    using Interfaces;
    using System.Data.Entity;

    public class PersonRepo : Repository<Person>, IPersonRepo
    {
        public PersonRepo(DbContext context) : base(context) { }
    }
}
