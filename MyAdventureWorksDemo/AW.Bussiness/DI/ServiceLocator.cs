namespace AW.Bussiness.DI
{
    using AutoMapper;
    using DataAccess.BuildVersion;
    using DataAccess.Common;
    using DataAccess.Customer;
    using Models.Mapper;
    using Ninject;
    internal class ServiceLocator
    {
        private static IServiceLocator serviceLocator;

        static ServiceLocator()
        {
            serviceLocator = new DefaultServiceLocator();
        }

        public static IServiceLocator Current
        {
            get
            {
                return serviceLocator;
            }
        }

        private sealed class DefaultServiceLocator : IServiceLocator
        {
            private readonly IKernel kernel;  // Ninject kernel

            public DefaultServiceLocator()
            {
                kernel = new StandardKernel();
                LoadBindings();
            }

            public T Get<T>()
            {
                return kernel.Get<T>();
            }

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
            }
        }
    }
}
