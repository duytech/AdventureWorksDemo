namespace AW.Bussiness.Person
{
    using AutoMapper;
    using AW.Bussiness.DI;
    using DataAccess.Interfaces;
    using System.Collections.Generic;

    public class PersonManager : IPersonManager
    {
        private IPersonRepo personRepo;
        private IMapper mapper;

        public PersonManager() : this(ServiceLocator.Current.Get<IPersonRepo>(), ServiceLocator.Current.Get<IMapper>())
        { }
        public PersonManager(IPersonRepo personRepo, IMapper mapper)
        {
            this.personRepo = personRepo;
            this.mapper = mapper;
        }

        public IEnumerable<AW.Models.Person> Search()
        {
            var result = personRepo.GetAll();

            var mappedResult = mapper.Map<IEnumerable<Models.Person>>(result);

            return mappedResult;
        }

        public IEnumerable<AW.Models.Person> GetById(int id)
        {
            var result = personRepo.GetById(id);

            var mappedResult = mapper.Map<IEnumerable<Models.Person>>(result);

            return mappedResult;
        }
    }
}
