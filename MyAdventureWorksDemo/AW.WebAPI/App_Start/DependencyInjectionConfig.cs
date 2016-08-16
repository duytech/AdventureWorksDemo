namespace AW.WebAPI.App_Start
{
    using Bussiness.Person;
    using DataAccess.Common;
    using DataAccess.Implementations;
    using DataAccess.Interfaces;
    using DryIoc;
    using DryIoc.WebApi;
    using System.Web.Http;
    public class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Register<IAWDbFactory, AWDbFactory>(Reuse.Singleton);
            container.Register<IPersonRepo, PersonRepo>(Reuse.Singleton);
            container.Register<IPersonManager, PersonManager>(Reuse.Singleton);
            container.Register<IAWBuildVersionRepo, AWBuildVersionRepo>(Reuse.Singleton);
            container.WithWebApi(config);
        }
    }
}