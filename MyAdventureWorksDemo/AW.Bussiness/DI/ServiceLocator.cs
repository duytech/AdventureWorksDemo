namespace AW.Bussiness.DI
{
    #region Using
    using AutoMapper;
    using DataAccess.BuildVersion;
    using DataAccess.Common;
    using DataAccess.Customer;
    using DataAccess.Employee;
    using Models.Mapper;
    using Ninject;
    #endregion
    internal class ServiceLocator
    {
        private static IServiceLocator serviceLocator;

        static ServiceLocator()
        {
            serviceLocator = new DefaultServiceLocator();
        }

        public static IServiceLocator Current => serviceLocator;

        private sealed class DefaultServiceLocator : IServiceLocator
        {
            // Ninject kernel
            private readonly IKernel kernel;

            public DefaultServiceLocator()
            {
                kernel = new StandardKernel();
                LoadBindings();
            }

            public T Get<T>() => kernel.Get<T>();

            private void LoadBindings()
            {
                var mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AWMapperProfile());
                });
                var mapper = mapperConfiguration.CreateMapper();

                kernel.Bind<IMapper>().ToConstant(mapper);

                kernel.Bind<IDbFactory>().To<DbFactory>();
                kernel.Bind<IBuildVersionRepo>().To<BuildVersionRepo>();
                kernel.Bind<ICustomerRepo>().To<CustomerRepo>();
                kernel.Bind<IEmployeeRepo>().To<EmployeeRepo>();
            }
        }
    }
}
