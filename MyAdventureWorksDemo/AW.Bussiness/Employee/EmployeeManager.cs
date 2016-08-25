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
        private IMapper mapper;

        public EmployeeManager() : this(ServiceLocator.Current.Get<IEmployeeRepo>(), ServiceLocator.Current.Get<IMapper>()) { }

        public EmployeeManager(IEmployeeRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IQueryable<Models.Employee> Search()
        {
            Mapper.Initialize(cfg =>
                cfg.AddProfile(new AWMapperProfile())
            );
            return repo.GetAllQueryable().ProjectTo<Models.Employee>();
        }
    }
}
