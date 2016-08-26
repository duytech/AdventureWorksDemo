namespace AW.Bussiness.Employee
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DataAccess.Employee;
    using DI;
    using Models.Mapper;
    using System.Linq;
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeRepo repo;
        private IConfigurationProvider configurationProvider;

        public EmployeeManager() : this(ServiceLocator.Current.Get<IEmployeeRepo>(), ServiceLocator.Current.Get<IConfigurationProvider>()) { }

        public EmployeeManager(IEmployeeRepo repo, IConfigurationProvider configurationProvider)
        {
            this.repo = repo;
            this.configurationProvider = configurationProvider;
        }

        public IQueryable<Models.Employee> Search()
        {
            return repo.GetAllQueryable().ProjectTo<Models.Employee>(configurationProvider);
        }
    }
}
