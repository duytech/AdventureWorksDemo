namespace AW.Bussiness.Person
{
    using AW.DataAccess.Interfaces;
    using System.Collections.Generic;
    using DataAccess.Entities;
    using System;
    using System.Linq.Expressions;

    public class PersonManager : IPersonManager
    {
        private IPersonRepo personRepo;
        public PersonManager(IPersonRepo personRepo)
        {
            this.personRepo = personRepo;
        }

        public IEnumerable<Person> Search()
        {
            return personRepo.GetAll();
        }

        IEnumerable<Person> IPersonManager.FindBy(Expression<Func<Person, bool>> predicate)
        {
            var result = personRepo.GetList(predicate);

            return result;
        }
    }
}
