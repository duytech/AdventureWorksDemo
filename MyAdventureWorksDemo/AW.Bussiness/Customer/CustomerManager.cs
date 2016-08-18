namespace AW.Bussiness.Customer
{
    using AutoMapper;
    using DataAccess.Customer;
    using DI;
    using Models;
    using System.Collections.Generic;

    public class CustomerManager : ICustomerManager
    {
        private ICustomerRepo customerRepo;
        private IMapper mapper;

        public CustomerManager() : this(ServiceLocator.Current.Get<ICustomerRepo>(), ServiceLocator.Current.Get<IMapper>())
        { }

        public CustomerManager(ICustomerRepo customerRepo, IMapper mapper)
        {
            this.customerRepo = customerRepo;
            this.mapper = mapper;
        }
        public Models.Customer GetById(int id)
        {
            var result = customerRepo.GetById(id);
            var mappedResult = mapper.Map<Customer>(result);

            return mappedResult;
        }

        public IEnumerable<Customer> Search(int pageIndex, int pageSize)
        {
            var result = customerRepo.Search(pageIndex, pageSize);
            var mappedResult = mapper.Map<IEnumerable<Customer>>(result);

            return mappedResult;
        }
    }
}
