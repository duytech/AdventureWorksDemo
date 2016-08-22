namespace AW.Bussiness.Customer
{
    #region
    using AutoMapper;
    using AW.Common;
    using AW.Common.Constants;
    using AW.Common.Dtos;
    using Common;
    using DataAccess.Customer;
    using DI;
    using Models;
    using System.Collections.Generic;
    using System;
    #endregion

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
        public Customer GetById(int id)
        {
            return mapper.Map<Customer>(customerRepo.GetById(id));
        }

        public IEnumerable<Customer> Search(int pageIndex, int pageSize, out string error, Sorting sorting = null)
        {
            error = string.Empty;

            var dict = PropertyDictionary.GetCustomer();
            if(sorting != null && !dict.ContainsKey(sorting.PropertyName))
            {
                error = string.Format(Message.Common.PropertyInvalid, sorting.PropertyName);

                return null;
            }

            if (sorting != null && dict.ContainsKey(sorting.PropertyName))
                sorting.PropertyName = dict[sorting.PropertyName];

            // Process search option

            return mapper.Map<IEnumerable<Customer>>(customerRepo.Search(pageIndex, pageSize, null, sorting));
        }

        public Customer Create(Customer customer)
        {
            var entity = mapper.Map<DataAccess.Entities.Customer>(customer);
            entity.rowguid = Guid.NewGuid();
            entity.ModifiedDate = DateTime.Now;
            var result = customerRepo.Create(entity);
            customerRepo.Save();
            var model = mapper.Map<Customer>(result);

            return model;
        }

        public Customer Update(Customer customer)
        {
            var existingEntity = customerRepo.GetById(customer.CustomerID);
            // Avoid exception when update entity using Entity Framework and Automapper
            var mappedEntity = mapper.Map(customer, existingEntity);

            //var entity = mapper.Map<DataAccess.Entities.Customer>(customer);
            //entity.rowguid = Guid.NewGuid();
            //entity.ModifiedDate = DateTime.Now;
            customerRepo.Update(mappedEntity);
            customerRepo.Save();
            var result = customerRepo.GetById(mappedEntity.CustomerID);
            var model = mapper.Map<Customer>(result);

            return model;
        }
    }
}
