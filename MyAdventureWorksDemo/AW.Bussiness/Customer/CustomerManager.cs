namespace AW.Bussiness.Customer
{
    using AutoMapper;
    using AW.Common;
    using AW.Common.Constants;
    using AW.Common.Utils;
    using Common;
    using DataAccess.Customer;
    using DI;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

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

        public IEnumerable<Customer> Search(int pageIndex, int pageSize, out string error, Sorting sorting = null)
        {
            error = string.Empty;

            var dict = PropertyMappingTable.GetCustomer();
            bool isExist = dict.ContainsKey(sorting.PropertyName);
            if(!isExist)
            {
                error = string.Format(Message.Common.PropertyInvalid, sorting.PropertyName);

                return null;
            }

            var entityProperty = dict[sorting.PropertyName];

            var result = customerRepo.Search(pageIndex, pageSize, null, sorting);
            var mappedResult = mapper.Map<IEnumerable<Customer>>(result);

            return mappedResult;
        }
    }
}
