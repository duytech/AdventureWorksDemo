namespace AW.WebAPI.App_Start
{
    #region Using
    using Bussiness.BuildVersion;
    using Bussiness.Customer;
    using DryIoc;
    using DryIoc.WebApi;
    using System.Web.Http;
    #endregion
    public class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Register<IBuildVersionManager, BuildVersionManager>(reuse: Reuse.Singleton, made: Made.Of(() => new BuildVersionManager()));
            container.Register<ICustomerManager>(reuse: Reuse.Singleton, made: Made.Of(() => new CustomerManager()));
            container.WithWebApi(config);
        }
    }
}