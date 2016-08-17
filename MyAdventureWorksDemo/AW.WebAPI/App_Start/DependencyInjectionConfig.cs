namespace AW.WebAPI.App_Start
{
    using Bussiness.BuildVersion;
    using Bussiness.Person;
    using DryIoc;
    using DryIoc.WebApi;
    using System.Web.Http;
    public class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Register<IPersonManager>(reuse: Reuse.Singleton, made: Made.Of(() => new PersonManager()));
            container.Register<IBuildVersionManager, BuildVersionManager>(reuse: Reuse.Singleton, made: Made.Of(() => new BuildVersionManager()));
            container.WithWebApi(config);
        }
    }
}